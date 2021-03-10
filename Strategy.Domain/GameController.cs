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

            //try
            //{
            //    foreach (Unit u1 in _map.Units)
            //    {
            //        if (u1.X == x && u1.Y == y)
            //            return false;
            //    }
            //}
            //catch
            //{
            //    throw new ArgumentException("Неизвестный тип");
            //}
            //return true;

            foreach (Unit u1 in _map.Units)
            {
                if (u1.X == x && u1.Y == y)
                    return false;

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
        public bool CanAttackUnit(object attackU, object defenseU)
        {
            try
            {
                Unit attackUnit = (Unit)attackU;
                Unit defenseUnit = (Unit)defenseU;

                if (defenseUnit.IsDead())
                    return false;

                if (attackUnit.Player == defenseUnit.Player)
                    return false;

                var dx = attackUnit.X - defenseUnit.X;
                var dy = attackUnit.Y - defenseUnit.Y;

                bool temp = dx >= -attackUnit.AttackRange && dx <= attackUnit.AttackRange && dy >= -attackUnit.AttackRange && dy <= attackUnit.AttackRange;

                return temp;
            }
            catch
            {
                throw new ArgumentException("Неизвестный тип");
            }
        }

        /// <summary>
        /// Атаковать указанного юнита.
        /// </summary>
        /// <param name="attackUnit">Юнит, который собирается совершить атаку.</param>
        /// <param name="defenseUnit">Юнит, который является целью.</param>
        public void AttackUnit(Object attackU, Object defenseU)
        {
            try
            {
                Unit attackUnit = (Unit)attackU;
                Unit defenseUnit = (Unit)defenseU;

                if (!CanAttackUnit(attackUnit, defenseUnit))
                    return;

                var dx = attackUnit.X - defenseUnit.X;
                var dy = attackUnit.Y - defenseUnit.Y;

                if(attackUnit.IsMelee())
                    defenseUnit.HP = Math.Max((defenseUnit.HP - attackUnit.DamageValue), 0);
                else if (dx >= -1 && dx <= 1 && dy >= -1 && dx <= 1)
                {
                    defenseUnit.HP = Math.Max((defenseUnit.HP - attackUnit.DamageValue / 2), 0);
                }
                else
                {
                    defenseUnit.HP = Math.Max((defenseUnit.HP - attackUnit.DamageValue), 0);
                }
            }
            catch
            {
                throw new ArgumentException("Неизвестный тип");
            }
        }

        /// <summary>
        /// Получить изображение объекта.
        /// </summary>
        public ImageSource GetObjectSource(object o)
        {
            try
            {
                if(o is Unit unit)
                {
                    return unit.IsDead() ? Dead.Image : unit.Image;
                }
                return (o as Cell).Image;
            }
            catch
            {
                throw new ArgumentException("Неизвестный тип");
            }
        }
    }
}