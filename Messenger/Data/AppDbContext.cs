using Messenger.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Data
{
    public class AppDbContext:DbContext 

    {
        public AppDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<FriendList> FriendList { get; set; }
        public DbSet<Message> Messages { get; set; }




    }
}
