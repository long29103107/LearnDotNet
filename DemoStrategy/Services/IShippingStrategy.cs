namespace DemoStrategy.Services
{
    public interface IShippingStrategy
    {
        decimal CalculateFinalTotal(decimal orderTotal);
    }
}
