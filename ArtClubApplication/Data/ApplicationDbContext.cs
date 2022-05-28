using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ArtClubApp.Models;
using ArtClubApplication.Models;
using Microsoft.AspNetCore.Identity;

namespace ArtClubApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ArtClubApp.Models.Payment>? Payment { get; set; }
        public DbSet<ArtClubApp.Models.ArtEvent>? ArtEvent { get; set; }
        public DbSet<ArtClubApplication.Models.ArtResource>? ArtResource { get; set; }
        public DbSet<ArtClubApp.Models.Review>? Review { get; set; }
        public DbSet<ArtClubApp.Models.ArtPiece>? ArtPiece { get; set; }
        public DbSet<ArtClubApp.Models.Category>? Category { get; set; }
        public DbSet<ArtClubApplication.Models.Report>? Report { get; set; }
        public DbSet<ArtClubApp.Models.Rezervation>? Rezervation { get; set; }
        public DbSet<ArtClubApp.Models.User>? User { get; set; }
    }
}