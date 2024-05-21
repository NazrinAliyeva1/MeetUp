using MeetUp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.DataAccesLayer;

public class MeetUpContext : DbContext
{
    public MeetUpContext(DbContextOptions options):base(options)
    {
        
    }
    public DbSet<Speaker> Speakers { get; set; }
}
