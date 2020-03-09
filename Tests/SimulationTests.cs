using MCSLib.Abstraction;
using MCSLib.PDFs;
using MCSLib.Simulation;
using NUnit.Framework;
using System;
using static NUnit.Framework.Assert;

namespace Tests
{
    [TestFixture]
    public class SimulationTests
    {
        [SetUp]
        public void SetUpMockObjects()
        {
           // mockSimulator = new Simulator();
        }

        [Test]
        public void TestSimulatorPopulatesResults()
        {
            var result = _mockSimulator.Run();
            Greater(result.BinSizes.Count,0);
            Greater(result.Frequencies.Count,0);
            Greater(result.Expectations.Count,0);
            Greater(result.CumulativeFrequencies.Count,0);
            Greater(result.SimulatedValues.Count,0);
            Greater(result.RelativeFrequencies.Count,0);
           
        }
        [Test]
        public void TestSimulatorPopulatesResultsWhyRunMethodWithParameterIsInvoke()
        {
            var result = _mockSimulator.Run(new Triangular());
            GreaterOrEqual(result.BinSizes.Count, 1);
            GreaterOrEqual(result.Frequencies.Count, 1);
            GreaterOrEqual(result.Expectations.Count, 1);
            GreaterOrEqual(result.CumulativeFrequencies.Count, 1);
            GreaterOrEqual(result.SimulatedValues.Count, 1);
            GreaterOrEqual(result.RelativeFrequencies.Count, 1);

        }

        [Test]
        public void TestBadConstructor()
        {
            bool isBadContructor;
            try
            {
                _mockSimulator  = new Simulator(new Uniform()); ;
                isBadContructor = false;
            }
            catch (Exception)
            {
                isBadContructor = true;
            }
            IsFalse(isBadContructor);
        }
        [Test]
        public void TestSimulationResultIsNotNull()
        {
            IsNotNull(_mockSimulator.SimulationResult);
        }
        private ISimulator _mockSimulator;
    }
}
