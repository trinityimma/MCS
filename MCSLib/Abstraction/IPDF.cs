using MCSLib.PDFs;
using System;
using System.Collections.Generic;

namespace MCSLib.Abstraction
{
    public interface IPDF
    {
        IList<double> GetDistribution(int iteration, params double[] uncertainties);
        IList<double> GetDistribution(int iteration, IList<double> uncertainties);
        double[] GetDistribution(Params args);
        T GetDistribution<T>(Func<T> action, int iteration, params double[] uncertainties);
        T GetDistribution<T>(Func<T> action, int iteration, IList<double> uncertainties);
        T GetDistribution<T>(Func<T> action, Params args);
    }
}
