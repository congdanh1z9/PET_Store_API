using Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUnitOfWork
    {
        public Task<int> SaveChangeAsync();
        public IAccountRepository AccountRepository { get; }
        public IBusinessPlanRepository BusinessPlanRepository { get; }
        IImageRepository ImageRepository { get; }
        ITypeRepository TypeRepository { get; }
        public INotificationRepository NotificationRepository { get; }
        public IPostRepository PostRepository { get; }
    }
}
