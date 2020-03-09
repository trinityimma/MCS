namespace MCSLib.PDFs
{
    public struct Params
    {
        /// <summary>
        ///  <param name="Iteration">represent the number of iteration for the simulation</param>
        /// </summary>
        public int Iteration { get; set; }
        /// <summary>
        /// <param name="UncertaintyArray">represent uncertainties:
        /// values are added in the order; minValue, maxValue, modeValue, 
        /// averageValue and standardDeviationValue in that order.
        /// </param>
        /// </summary>
        public double[] Uncertainties { get; set; }
    }
}
