
namespace EventBusRabbitMQ.Event.Basket
{
    public class BasketCartEvent
    {
        public string UserName { get; set; }
        public List<CartItem> Items { get; set;} = new List<CartItem>();

        public BasketCartEvent(string userName)
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

        public int TotalItem
        {
            get
            {
                int totalItem = Items.Count();
                return totalItem;
            }
        }
    }
}
