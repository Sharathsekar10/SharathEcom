using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interface;
using Core.Models;

namespace Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        public Task<IReadOnlyList<T>> GetAllAsyc()
        {
            throw new System.NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}