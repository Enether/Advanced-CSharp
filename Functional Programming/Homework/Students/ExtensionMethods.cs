using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public static class ExtensionMethods
    {
        public static bool ContainsExactlyTwoOf(this IList<int> list, int value)
        {
            bool doesContain = false;
            byte timesContained = 0;
            foreach (var number in list)
            {
                if (number == value)
                    timesContained++;
            }

            if (timesContained == 2)
                doesContain = true;
            return doesContain;
        }
    }
}
