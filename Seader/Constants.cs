using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seader
{
    public static class Constants
    {
        private static int[] updateIntervalList = new int[] { 5, 10, 15, 30, 45, 60, 90, 120 };

        public static int[] GetIntervalList
        {
            get { return updateIntervalList; }
        }
    }
}
