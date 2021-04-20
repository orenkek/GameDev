using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Strategy.Domain
{
    class DataSet
    {
        #region Initialize HP of Units
        public static int InitializeArcherHP() => 50;
        public static int InitializeCatapultHP() => 70;
        public static int InitializeHorsemanHP() => 200;
        public static int InitializeSwordsmanHP() => 100;
        #endregion

        #region Initialize images of models
        public static ImageSource InitializeArcherImage() => new BitmapImage(new Uri("Resources/Units/Archer.png", UriKind.Relative));
        public static ImageSource InitializeCatapultImage() => new BitmapImage(new Uri("Resources/Units/Catapult.png", UriKind.Relative));
        public static ImageSource InitializeHorsemanImage() => new BitmapImage(new Uri("Resources/Units/Horseman.png", UriKind.Relative));
        public static ImageSource InitializeSwordsmanImage() => new BitmapImage(new Uri("Resources/Units/Swordsman.png", UriKind.Relative));
        public static ImageSource InitializeDeadUnitImage() => new BitmapImage(new Uri("Resources/Units/Dead.png", UriKind.Relative));
        public static ImageSource InitializeGrassImage() => new BitmapImage(new Uri("Resources/Units/Grass.png", UriKind.Relative));
        public static ImageSource InitializeWaterImage() => new BitmapImage(new Uri("Resources/Units/Water.png", UriKind.Relative));
        #endregion

        #region Initialize attack range of Units

        public static int InitializeAttackRangeOfArcher() => 5;
        public static int InitializeAttackRangeOfCatapult() => 10;
        public static int InitializeAttackRangeOfHorseman() => 1;
        public static int InitializeAttackRangeOfSwordsman() => 1;

        #endregion

        #region Initialize damage value of units

        public static int InitializeArcherDamageValue() => 50;
        public static int InitializeCatapultDamageValue() => 100;
        public static int InitializeHorsemanDamageValue() => 75;
        public static int InitializeSwordsmanDamageValue() => 50;

        #endregion

        #region Initialize max steps of units

        public static int InitializeArcherMaxSteps() => 3;
        public static int InitializeCatapultMaxSteps() => 1;
        public static int InitializeHorsemanMaxSteps() => 10;
        public static int InitializeSwordsmanMaxSteps() => 5;

        #endregion
    }
}
