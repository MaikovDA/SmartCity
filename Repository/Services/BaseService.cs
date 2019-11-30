using System;
using Repository.DAL;

namespace Repository.Services
{
    public abstract class BaseService : IDisposable
    {
        protected readonly DataContext UsContext = new DataContext();

        public void Dispose()
        {
            UsContext.Dispose();
        }
    }
}
