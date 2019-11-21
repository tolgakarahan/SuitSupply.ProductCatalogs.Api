using Application.Common.Interfaces;
using Application.Notifications.Models;
using System;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}
