using CRM_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_App.Library.Services
{
    public class ContactService(AppDbContext dbContext) : BaseService<ContactModel>(dbContext)
    {

        public override async Task<bool> DeleteAsync(ContactModel t)
        {
            DbContext.Contacts.Remove(t);
            return (await DbContext.SaveChangesAsync()) > 0;
        }

        public override async Task<List<ContactModel>> GetAllAsync()
        {
            return await DbContext.Contacts.ToListAsync();
        }

        public override async Task<ContactModel?> GetSingleAsync(int id)
        {
            return await DbContext.Contacts.FindAsync(id);
        }

        public override async Task<ContactModel?> CreateAsync(ContactModel t)
        {
            DbContext.Contacts.Add(t);

            return await DbContext.SaveChangesAsync() > 0 ? t : null;
        }

        public override async Task<bool> UpdateAsync(ContactModel t)
        {
            DbContext.Contacts.Update(t);

            return (await DbContext.SaveChangesAsync()) > 0;
        }
    }
}
