using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Strategy.Domain.Models;
using Strategy.Domain.Models.Base;

namespace Strategy.Domain
{
    /// <summary>
    /// Контроллер хода игры.
    /// </summary>
    public class GameController
    {
        private readonly Map _map;

        // Очки жизни каждого юнита.
        private readonly Dictionary<object, int> _hp = new Dictionary<object, int>();

        //private readonly ImageSource _archerSource = BuildSourceFromPath("Resources/Units/Archer.png");
        //private readonly ImageSource _catapultSource = BuildSourceFromPath("Resources/Units/Catapult.png");
        //private readonly ImageSource _horsemanSource = BuildSourceFromPath("Resources/Units/Horseman.png");
        //private readonly ImageSource _swordsmanSource = BuildSourceFromPath("Resources/Units/Swordsman.png");
        //private readonly ImageSource _deadUnitSource = BuildSourceFromPath("Resources/Units/Dead.png");
        //private readonly ImageSource _grassSource = BuildSourceFromPath("Resources/Ground/Grass.png");
        //private readonly ImageSource _waterSource = BuildSourceFromPath("Resources/Ground/Water.png");

        /// <inheritdoc />
        public GameController(Map map)
        {
            _map = map;
        }


        /// <summary>
        /// Получить координаты объекта.
        /// </summary>
        /// <param name="o">Координаты объекта, которые необходимо получить.</param>
        /// <returns>Координата x, координата y.</returns>

        public Coordinates GetObjectCoordinates(Cell c)
        {
            try { return c.GetCoordinates(); } catch { throw new ArgumentException("Неизвестный тип"); }
        }

        /// <summary>
        /// Может ли юнит передвинуться в указанную клетку.
        /// </summary>
        /// <param name="unit">Юнит.</param>
        /// <param name="x">Координата X клетки.</param>
        /// <param name="y">Координата Y клетки.</param>
        /// <returns>
        /// <see langvalue="true" />, если юнит может переместиться
        /// <see langvalue="false" /> - иначе.
        /// </returns>

        public bool CanMoveUnit(Unit unit, int x, int y)
        {
            if (Math.Abs(unit.X - x) > unit.MaxSteps || Math.Abs(unit.Y - y) > unit.MaxSteps)
                return false;
            else if (!(unit is Unit))
                throw new ArgumentException("Неизвестный тип");

            foreach (object g in _map.Ground)
            {
                if (g is Water w && w.X == x && w.Y == y)
                {
                    return false;
                }
            }

            foreach (object u1 in _map.Units)
            {
                if (u1 is Archer a1)
                {
                    if (a1.X == x && a1.Y == y)
                        return false;
                }
                else if (u1 is Catapult c1)
                {
                    if (c1.X == x && c1.Y == y)
                        return false;
                }
                else if (u1 is Horseman h1)
                {
                    if (h1.X == x && h1.Y == y)
                        return false;
                }
                else if (u1 is Swordsman s1)
                {
                    if (s1.X == x && s1.Y == y)
                        return false;
                }
                else
                    throw new ArgumentException("Неизвестный тип");
            }

            return true;
        }

        /// <summary>
        /// Передвинуть юнита в указанную клетку.
        /// </summary>
        /// <param name="u">Юнит.</param>
        /// <param name="x">Координата X клетки.</param>
        /// <param name="y">Координата Y клетки.</param>
        public void MoveUnit(Unit u, int x, int y)
        {
            try
            {
                if (!CanMoveUnit(u, x, y))
                    return;

                u.X = x;
                u.Y = y;
            }
            catch
            {
                throw new ArgumentException("Неизвестный тип");
            }
        }

