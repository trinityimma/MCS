using MCSLib.PDFs;
using System;
using System.Collections.Generic;

namespace MCSLib.Abstraction
{
    public interface IPDF
    {
        IEnumerable<double> GetDistribution(int iteration, params double[] uncertainties);
        IEnumerable<double> GetDistribution(int iteration, List<double> uncertainties);
        IEnumerable<double> GetDistribution(Params args);
        IEnumerable<double> GetDistribution(Func<double, double> action, int iteration, params double[] uncertainties);
        IEnumerable<double> GetDistribution(Func<double, double> action, int iteration, List<double> uncertainties);
        IEnumerable<double> GetDistribution(Func<double, double> action, Params args);
    }
}
