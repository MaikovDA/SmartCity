using System;
using Repository.DAL;

namespace Repository.Services
{
    public abstract class BaseService : IDisposable
    {
        protected readonly DataContext DbContext = new DataContext();

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
