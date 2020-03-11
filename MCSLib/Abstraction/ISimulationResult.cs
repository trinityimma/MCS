using System.Collections.Generic;

namespace MCSLib.Abstraction
{
    /// <summary>
    /// Represents actual and fitted simulation results based on Monte Carlo method
    /// </summary>
    public interface ISimulationResult
    {
        /// <summary>
        /// Returns simulation results based on Monte Carlo method
        /// </summary>
        IList<double> SimulatedValues { get; set; }
        /// <summary>
        /// Returns fitted simulation results based on Monte Carlo method
        /// </summary>
        IList<double> FittedValues { get; set; }
    }
}