        /// <summary>
        /// Проверить, может ли один юнит атаковать другого.
        /// </summary>
        /// <param name="attackUnit">Юнит, который собирается совершить атаку.</param>
        /// <param name="defenseUnit">Юнит, который является целью.</param>
        /// <returns>
        /// <see langvalue="true" />, если атака возможна
        /// <see langvalue="false" /> - иначе.
        /// </returns>
        public bool CanAttackUnit(Object attackUnit, Object defenseUnit)
        {
            //try
            //{
            //    var defenseUnitCoor = GetObjectCoordinates((Cell)defenseUnit);
            //    Player player;
            //    player = (defenseUnit as Unit).Player;
            //    if ((IsDead(defenseUnit)))
            //        return false;

            //}
            //catch
            //{
            //    throw new ArgumentException("Неизвестный тип");
            //}

            var cr = GetObjectCoordinates((Cell)defenseUnit);
            Player ptu;
            try
            {
                ptu = (defenseUnit as Unit).Player;
            }
            catch
            {
                throw new ArgumentException("Неизвестный тип");
            }

            if (IsDead(defenseUnit))
                return false;

            if (attackUnit is Archer a1)
            {
                if (a1.Player == ptu)
                    return false;

                var dx = a1.X - cr.X;
                var dy = a1.Y - cr.Y;

                return dx >= -5 && dx <= 5 && dy >= -5 && dy <= 5;
            }

            if (attackUnit is Catapult c1)
            {
                if (c1.Player == ptu)
                    return false;

                var dx = c1.X - cr.X;
                var dy = c1.Y - cr.Y;

                return dx >= -10 && dx <= 10 && dy >= -10 && dy <= 10;
            }

            if (attackUnit is Horseman h1)
            {
                if (h1.Player == ptu)
                    return false;

                var dx = h1.X - cr.X;
                var dy = h1.Y - cr.Y;

                return (dx == -1 || dx == 0 || dx == 1) &&
                       (dy == -1 || dy == 0 || dy == 1);
            }

            if (attackUnit is Swordsman s1)
            {
                if (s1.Player == ptu)
                    return false;

                var dx = s1.X - cr.X;
                var dy = s1.Y - cr.Y;

                return (dx == -1 || dx == 0 || dx == 1) &&
                       (dy == -1 || dy == 0 || dy == 1);
            }

            throw new ArgumentException("Неизвестный тип");
        }

        /// <summary>
        /// Атаковать указанного юнита.
        /// </summary>
        /// <param name="attackUnit">Юнит, который собирается совершить атаку.</param>
        /// <param name="defenseUnit">Юнит, который является целью.</param>
        public void AttackUnit(Object attackUnit, Object defenseUnit)
        {
            if (!CanAttackUnit((Unit)attackUnit, (Unit)defenseUnit))
                return;

            InitializeUnitHp(defenseUnit);
            var thp = _hp[defenseUnit];
            var cr = GetObjectCoordinates((Cell)defenseUnit);
            int d = 0;

            if (attackUnit is Archer a)
            {
                d = 50;

                var dx = a.X - cr.X;
                var dy = a.Y - cr.Y;

                if ((dx == -1 || dx == 0 || dx == 1) &&
                    (dy == -1 || dy == 0 || dy == 1))
                {
                    d /= 2;
                }
            }
            else if (attackUnit is Catapult c)
            {
                d = 100;

                var dx = c.X - cr.X;
                var dy = c.Y - cr.Y;

                if ((dx == -1 || dx == 0 || dx == 1) &&
                    (dy == -1 || dy == 0 || dy == 1))
                {
                    d /= 2;
                }
            }
            else if (attackUnit is Horseman)
            {
                d = 75;
            }
            else if (attackUnit is Swordsman)
            {
                d = 50;
            }
            else
                throw new ArgumentException("Неизвестный тип");

            _hp[defenseUnit] = Math.Max(thp - d, 0);
        }

        /// <summary>
        /// Получить изображение объекта.
        /// </summary>
        public ImageSource GetObjectSource(object o)
        {
                if (!(o is Unit))
                    return ((Cell)o).Image;
                else
                {
                    if (IsDead(o))
                        return Dead.Image;
                return ((Unit)o).Image;
                }

        }

        /// <summary>
        /// Проверить, что указанный юнит умер.
        /// </summary>
        /// <param name="u">Юнит.</param>
        /// <returns>
        /// <see langvalue="true" />, если у юнита не осталось очков здоровья,
        /// <see langvalue="false" /> - иначе.
        /// </returns>
        private bool IsDead(object u)
        {
            if (_hp.TryGetValue(u, out var hp))
                return hp == 0;


            InitializeUnitHp(u);
            return false;
        }

        /// <summary>
        /// Инициализировать здоровье юнита.
        /// </summary>
        /// <param name="u">Юнит.</param>
        private void InitializeUnitHp(object u)
        {
            if (_hp.ContainsKey(u))
                return;

            if (u is Archer)
            {
                _hp.Add(u, 50);
            }
            else if (u is Catapult)
            {
                _hp.Add(u, 70);
            }
            else if (u is Horseman)
            {
                _hp.Add(u, 200);
            }
            else if (u is Swordsman)
            {
                _hp.Add(u, 100);
            }
            else
                throw new ArgumentException("Неизвестный тип");
        }
    }
}