using System;
using System.Collections.Generic;

namespace MCSLib.PDFs
{
    /// <summary>
    /// Uniform (contineous) distribution
    /// </summary>
    public class Uniform : PDF
    {
        /// <summary>
        /// Get simulated probability distribution
        /// </summary>
        /// <param name="iteration">represent the number of iteration for the simulation</param>
        /// <param name="uncertainties">represent uncertainties:
        /// values are added in the order; minValue, maxValue, modeValue, 
        /// averageValue and standardDeviationValue in that order.</param>
        /// <returns>IEnumerable of simulated values</returns>
        public override IList<double> GetDistribution(int iteration, params double[] uncertainties)
        {
            return ValidateInput(iteration, uncertainties);
        }
        /// <summary>
        /// Get simulated probability distribution
        /// </summary>
        /// <param name="iteration">represent the number of iteration for the simulation</param>
        /// <param name="uncertainties">represent uncertainties:
        /// values are added in the order; minValue, maxValue, modeValue, 
        /// averageValue and standardDeviationValue in that order.</param>
        /// <returns>IEnumerable of simulated values</returns>

        public override IList<double> GetDistribution(int iteration, List<double> uncertainties)
        {
            return ValidateInput(iteration, uncertainties.ToArray());
        }
        /// <summary>
        ///  <param name="args">represent probability distribution
        ///  input parameters for simulation</param>
        /// </summary>
        public override IList<double> GetDistribution(Params args)
        {
            return ValidateInput(args.Iteration, args.Uncertainties);
        }
        /// <summary>
        /// Get simulated probability distribution
        /// </summary>
        /// <param name="action">represent the delegate that needs this random distribution as argument</param>
        /// <param name="iteration">represent the number of iteration for the simulation</param>
        /// <param name="args">represent uncertainties:
        /// values are added in the order; minValue, maxValue, modeValue, 
        /// averageValue and standardDeviationValue in that order.</param>
        /// <returns>IEnumerable of simulated values</returns>
        public override IList<double> GetDistribution(Func<double, double> action, int iteration, params double[] args)
        {
            return ValidateInputWithDelegate(action, iteration, args);
        }
        /// <summary>
        /// Get simulated probability distribution
        /// </summary>
        /// <param name="action">represent the delegate that needs this random distribution as argument</param>
        /// <param name="iteration">represent the number of iteration for the simulation</param>
        /// <param name="args">represent uncertainties:
        /// values are added in the order; minValue, maxValue, modeValue, 
        /// averageValue and standardDeviationValue in that order.</param>
        /// <returns>IEnumerable of simulated values</returns>
        public override IList<double> GetDistribution(Func<double, double> action, int iteration, List<double> args)
        {
            return ValidateInputWithDelegate(action, iteration, args.ToArray());
        }
        /// <summary>
        /// Get simulated probability distribution
        /// </summary>
        /// <param name="action">represent the delegate that needs this random distribution as argument</param>
        /// <param name = "args" > represent probability distribution
        ///  input parameters for simulation</param>
        /// <returns>IEnumerable of simulated values</returns>
        public override IList<double> GetDistribution(Func<double, double> action, Params args)
        {
            return ValidateInputWithDelegate(action, args.Iteration, args.Uncertainties);
        }

        private IList<double> ValidateInput(int iteration, double[] uncertainties)
        {
            if (uncertainties.Length != 2)
                throw new ArgumentOutOfRangeException("uncertainties", "uncertainties for uniform distribution must have two values, minValue and maxValue");
            return GetUniformDistribution(iteration, uncertainties[0], uncertainties[1]);
        }
        private IList<double> ValidateInputWithDelegate(Func<double, double> action,int iteration, double[] uncertainties)
        {
            if (uncertainties.Length != 2)
                throw new ArgumentOutOfRangeException("uncertainties", "uncertainties for uniform distribution must have two values, minValue and maxValue");
            return GetUniformDistribution(action, iteration, uncertainties[0], uncertainties[1]);
        }
        private IList<double> GetUniformDistribution(int iteration, double minValue, double maxValue)
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

        private IList<double> GetUniformDistribution(Func<double, double> action, int iteration, double minValue, double maxValue)
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
