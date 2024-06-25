using CRM_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_App.Library.Services
{
    public abstract class BaseService<T>(AppDbContext dbContext) where T : BaseModel
    {
        public AppDbContext DbContext { get; } = dbContext;

        public abstract Task<List<T>> GetAllAsync();
        public abstract Task<T?> CreateAsync(T t); // C
        public abstract Task<T?> GetSingleAsync(int id); // R
        public abstract Task<bool> UpdateAsync(T t); // U
        public abstract Task<bool> DeleteAsync(T t); // D
    }
}
