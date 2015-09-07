using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiaiWine
{
    public static class Extensions
    {
        public static double StdDev(this IEnumerable<double> values)
        {
            double ret = 0;
            int count = values.Count();
            if (count > 1)
            {
                //Compute the Average
                double avg = values.Average();

                //Perform the Sum of (value-avg)^2
                double sum = values.Sum(d => (d - avg) * (d - avg));

                //Put it all together
                ret = Math.Sqrt(sum / count);
            }
            return ret;
        }

        public static double NormalizeZScore(this double value, double mean, double stdDev)
        {
            return (value - mean)/ stdDev;
        }

        public static double NormalizeMinMax(this double value, double max, double min)
        {
            return (((value - min) / (max - min)) * 0.8) + 0.1;
        }
    }
}
