using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSLib.Simulation
{
    public class SimulationResult
    {
        public IList<double> RelativeFrequencies { get; set; }
        public IList<double> CumulativeFrequencies { get; set; }
        public IList<double> Expectations { get; set; }
        public IList<double> Frequencies { get; set; }
        public IList<double> BinSizes { get; set; }
        public IList<double> SimulatedValues { get; set; }
    }
}
