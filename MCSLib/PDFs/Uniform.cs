using System;
using System.Collections.Generic;

namespace MCSLib.PDFs
{
    public class Uniform : PDF
    {
        public override IEnumerable<double> GetDistribution(int iteration, params double[] uncertainties)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<double> GetDistribution(int iteration, IEnumerable<double> uncertainties)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<double> GetDistribution(Params args)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<double> GetDistribution(Func<double, double> action, int iteration, params double[] args)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<double> GetDistribution(Func<double, double> action, int iteration, IEnumerable<double> args)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<double> GetDistribution(Func<double, double> action, Params args)
        {
            throw new NotImplementedException();
        }
    }
}
