using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.RegularExpressions;

namespace SiteZnakomstv.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Interest> Interests { get; set; } = null!;
        public DbSet<Chatik> Chats { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;

    }

}
