using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class CNCFeedRateCalc
    {
        public CNCFeedRateCalc() : this(0.0f, 2, 0.1f, "mm")
        {
        }

        public CNCFeedRateCalc(float rpm, int numFlutes, float chipLoad, string units)
        {
            this.rpm = rpm;
            this.numFlutes = numFlutes;
            this.chipLoad = chipLoad;
            this.Units = units;
            CalcFeeRate();
        }

        private float rpm = 0.0f;

        [Required]
        public float RPM
        {
            get { return rpm; }
            set
            {
                rpm = value;
                CalcFeeRate();
            }
        }

        private int numFlutes;

        [Required, Range(1, 30)]
        public int NumFlutes
        {
            get { return numFlutes; }
            set
            {
                numFlutes = value;
                CalcFeeRate();
            }
        }

        private float chipLoad;

        [Required, Range(0.00001, float.MaxValue)]
        public float ChipLoad
        {
            get { return chipLoad; }
            set
            {
                chipLoad = value;
                CalcFeeRate();
            }
        }

        [Required, AllowedValues("mm", "in", "feet", "meters")]
        public string Units { get; set; } = "mm";

        public float FeedRate { get; private set; }

        private void CalcFeeRate()
        {
            FeedRate = rpm * numFlutes * chipLoad;
        }
    }
}