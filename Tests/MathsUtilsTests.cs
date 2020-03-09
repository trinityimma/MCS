using MCSLib;
using NUnit.Framework;
using System.Collections.Generic;
using static NUnit.Framework.Assert;

namespace Tests
{
    [TestFixture]
    public class MathsUtilsTests
    {
        [SetUp]
        public void SetUpMockObjects()
        {
            _mockBinSizes=new List<double>() { 1, 2, 3, 4, 5};
            _mockreletivefrequencies=new List<double>() { .1, .2, .3, .4, .5 };
            _mockfrequencies=new List<double> () { .1, .2, .3, .4, .5 }; 
            _mockcumfrequencies= new List<double>() { .1, .2, .3, .4, .5 }; 
            _mocksimulatedValues= new List<double>() { .1, .2, .3, .4, .5,.6,.7,.8,.9 }; 
        }
        [Test]
        public void TestGetFrequencyDoNotRetrurnNull()
        {
            var result = MathUtils.GetFrequency(10, 1, _mockBinSizes, _mocksimulatedValues);
            IsNotNull(result);
        }
        public void TestGetCumFrequencyDoNotRetrurnNull()
        {
            var result = MathUtils.GetCumFrequency(1, _mockreletivefrequencies);
            IsNotNull(result);
        }
        public void TestGetRelativeFrequencyDoNotRetrurnNull()
        {
            var result = MathUtils.GetRelFrequency(1, _mockfrequencies);
            IsNotNull(result);
        }
        public void TestGetExpectationDoNotRetrurnNull()
        {
            var result = MathUtils.GetExpectation(1, _mockreletivefrequencies, _mockcumfrequencies);
            IsNotNull(result);
        }
        public void TestGetBinSizeDoNotRetrurnNull()
        {
            var result = MathUtils.GetBinSize(4,2,1);
            IsNotNull(result);
        }

        IList<double> _mockBinSizes;
        IList<double> _mockreletivefrequencies;
        IList<double> _mockfrequencies;
        IList<double> _mockcumfrequencies;
        IList<double> _mocksimulatedValues;
    }
}
