using System;
using System.Collections.Generic;

namespace MCSLib.PDFs
{
    public class Uniform : PDF
    {
        public override IList<double> GetDistribution(int iteration, params double[] uncertainties)
        {
            throw new NotImplementedException();
        }

        public override IList<double> GetDistribution(int iteration, IList<double> uncertainties)
        {
            throw new NotImplementedException();
        }

        public override double[] GetDistribution(Params args)
        {
            throw new NotImplementedException();
        }

        public override T GetDistribution<T>(Func<T> action, int iteration, params double[] args)
        {
            throw new NotImplementedException();
        }

        public override T GetDistribution<T>(Func<T> action, int iteration, IList<double> args)
        {
            throw new NotImplementedException();
        }

        public override T GetDistribution<T>(Func<T> action, Params args)
        {
            throw new NotImplementedException();
        }
    }
}
