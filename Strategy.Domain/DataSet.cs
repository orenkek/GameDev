using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
