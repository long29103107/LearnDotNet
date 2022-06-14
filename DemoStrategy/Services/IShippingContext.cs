namespace DemoStrategy.Services
{
    public interface IShippingContext
    {
        void SetStrategy(IShippingStrategy strategy);

        decimal ExecuteStrategy(decimal orderTotal);
    }
}
