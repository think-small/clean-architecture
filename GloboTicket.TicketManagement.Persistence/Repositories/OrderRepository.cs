using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence.Repositories 
{
    public class OrderRepository : BaseRepository<OrderRepository>, IOrderRepository
    {
        public OrderRepository(GloboTicketDbContext context) : base(context) {}

        public async Task<List<Order>> GetPagedOrdersForMonth(DateTime date, int page, int size)
        {
            return await _dbContext.Orders
                    .Where(x => x.OrderPlaced.Month == date.Month && x.OrderPlaced.Year == date.Year)
                    .Skip((page - 1) * size)
                    .Take(size)
                    .AsNoTracking()
                    .ToListAsnc();
        }

        public async Task<int> GetTotalCountOfOrdersForMonth(DateTime date)
        {
            return await _dbContext.Orders.CountAsync(x => x.OrderPlaced.Month == date.Month && x.OrderPlaced.Year == date.Year);
        }
    }
}