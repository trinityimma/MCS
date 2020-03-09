using MCSLib.PDFs;
using System;
using System.Collections.Generic;

namespace MCSLib.Simulation
{
    /// <summary>
    /// Represents user defined variables for 
    /// probability distribution and simulation results
    /// </summary>
    public class DistributionInput
    {
        /// <summary>
        ///  Represent probability distribution
        ///  input parameters for simulation
        /// </summary>
        public Params Args { get; set; }
        /// <summary>
        ///  Represent the number of iteration for the simulation
        /// </summary>
        public int Iteration { get; set; }

        /// <summary>
        ///  Represent the class interval for 
        ///  creating the bin sizes
        /// </summary>
        public int Interval { get; set; }

        ///  /// <summary>
        /// Represent uncertainties:
        /// values are added in the order; minValue, maxValue, modeValue, 
        /// averageValue and standardDeviationValue in that order.
        /// </summary>
        public List<double> UncertaintyList { get; set; }
        /// <summary>
        /// Represent uncertainties:
        /// values are added in the order; minValue, maxValue, modeValue, 
        /// averageValue and standardDeviationValue in that order.
        /// </summary>
        public double[] UncertaintyArray { get; set; }
        /// <summary>
        /// Represent the delegate that needs this random distribution as argument
        /// </summary>
        public Func<double, double> Delegate { get; set; }
    }
}
