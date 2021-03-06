using DemoMediatR.Commands;
using DemoMediatR.Models;
using MediatR;

namespace DemoMediatR.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly FakeDataStore _fakeDataStore;
        public AddProductHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public async Task<Product> Handle(AddProductCommand context, CancellationToken cancellationToken)
        {
            await _fakeDataStore.AddProduct(context.Product);

            return context.Product;
        }
    }
}
