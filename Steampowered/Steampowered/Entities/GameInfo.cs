namespace Steampowered.Entities
{
    public class GameInfo
    {
        private readonly string _nameGame;
        private readonly string _discount;
        private readonly string _originalPrice;
        private readonly string _discountPrice;

        public string GetNameGame
        {
            get
            {
                return _nameGame;
            }
        }

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

        public GameInfo(string nameGame, string discount, string originalPrice, string discountPrice)
        {
            _nameGame = nameGame;
            _discount = discount;
            _originalPrice = originalPrice;
            _discountPrice = discountPrice;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            var gameInfo = obj as GameInfo;
            return gameInfo != null && Equals(gameInfo);
        }

        protected bool Equals(GameInfo gameInfo)
        {
            return GetNameGame.Equals(gameInfo.GetNameGame)
                   && GetDiscount.Equals(gameInfo.GetDiscount)
                   && GetDiscountPrice.Equals(gameInfo.GetDiscountPrice)
                   && GetOriginalPrice.Equals(gameInfo.GetOriginalPrice);
        }

        public override string ToString()
        {
            return GetNameGame + ", " + GetDiscount + ", " + GetDiscountPrice + ", " + GetOriginalPrice;
        }
    }
}
