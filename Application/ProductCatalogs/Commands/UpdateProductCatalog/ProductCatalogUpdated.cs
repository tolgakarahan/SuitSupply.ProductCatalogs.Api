using Application.Common.Interfaces;
using Application.Notifications.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ProductCatalogs.Commands.UpdateProductCatalog
{
    public class ProductCatalogUpdated : INotification
    {
        public int ProductCatalogId { get; set; }


        public class ProductCatalogCreatedHandler : INotificationHandler<ProductCatalogUpdated>
        {
            private readonly INotificationService _notification;

            public ProductCatalogCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(ProductCatalogUpdated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new MessageDto());
            }
        }

    }
}
