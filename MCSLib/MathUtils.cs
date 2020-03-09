using System.Collections.Generic;
using System.Linq;

namespace MCSLib
{
    public static class MathUtils
    {
        public static List<double> GetExpectation(int interval, IList<double> reletivefrequencies, IList<double> cumfrequencies)
        {
            var result = new List<double>();
            for (int i = 0; i < interval; i++)
                result.Add(cumfrequencies[i] - reletivefrequencies[i]);
            return result;
        }
        public static List<double> GetCumFrequency(int interval, IList<double> reletivefrequencies)
        {
            var result = new List<double> { 1};
            for (int i = 0; i < interval - 1; i++)
                result.Add(result[i] - reletivefrequencies[i]);
            return result;
        }

        public static List<double> GetRelFrequency(int interval, IList<double> frequencies)
        {
            var result = new List<double>();
            for (int i = 0; i < interval; i++)
            {
                double sum = frequencies.Sum();
                double relf = frequencies[i] / sum;
                result.Add(relf);
            }
            return result;
        }

        public static List<double> GetBinSize(double maxValue, double minValue, int interval)
        {
            double step = (maxValue - minValue) / interval;
            var ans = new List<double>();

            for (int i = 0; i < interval; i++)
            {
                double result = (minValue + step * i);
                ans.Add(result);
            }
            return ans;
        }

        public static List<double> GetFrequency(int iteration, int interval, IList<double> binSizes, IList<double> simulatedValues)
        {
            double lowerBound = -1;
            double upperBound = 0;
            List<double> result = new List<double>();
            int dataNum = iteration - interval;

            for (int i = 0; i < iteration - dataNum; i++)
            {
                int frequency = 0;
                upperBound = binSizes[i];

                for (int j = 0; j < iteration; j++)
                {
                    if (simulatedValues[j] > lowerBound && simulatedValues[j] <= upperBound)
                    {
                        frequency += 1;
                    }
                }
                result.Add(frequency);
                lowerBound = upperBound;
            }
            return result;
        }
    }
}
