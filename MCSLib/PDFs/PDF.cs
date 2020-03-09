using MCSLib.Abstraction;
using MCSLib.PDFs;
using System;
using System.Collections.Generic;

namespace MCSLib
{
    public abstract class PDF : IPDF
    {
        public abstract IEnumerable<double> GetDistribution(int iteration, params double[] uncertainties);

        public abstract IEnumerable<double> GetDistribution(int iteration, List<double> uncertainties);

        public abstract IEnumerable<double> GetDistribution(Params args);

        public abstract IEnumerable<double> GetDistribution(Func<double, double> action, int iteration, params double[] uncertainties);

        public abstract IEnumerable<double> GetDistribution(Func<double, double> action, int iteration, List<double> uncertainties);

        public abstract IEnumerable<double> GetDistribution(Func<double, double> action, Params args);
    }
}
