using DemoMediatR.Models;
using MediatR;

namespace DemoMediatR.Commands
{
    public class AddProductCommand : IRequest<Product>
    {
        public Product Product;
    }
}
