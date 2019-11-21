using Application.Common.Interfaces;
using Application.Notifications.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ProductCatalogs.Commands.CreateProductCatalog
{
    public class ProductCatalogCreated : INotification
    {
        public int ProductCategoryId { get; set; }


        public class ProductCatalogCreatedHandler : INotificationHandler<ProductCatalogCreated>
        {
            private readonly INotificationService _notification;

            public ProductCatalogCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(ProductCatalogCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new MessageDto());
            }
        }

    }
}
