namespace DecimalExtensions
{
    public static class DecimalExtensions
    {
        public static decimal GetIncreasePercentage(this decimal originalValue, decimal newValue)
        {
            if (originalValue == 0 && newValue != 0) return (-1) * newValue;
            if (newValue == 0 && originalValue != 0) return 0;
            if (originalValue == 0 && newValue == 0) return 0;

            var increase = newValue - originalValue;
            var increasePercentage = increase / originalValue * 100m;
            return decimal.Round(increasePercentage, 2);

        }
    }

}