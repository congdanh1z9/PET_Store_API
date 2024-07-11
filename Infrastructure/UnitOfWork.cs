using Application;
using Application.Repositories;
using Infrastructures.Repositories;

namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly IAccountRepository _accountRepository;
        private readonly IBusinessPlanRepository _businessPlanRepository;
        private readonly IImageRepository _imageRepository;
        private readonly ITypeRepository _typeRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IPostRepository _postRepository;

        public UnitOfWork(AppDbContext dbContext, IAccountRepository accountRepository, IBusinessPlanRepository businessPlanRepository, IImageRepository imageRepository, ITypeRepository typeRepository, INotificationRepository notificationRepository, IPostRepository postRepository)
        {
            _dbContext = dbContext;
            _accountRepository = accountRepository;
            _businessPlanRepository = businessPlanRepository;
            _imageRepository = imageRepository;
            _typeRepository = typeRepository;
            _notificationRepository = notificationRepository;
            _postRepository = postRepository;
        }

        public IAccountRepository AccountRepository => _accountRepository;
        public IBusinessPlanRepository BusinessPlanRepository => _businessPlanRepository;
        public IImageRepository ImageRepository => _imageRepository;
        public ITypeRepository TypeRepository => _typeRepository;
        public INotificationRepository NotificationRepository => _notificationRepository;
        public IPostRepository PostRepository => _postRepository;

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}