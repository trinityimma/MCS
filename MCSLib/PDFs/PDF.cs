using MCSLib.Abstraction;
using MCSLib.PDFs;
using System;
using System.Collections.Generic;

namespace MCSLib
{
    public abstract class PDF : IPDF
    {
        public abstract IList<double> GetDistribution(int iteration, params double[] uncertainties);

        public abstract IList<double> GetDistribution(int iteration, IList<double> uncertainties);

        public abstract double[] GetDistribution(Params args);

        public abstract T GetDistribution<T>(Func<T> action, int iteration, params double[] uncertainties);

        public abstract T GetDistribution<T>(Func<T> action, int iteration, IList<double> uncertainties);

        public abstract T GetDistribution<T>(Func<T> action, Params args);
    }
}
