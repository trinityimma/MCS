using MCSLib.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MCSLib
{
    internal static class MathUtils
    {
        internal static IList<double> GetExpectation(StatisticalInput statisticalInput, IList<double> simulatedValues)
        {
            var result = new List<double>();
            IList<double> reletivefrequencies = GetRelFrequency(statisticalInput,simulatedValues);
            IList<double> cumfrequencies = GetCumFrequency(statisticalInput, simulatedValues);
            for (int i = 0; i < statisticalInput.Interval; i++)
                result.Add(cumfrequencies[i] - reletivefrequencies[i]);
            return result;
        }

        internal static double GoodnessOfFitTest(Func<double> @delegate)
        {
            return  ((751207.14 * @delegate() * @delegate() * (100 - @delegate())) / (@delegate()));
        }
        internal static IList<double> GetCumFrequency(StatisticalInput statisticalInput, IList<double> simulatedValues)
        {
            var result = new List<double> { 1};
            IList<double> reletivefrequencies = GetRelFrequency(statisticalInput,simulatedValues);
            for (int i = 0; i < statisticalInput.Interval - 1; i++)
                result.Add(result[i] - reletivefrequencies[i]);
            return result;
        }

        public static IList<double> GetRelFrequency(StatisticalInput statisticalInput, IList<double> simulatedValues)
        {
            var result = new List<double>();
            IList<double> frequencies = GetFrequency(statisticalInput, simulatedValues);
            double sum = frequencies.Sum();

            for (int i = 0; i < statisticalInput.Interval; i++)
            {
                double relf = frequencies[i] / sum;
                result.Add(relf);
            }
            return result;
        }



        public static IList<double> GetBinSizes(double maxValue, double minValue, int interval)
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
        
        private static IList<double> GetFrequency(StatisticalInput statisticalInput,IList<double> simulatedValues)
        {
            double lowerBound = -1;
            double upperBound = 0;
            IList<double> binSizes = GetBinSizes(statisticalInput.MaxValue, statisticalInput.MinValue, statisticalInput.Interval);
            List<double> result = new List<double>();
            int dataNum = statisticalInput.Iteration - statisticalInput.Interval;

            for (int i = 0; i < statisticalInput.Iteration - dataNum; i++)
            {
                int frequency = 0;
                upperBound = binSizes[i];

                for (int j = 0; j < statisticalInput.Iteration; j++)
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
