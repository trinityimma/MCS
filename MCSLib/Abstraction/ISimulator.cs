using MCSLib.Simulation;

namespace MCSLib.Abstraction
{
    public interface ISimulator
    {
        SimulationResult SimulationResult { get; set; }
        SimulationResult Run();
        SimulationResult Run(IPDF pDF);
    }
}
