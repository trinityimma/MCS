using MCSLib.Abstraction;
using MCSLib.PDFs;
using System.Collections.Generic;
using System.Linq;
using System;

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
        public IList<StatisticalResult> Run()
        {
            SimulationResult = ToggleDistribution(_distributionInput, _distributionType);
            _statisticalInput.Interval = _distributionInput.Interval;
            _statisticalInput.Iteration = _distributionInput.Iteration;
            _statisticalInput.MinValue = SimulationResult.FittedValues.Min();
            _statisticalInput.MaxValue = SimulationResult.FittedValues.Max();
            return GetSimResult(_statisticalInput, SimulationResult.FittedValues);
        }
        /// <summary>
        /// Returns simulation results based on Monte Carlo method
        /// </summary>
        /// <param name="distributionInput">Represents user defined variables for 
        /// probability distribution and simulation results</param>
        /// <param name="distributionType">Represents selected probability distribution</param>
        public IList<StatisticalResult> Run(DistributionInput distributionInput,DistributionType distributionType)
        {
            SimulationResult = ToggleDistribution(distributionInput,distributionType);
            if (SimulationResult.FittedValues.Count > 0)
            {
                if (_statisticalInput == null)
                    _statisticalInput = new StatisticalInput();
                _statisticalInput.Interval = distributionInput.Interval;
                _statisticalInput.Iteration = distributionInput.Iteration;
                _statisticalInput.MinValue = SimulationResult.FittedValues.Min();
                _statisticalInput.MaxValue = SimulationResult.FittedValues.Max();
                return GetSimResult(_statisticalInput, SimulationResult.FittedValues);
            }
             throw new ArgumentException();
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

        private IList<StatisticalResult> GetSimResult(StatisticalInput statisticalInput, IList<double> distribution)
        {
            SimulationResults = new List<StatisticalResult>();
            var relFrequencies = MathUtils.GetRelFrequency(statisticalInput, distribution);
            var cumFrequencies = MathUtils.GetCumFrequency(statisticalInput, distribution);
            var expectations = MathUtils.GetExpectation(statisticalInput, distribution);
            var binSizes = MathUtils.GetBinSizes(statisticalInput.MaxValue, statisticalInput.MinValue, statisticalInput.Interval);
            for (int i = 0; i < _statisticalInput.Interval; i++)
            {
                SimulationResults.Add(new StatisticalResult()
                {
                    Expectation = expectations[i],
                    RelativeFrequency = relFrequencies[i],
                    CumulativeFrequency = cumFrequencies[i],
                    BinSize= binSizes[i]

                });
            }
            return SimulationResults;
        }
        private ISimulationResult ToggleDistribution(DistributionInput distributionInput, DistributionType distributionType)
        {
            ISimulationResult distributions =null;
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

        /// <summary>
        /// Returns simulation results based on Monte Carlo method
        /// </summary>
        public IList<StatisticalResult> SimulationResults { get; set; }
        /// <summary>
        /// Represents actual and fitted simulation results based on Monte Carlo method
        /// </summary>
        public ISimulationResult SimulationResult { get; set; }

        private DistributionInput _distributionInput;
        private StatisticalInput _statisticalInput;
        private DistributionType _distributionType;
    }
}
