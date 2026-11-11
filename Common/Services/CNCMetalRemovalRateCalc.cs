namespace Common.Services;

public class CNCMetalRemovalRateCalc
{
    private float feedRate;
    private float widthOfCut;
    private float depthOfCut;

    public float FeedRate
    {
        get => feedRate;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value, nameof(FeedRate));
            feedRate = value;
            CalculateRemovalRate();
        }
    }

    public float WidthOfCut
    {
        get => widthOfCut;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value, nameof(WidthOfCut));
            widthOfCut = value;
            CalculateRemovalRate();
        }
    }

    public float DepthOfCut
    {
        get => depthOfCut;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value, nameof(DepthOfCut));
            depthOfCut = value;
            CalculateRemovalRate();
        }
    }

    public float RemovalRate { get; private set; }

    private void CalculateRemovalRate()
    {
        RemovalRate = feedRate * widthOfCut * depthOfCut;
    }
}
