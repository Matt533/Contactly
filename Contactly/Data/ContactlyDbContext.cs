using Contactly.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Contactly.Data
{
    public class ContactlyDbContext : DbContext 
    {
        public ContactlyDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Contact> contacts { get; set; }


    }
}
