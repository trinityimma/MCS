using MCSLib.PDFs;
using System;
using System.Collections.Generic;

namespace MCSLib.Abstraction
{
    /// <summary>
    /// Interface for probability distribution
    /// </summary>
    public interface IPDF
    {
        /// <summary>
        /// Get simulated probability distribution
        /// </summary>
        /// <param name="iteration">represent the number of iteration for the simulation</param>
        /// <param name="uncertainties">represent uncertainties:
        /// values are added in the order; minValue, maxValue, modeValue, 
        /// averageValue and standardDeviationValue in that order.</param>
        /// <returns>IEnumerable of simulated values</returns>
        ISimulationResult GetDistribution(int iteration, params double[] uncertainties);
        /// <summary>
        /// Get simulated probability distribution
        /// </summary>
        /// <param name="iteration">represent the number of iteration for the simulation</param>
        /// <param name="uncertainties">represent uncertainties:
        /// values are added in the order; minValue, maxValue, modeValue, 
        /// averageValue and standardDeviationValue in that order.</param>
        /// <returns>IEnumerable of simulated values</returns>
        ISimulationResult GetDistribution(int iteration, List<double> uncertainties);
        /// <summary>
        ///  <param name="args">represent probability distribution
        ///  input parameters for simulation</param>
        /// </summary>
        ISimulationResult GetDistribution(Params args);
        /// <summary>
        /// Get simulated probability distribution
        /// </summary>
        /// <param name="action">represent the delegate that needs this random distribution as argument</param>
        /// <param name="iteration">represent the number of iteration for the simulation</param>
        /// <param name="uncertainties">represent uncertainties:
        /// values are added in the order; minValue, maxValue, modeValue, 
        /// averageValue and standardDeviationValue in that order.</param>
        /// <returns>IEnumerable of simulated values</returns>
        ISimulationResult GetDistribution(Func<double, double> action, int iteration, params double[] uncertainties);
        /// <summary>
        /// Get simulated probability distribution
        /// </summary>
        /// <param name="action">represent the delegate that needs this random distribution as argument</param>
        /// <param name="iteration">represent the number of iteration for the simulation</param>
        /// <param name="uncertainties">represent uncertainties:
        /// values are added in the order; minValue, maxValue, modeValue, 
        /// averageValue and standardDeviationValue in that order.</param>
        /// <returns>IEnumerable of simulated values</returns>
        ISimulationResult GetDistribution(Func<double, double> action, int iteration, List<double> uncertainties);
        /// <summary>
        /// Get simulated probability distribution
        /// </summary>
        /// <param name="action">represent the delegate that needs this random distribution as argument</param>
        /// <param name = "args" > represent probability distribution
        ///  input parameters for simulation</param>
        /// <returns>IEnumerable of simulated values</returns>
        ISimulationResult GetDistribution(Func<double, double> action, Params args);
    }
}
