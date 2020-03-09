using System;
using System.Collections.Generic;

namespace MCSLib.PDFs
{
    public class Triangular : PDF
    {
        public override IEnumerable<double> GetDistribution(int iteration, params double[] uncertainties)
        {
            return ValidateInput(iteration, uncertainties);
        }

        public override IEnumerable<double> GetDistribution(int iteration, List<double> uncertainties)
        {
            return ValidateInput(iteration, uncertainties.ToArray());
        }

        public override IEnumerable<double> GetDistribution(Params args)
        {
            return ValidateInput(args.Iteration, args.Uncertainties);
        }

        public override IEnumerable<double> GetDistribution(Func<double, double> action, int iteration, params double[] args)
        {
            return ValidateInputWithDelegate(action, iteration, args);
        }

        public override IEnumerable<double> GetDistribution(Func<double, double> action, int iteration, List<double> args)
        {
            return ValidateInputWithDelegate(action, iteration, args.ToArray());
        }

        public override IEnumerable<double> GetDistribution(Func<double, double> action, Params args)
        {
            return ValidateInputWithDelegate(action, args.Iteration, args.Uncertainties);
        }

        private IEnumerable<double> GetTriangularDistribution(int iteration, double minValue, double modeValue, double maxValue)
        {
            Random rand = new Random();
            double fc = (maxValue - minValue) / (modeValue - minValue);
            var results = new List<double>();

            for (int i = 0; i < iteration; i++)
            {
                var randomness = rand.NextDouble();
                if (randomness <= fc)
                {
                    double ans = minValue + Math.Sqrt((randomness * (modeValue - minValue) * (maxValue - minValue)));
                    results.Add(ans);
                }
                else
                {
                    double ans = modeValue - Math.Sqrt((1 - randomness * (modeValue - minValue) * (modeValue - maxValue)));
                    results.Add(ans);
                }
            }
            return results;
        }
       
        private IEnumerable<double> GetTriangularDistribution(Func<double, double> action, int iteration, double minValue, double modeValue, double maxValue)
        {
            Random rand = new Random();
            var results = new List<double>();
            double fc = (maxValue - minValue) / (modeValue - minValue);
            for (int i = 0; i < iteration; i++)
            {
                var randomness = rand.NextDouble();
                if (randomness <= fc)
                {
                    double ans = minValue + Math.Sqrt((randomness * (modeValue - minValue) * (maxValue - minValue)));
                    results.Add(action(ans));
                }
                else
                {
                    double ans = modeValue - Math.Sqrt((1 - randomness * (modeValue - minValue) * (modeValue - maxValue)));
                    results.Add(action(ans));
                }
            }
            return results;
        }

        private IEnumerable<double> ValidateInput(int iteration, double[] uncertainties)
        {
            if (uncertainties.Length != 2)
                throw new ArgumentOutOfRangeException("uncertainties", "uncertainties for uniform distribution must have two values, minValue and maxValue");
            return GetTriangularDistribution(iteration, uncertainties[0], uncertainties[1], uncertainties[1]);
        }
        private IEnumerable<double> ValidateInputWithDelegate(Func<double, double> action, int iteration, double[] uncertainties)
        {
            if (uncertainties.Length != 2)
                throw new ArgumentOutOfRangeException("uncertainties", "uncertainties for uniform distribution must have two values, minValue and maxValue");
            return GetTriangularDistribution(action, iteration, uncertainties[0], uncertainties[1], uncertainties[1]);
        }
    }
}
