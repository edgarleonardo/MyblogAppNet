using System;

namespace BlogApplication.Domain.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAssetRepository Assets { get; }
        IProfileRepository Profiles { get; }
        ICategoryRepository Categories { get; }
        IPostRepository BlogPosts { get; }
        ICustomRepository CustomFields { get; }

        int Complete();
    }
}
