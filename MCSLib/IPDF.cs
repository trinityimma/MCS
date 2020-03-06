using System.Collections.Generic;

namespace MCSLib
{
    public interface IPDF
    {
        IList<double> SingleDistribution(int interval, int iteration, params double[] args);
        IList<double> UniformDistribution(int interval, int iteration, params double[] args);
        IList<double> TriangularDistribution(int interval, int iteration, params double[] args);
    }
}
