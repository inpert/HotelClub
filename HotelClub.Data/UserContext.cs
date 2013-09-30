using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using HotelClub.Core;

namespace HotelClub.Data
{
    public class UsersContext : BaseContext<UsersContext>
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
