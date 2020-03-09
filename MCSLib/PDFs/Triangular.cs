using System;
using System.Collections.Generic;

namespace MCSLib.PDFs
{
    /// <summary>
    /// Triangular distribution
    /// </summary>
    public class Triangular : PDF
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

        private IList<double> GetTriangularDistribution(int iteration, double minValue, double maxValue, double modeValue)
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
       
        private IList<double> GetTriangularDistribution(Func<double, double> action, int iteration, double minValue, double maxValue, double modeValue)
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

        private IList<double> ValidateInput(int iteration, double[] uncertainties)
        {
            if (uncertainties.Length != 3)
                throw new ArgumentOutOfRangeException("uncertainties", "uncertainties for triangular distribution must have three values, min, mode and max values");
            return GetTriangularDistribution(iteration, uncertainties[0], uncertainties[1], uncertainties[2]);
        }
        private IList<double> ValidateInputWithDelegate(Func<double, double> action, int iteration, double[] uncertainties)
        {
            if (uncertainties.Length != 3)
                throw new ArgumentOutOfRangeException("uncertainties", "uncertainties for triangular distribution must have three values, min, mode and max values");
            return GetTriangularDistribution(action, iteration, uncertainties[0], uncertainties[1], uncertainties[2]);
        }
    }
}
