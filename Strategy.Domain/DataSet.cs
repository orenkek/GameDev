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
        public static ImageSource InitializeArcherWater() => new BitmapImage(new Uri("Resources/Units/Water.png", UriKind.Relative));

        #endregion
    }
}
