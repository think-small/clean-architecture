using System;
using System.Threading;
using System.Threading.Tasks;
using GloboTicket.TicketManagement.Domain.Common;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Persistence
{
    public class GloboTicketDbContext : DbContext
    {
        public GloboTicketDbContext(DbContextOptions<GloboTicketDbContext> options) : base(options)
        {
            
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GloboTicketDbContext).Assembly);

            var concertGuid = Guid.Parse("{B83KS92J-38DJ-AL29-FJD1-3IDKSL2K}");
            var musicalGuid = Guid.Parse("{5IDK29KA-2J3J-SL1L-FJK3-ZXLEJ29S}");
            var playGuid = Guid.Parse("{FJEKSOLS-38SA-ZMK3-FJ38-SK3JFJX1}");
            var conferenceGuid = Guid.Parse("{PQ2M2J9S-K1OZ-N3J1-BVJ2-FJ31LA02}");

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = concertGuid,
                Name = "Concerts"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = musicalGuid,
                Name = "Musicals"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = playGuid,
                Name = "Plays"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = conferenceGuid,
                Name = "Conferences"
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("{AWEK2OK1-34S2-FDK1-FK3L-SKXSL3K1}"),
                Name = "GC and the Chlams",
                Price = 70,
                Artist = "Lauren Marie",
                Date = DateTime.Now.AddMonths(6),
                Description = "Don't miss out on this farewell tour by GC and the Chlams. They cause quite the uproar wherever they go, so be sure to catch them before they leave for good!",
                ImageUrl = "https://images.unsplash.com/photo-1540039155733-5bb30b53aa14?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1074&q=80",
                CategoryId = concertGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("{ZMEI29SL-P10X-CKS1-4ICN-19SK38VB}"),
                Name = "The State of Affairs: JBo Live!",
                Price = 93,
                Artist = "Jimmy Bonehead",
                Date = DateTime.Now.AddMonths(9),
                Description = "He needs no introduction - JBo will be coming at you to bring you the latest on all things relevant. If that sounds like a lot, well it's because it is. Buckle in for a wild ride!",
                ImageUrl = "https://images.unsplash.com/photo-1562957177-3275fd7cbd68?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1170&q=80",
                CategoryId = musicalGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("{I28CX9Z0-18MN-3JU1-XBCC-FJQ92KCV}"),
                Name = "Clash of the Medical Doctors",
                Price = 95,
                Artist = "Docs United",
                Date = DateTime.Now.AddMonths(10),
                Description = "A battle royale for the ages - this showdown pits the best of MDs against the finest DOs. Join us for an incredible evening of medical knowledge duels among the professions brightest minds.",
                ImageUrl = "",
                CategoryId = conferenceGuid
            });

            modelBuilder.Entity<Order>().HasData(new Order {
                Id = Guid.Parse("{38DK2LS0-DK3I-SK3O-SJFX-ZLSK38D9}"),
                OrderTotal = 150,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("{VK2X85UE-FJ10-983J-N32L-POC84N2K}"),                
            });

            modelBuilder.Entity<Order>().HasData(new Order {
                Id = Guid.Parse("{VN289DKJ-QO28-D921-FN38-MN2847XJ}"),
                OrderTotal = 89,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("{189SK427-ZW27-9821-B6U2-SK1038MQ}")                
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModificationDate = DateTime.Now;
                        break;                        
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}