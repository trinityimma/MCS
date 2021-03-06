﻿using MCSLib.PDFs;
using MCSLib.Simulation;
using System.Collections.Generic;

namespace MCSLib.Abstraction
{
    /// <summary>
    /// A simulator interface for running Monte Carlo simulation
    /// </summary>
    public interface ISimulator
    {
        /// <summary>
        /// Represents actual and fitted simulation results based on Monte Carlo method
        /// </summary>
        ISimulationResult SimulationResult { get; set; }

        /// <summary>
        /// Returns CDP and PDF based on Monte Carlo method
        /// </summary>
        IList<StatisticalResult> SimulationResults { get; set; }
        /// <summary>
        /// Returns simulation results based on Monte Carlo method
        /// </summary>
        IList<StatisticalResult> Run();
        /// <summary>
        /// Returns simulation results based on Monte Carlo method
        /// </summary>
        /// <param name="distributionInput">Represents user defined variables for 
        /// probability distribution and simulation results</param>
        /// <param name="distributionType">Represents selected probability distribution</param>
        IList<StatisticalResult> Run(DistributionInput distributionInput, DistributionType distributionType);
    }
}
