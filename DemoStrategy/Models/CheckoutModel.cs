namespace DemoStrategy.Models
{
    public class CheckoutModel
    {
        public int SelectedMethod { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal FinalTotal { get; set; }

        public List<ShippingMethod> ShippingMethods { get; set; }
    }
}
