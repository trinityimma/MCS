using MCSLib.Abstraction;
using MCSLib.PDFs;
using System.Collections.Generic;
using System.Linq;

namespace MCSLib.Simulation
{
    /// <summary>
    /// Simulator for running Monte Carlo simulation
    /// </summary>
    public class Simulator: ISimulator
    {

        /// <summary>
        /// Returns simulation results based on Monte Carlo method
        /// </summary>
        public IList<SimulationResult> SimulationResults { get; set; }


        /// <summary>
        /// Returns simulation results based on Monte Carlo method
        /// </summary>
        public IList<SimulationResult> Run()
        {
            var distribution = ToggleDistribution(_distributionInput, _distributionType);
            _statisticalInput.Interval = _distributionInput.Interval;
            _statisticalInput.Iteration = _distributionInput.Iteration;
            _statisticalInput.MinValue = distribution.Min();
            _statisticalInput.MaxValue = distribution.Max();
            return GetSimResult(_statisticalInput, distribution);
        }
        /// <summary>
        /// Returns simulation results based on Monte Carlo method
        /// </summary>
        /// <param name="distributionInput">Represents user defined variables for 
        /// probability distribution and simulation results</param>
        /// <param name="distributionType">Represents selected probability distribution</param>
        public IList<SimulationResult> Run(DistributionInput distributionInput,DistributionType distributionType)
        {
            var distribution = ToggleDistribution(distributionInput,distributionType);
            if (_statisticalInput == null)
                _statisticalInput = new StatisticalInput();
            _statisticalInput.Interval = distributionInput.Interval;
            _statisticalInput.Iteration = distributionInput.Iteration;
            _statisticalInput.MinValue = distribution.Min();
            _statisticalInput.MaxValue = distribution.Max();

            return GetSimResult(_statisticalInput, distribution);
        }

        /// <summary>
        /// Simulator contructor
        /// </summary>
        /// <param name="distributionInput">Represents user defined variables for 
        /// probability distribution and simulation results</param>
        /// <param name="distributionType">Represents selected probability distribution</param>
        public Simulator(DistributionInput distributionInput, DistributionType distributionType)
        {
            _distributionInput = distributionInput;
            _distributionType = distributionType;
        }
        /// <summary>
        /// Simulator default contructor
        /// </summary>
        public Simulator()
        {

        }

        private IList<SimulationResult> GetSimResult(StatisticalInput statisticalInput, IList<double> distribution)
        {
            SimulationResults = new List<SimulationResult>();
            var relFrequencies = MathUtils.GetRelFrequency(statisticalInput, distribution);
            var cumFrequencies = MathUtils.GetCumFrequency(statisticalInput, distribution);
            var expectations = MathUtils.GetExpectation(statisticalInput, distribution);
            for (int i = 0; i < _statisticalInput.Interval; i++)
            {
                SimulationResults.Add(new SimulationResult()
                {
                    Expectation = expectations[i],
                    RelativeFrequency = relFrequencies[i],
                    CumulativeFrequency = cumFrequencies[i]
                });
            }
            return SimulationResults;
        }
        private IList<double> ToggleDistribution(DistributionInput distributionInput, DistributionType distributionType)
        {
            IList<double> distributions=new List<double>();
            switch (distributionType)
            {
                case DistributionType.Uniform:
                    distributions= new Uniform().GetDistribution(distributionInput.Delegate,
                                                        distributionInput.Iteration, distributionInput.UncertaintyArray);
                    break;
                case DistributionType.Triangular:
                    distributions= new Triangular().GetDistribution(distributionInput.Delegate,
                                                        distributionInput.Iteration, distributionInput.UncertaintyArray);
                    break;
                case DistributionType.Normal:
                    break;
                case DistributionType.Log_Normal:
                    break;
            }
            return distributions;
        }
        private DistributionInput _distributionInput;
        private StatisticalInput _statisticalInput;
        private DistributionType _distributionType;
    }
}
