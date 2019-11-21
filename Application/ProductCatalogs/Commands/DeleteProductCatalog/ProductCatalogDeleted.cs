using Application.Common.Interfaces;
using Application.Notifications.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ProductCatalogs.Commands.DeleteProductCatalog
{
    public class ProductCatalogDeleted : INotification
    {
        public int ProductCatalogId { get; set; }

        public class ProductCatalogDeletedHandler : INotificationHandler<ProductCatalogDeleted>
        {
            private readonly INotificationService _notification;

            public ProductCatalogDeletedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(ProductCatalogDeleted notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new MessageDto());
            }
        }
    }
}
