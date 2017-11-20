namespace Steampowered.Entities
{
    public class GameInfo
    {
        private readonly string _discount;
        private readonly string _originalPrice;
        private readonly string _discountPrice;

        public string GetDiscount
        {
            get
            {
                return _discount;
            }
        }

        public string GetOriginalPrice
        {
            get
            {
                return _originalPrice;
            }
        }

        public string GetDiscountPrice
        {
            get
            {
                return _discountPrice;
            }
        }

        public GameInfo(string discount, string originalPrice, string discountPrice)
        {
            _discount = discount;
            _originalPrice = originalPrice;
            _discountPrice = discountPrice;
        }

        public static bool Equals(GameInfo expected, GameInfo actual)
        {
            return expected.GetDiscount == actual.GetDiscount && expected.GetDiscountPrice == actual.GetDiscountPrice
                   && expected.GetOriginalPrice == actual.GetOriginalPrice;
        }
    }
}
