using DemoMediatR.Models;
using MediatR;

namespace DemoMediatR.Notifications
{
    public class ProductAddedNotification : INotification
    {
        public Product Product;
    }
}
