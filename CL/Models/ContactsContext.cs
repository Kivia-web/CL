using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CL.Models
{
    public class ContactsContext: DbContext
    {
        public DbSet<ContactsPeople> ContactsPeople { get; set; }

        public ContactsContext(DbContextOptions<ContactsContext> options): base(options)
        {
            Database.EnsureCreated();
        }
        //Создание базы данных
    }
}
