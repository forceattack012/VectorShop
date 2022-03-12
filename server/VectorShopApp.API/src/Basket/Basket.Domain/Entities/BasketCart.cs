
namespace Basket.Domain.Entities
{
    public class BasketCart
    {
        public string UserName { get; set; }
        public List<CartItem> Items { get; set;} = new List<CartItem>();

        public BasketCart(string userName)
        {
            UserName = userName;
        }

        public decimal Total
        {
            get
            {
                decimal totalPrice = 0;
                if(Items.Count > 0)
                {
                    totalPrice = Items.Sum(item => item.Price * item.Quitity);
                }
                return totalPrice;
            }
        }
    }
}
