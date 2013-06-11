using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;

namespace GenAI.Core.Utils
{
    internal static class RandomHelper
    {
        private static readonly DiscreteUniform _rnd = new DiscreteUniform(0, 1000);

        public static int RouletteSelection(uint[] selectionTable)
        {
            var total = selectionTable[selectionTable.Length - 1];
            uint randomSelection = (uint)_rnd.Sample() / 1000 * total;
            int idx = -1;
            int first = 0;
            int last = selectionTable.Length - 1;
            int mid = (last - first) / 2;

            while (idx == -1 && first <= last)
            {
                if (randomSelection < selectionTable[mid])
                {
                    last = mid;
                }
                else if (randomSelection > selectionTable[mid])
                {
                    first = mid;
                }
                else if (randomSelection == selectionTable[mid])
                {
                    return mid;
                }

                mid = (first + last) / 2;

                // lies between i and i+1
                if ((last - first) == 1)
                {
                    idx = last;
                }
            }
            return idx;
        }
    }
}
