using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PocketBook.Api.Core.IRepositories;

namespace PocketBook.Api.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Task CompleteAsync();
    }
}