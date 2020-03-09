using MCSLib.Simulation;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class SimulationTests
    {
        [SetUp]
        public void SetUpMockObjects()
        {
            mockSimResult = new SimulationResult();
            mockSimulator = new Simulator();
        }
    }
}
