using MCSLib.Abstraction;
using System.Collections.Generic;

namespace MCSLib.Simulation
{
    public class Simulator: ISimulator
    {
        public SimulationResult SimulationResult { get; set; }
       

        public SimulationResult Run()
        {
            throw new System.NotImplementedException();
        }

        public SimulationResult Run(IPDF pDF)
        {
            throw new System.NotImplementedException();
        }

        public Simulator(IPDF pDF)
        {
            _pDF = pDF;
            SimulationResult = new SimulationResult();
        }
        private IPDF _pDF;
    }
}
