using CRM_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_App.Library.Services
{
    public class ComapnyService(AppDbContext dbContext) : BaseService<CompanyModel>(dbContext)
    {
        public override async Task<CompanyModel?> CreateAsync(CompanyModel t)
        {
            DbContext.Companies.Add(t);

            return await DbContext.SaveChangesAsync() > 0 ? t : null;
        }

        public override async Task<bool> DeleteAsync(CompanyModel t)
        {
           DbContext.Companies.Remove(t);

           return (await DbContext.SaveChangesAsync()) > 0;
        }

        public override async Task<List<CompanyModel>> GetAllAsync()
        {
            return await DbContext.Companies.ToListAsync();
        }

        public override async Task<CompanyModel?> GetSingleAsync(int id)
        {
            return await DbContext.Companies.FindAsync(id);
        }

        public override async Task<bool> UpdateAsync(CompanyModel t)
        {
            DbContext.Companies.Update(t);

            return (await DbContext.SaveChangesAsync()) > 0;
        }
    }
}
