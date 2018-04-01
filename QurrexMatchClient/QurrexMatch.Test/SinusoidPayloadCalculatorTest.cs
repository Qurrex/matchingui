using System.Threading;
using NUnit.Framework;
using QurrexMatch.LoadApp.Model;

namespace QurrexMatch.Test
{
    [TestFixture]
    public class SinusoidPayloadCalculatorTest
    {
        [Test]
        public void TestPeriod()
        {
            var sets = new TradersSettings
            {
                PayloadSets = new TradersSettings.PayloadSettings
                {
                    SinusoidPeriodMs = 5000,
                    SleepInterval = 20
                }
            };
            var calc = new SinusoidPayloadCalculator(sets);
            var a = calc.GetNextInterval();
            Thread.Sleep(200);
            var b = calc.GetNextInterval();
            Assert.AreNotEqual(a, b);
        }
    }
}
