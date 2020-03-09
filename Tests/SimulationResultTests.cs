using MCSLib.Simulation;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace Tests
{
    [TestFixture]
    public class SimulationResultTests
    {
        [SetUp]
        public void SetUpMockObjects()
        {
            _mockSimResult = new SimulationResult();
        }
        

        [Test]
        public void TestSimulationResultObjectIsNotNull()
        {
            IsNotNull(_mockSimResult);
        }
        [Test]
        public void TestRelativeFrequenciesIsNotNull()
        {
           // IsNotNull(_mockSimResult.RelativeFrequencies);
        }
        [Test]
        public void TestCumulativeFrequenciesIsNotNull()
        {
            //IsNotNull(_mockSimResult.CumulativeFrequencies);
        }
        [Test]
        public void TestExpectationsIsNotNull()
        {
           // IsNotNull(_mockSimResult.Expectations);
        }
        [Test]
        public void TestSimulatedValuesIsNotNull()
        {
            //IsNotNull(_mockSimResult.SimulatedValues);
        }
        [Test]
        public void TestBinSizesIsNotNull()
        {
           // IsNotNull(_mockSimResult.BinSizes);
        }
        [Test]
        public void TestFrequenciesIsNotNull()
        {
           // IsNotNull(_mockSimResult.Frequencies);
        }
        private SimulationResult _mockSimResult;
    }
}
