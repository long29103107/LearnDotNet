using DemoMediatR.Models;
using MediatR;

namespace DemoMediatR.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
