namespace MCSLib.Simulation
{
    /// <summary>
    /// Represents simulated results
    /// </summary>
    public class StatisticalResult
    {
        /// <summary>
        /// Returns the relative frequency 
        /// calculated from the simulated results
        /// </summary>
        public double RelativeFrequency { get; set; }
        /// <summary>
        /// Returns the Bin Size 
        /// calculated from the simulated results
        /// </summary>
        public double BinSize { get; set; }
        /// <summary>
        /// Returns the cumulative frequency 
        /// calculated from the simulated results
        /// </summary>
        public double CumulativeFrequency { get; set; }
        /// <summary>
        /// Returns the probability of uncertainties 
        /// calculated from the simulated results
        /// </summary>
        public double Expectation { get; set; }
    }
}
