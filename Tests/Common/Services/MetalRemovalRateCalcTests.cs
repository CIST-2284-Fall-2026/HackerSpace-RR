using Common.Services;

namespace Tests.Common.Services;

[TestClass]
public sealed class MetalRemovalRateCalcTests
{
    [TestMethod]
    public void Ipm10Woc2Doc3ShouldReturn60()
    {
        var calculator = new CNCMetalRemovalRateCalc
        {
            FeedRate = 10,
            WidthOfCut = 2,
            DepthOfCut = 3
        };

        Assert.AreEqual(60f, calculator.RemovalRate);
    }

    [TestMethod]
    public void ShouldNotBeAbleToSetRemovalRateDirectly()
    {
        var property = typeof(CNCMetalRemovalRateCalc)
            .GetProperty(nameof(CNCMetalRemovalRateCalc.RemovalRate));
        Assert.IsNotNull(property);
        var setter = property.SetMethod;
        Assert.IsNotNull(setter);
        Assert.IsTrue(setter.IsPrivate);
    }

    [TestMethod]
    public void CanNotSetFeedRateToNegativeValue()
    {
        var calculator = new CNCMetalRemovalRateCalc { FeedRate = 10 };
        Assert.Throws<ArgumentOutOfRangeException>(() => calculator.FeedRate = -5);
        Assert.AreEqual(10f, calculator.FeedRate);
    }

    [TestMethod]
    public void CanNotSetWidthOfCutToNegativeValue()
    {
        var calculator = new CNCMetalRemovalRateCalc { WidthOfCut = 2 };
        Assert.Throws<ArgumentOutOfRangeException>(() => calculator.WidthOfCut = -5);
        Assert.AreEqual(2f, calculator.WidthOfCut);
    }

    [TestMethod]
    public void CanNotSetDepthOfCutToNegativeValue()
    {
        var calculator = new CNCMetalRemovalRateCalc { DepthOfCut = 3 };
        Assert.Throws<ArgumentOutOfRangeException>(() => calculator.DepthOfCut = -5);
        Assert.AreEqual(3f, calculator.DepthOfCut);
    }
}
