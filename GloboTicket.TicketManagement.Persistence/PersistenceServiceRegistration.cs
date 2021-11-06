using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GloboTicketDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("GloboTicketManagementConnectionString")));

            services.AddScoped<IAsyncRepository, BaseRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}