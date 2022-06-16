using DemoMediatR.Models;
using MediatR;

namespace DemoMediatR.Queries
{
    public class GetProductByIdQuery: IRequest<Product>
    {
        public int Id;
    }
}
