using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interface
{
    public interface IGenericRepository<T> where T: BaseModel
    {
        Task<IReadOnlyList<T>> GetAllAsyc();
       
        Task<T> GetByIdAsync(int id); 
    }
}