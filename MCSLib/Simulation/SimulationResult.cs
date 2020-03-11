using MCSLib.Abstraction;
using System.Collections.Generic;

namespace MCSLib.Simulation
{
    /// <summary>
    /// Represents actual and fitted simulation results based on Monte Carlo method
    /// </summary>
    public class SimulationResult: ISimulationResult
    {
        /// <summary>
        /// ctor
        /// </summary>
        public SimulationResult()
        {
            SimulatedValues = new List<double>();
            FittedValues = new List<double>();
        }
        /// <summary>
        /// Returns simulation results based on Monte Carlo method
        /// </summary>
        public IList<double> SimulatedValues { get; set; }
        /// <summary>
        /// Returns fitted simulation results based on Monte Carlo method
        /// </summary>
        public IList<double> FittedValues { get; set; }
    }
}
