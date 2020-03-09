using System;
using System.Collections.Generic;

namespace MCSLib.PDFs
{
    public class Uniform : PDF
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

        private IEnumerable<double> ValidateInput(int iteration, double[] uncertainties)
        {
            if (uncertainties.Length != 2)
                throw new ArgumentOutOfRangeException("uncertainties", "uncertainties for uniform distribution must have two values, minValue and maxValue");
            return GetUniformDistribution(iteration, uncertainties[0], uncertainties[1]);
        }
        private IEnumerable<double> ValidateInputWithDelegate(Func<double, double> action,int iteration, double[] uncertainties)
        {
            if (uncertainties.Length != 2)
                throw new ArgumentOutOfRangeException("uncertainties", "uncertainties for uniform distribution must have two values, minValue and maxValue");
            return GetUniformDistribution(action, iteration, uncertainties[0], uncertainties[1]);
        }
        private IEnumerable<double> GetUniformDistribution(int iteration, double minValue, double maxValue)
        {
            Random rand = new Random();
            var results = new List<double>();
            for (int i = 0; i < iteration; i++)
            {
                double ans = minValue + (maxValue - minValue) * rand.NextDouble();
                results.Add(ans);
            }
            return results;
        }

        private IEnumerable<double> GetUniformDistribution(Func<double, double> action, int iteration, double minValue, double maxValue)
        {
            Random rand = new Random();
            var results = new List<double>();
            for (int i = 0; i < iteration; i++)
            {
                double ans = minValue + (maxValue - minValue) * rand.NextDouble();
                results.Add(action(ans));
            }
            return results;
        }
    }
}
