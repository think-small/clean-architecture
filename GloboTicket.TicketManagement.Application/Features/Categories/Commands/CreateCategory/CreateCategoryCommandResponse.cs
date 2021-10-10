using System;
using System.Collections.Generic;
using GloboTicket.TicketManagement.Application.Responses;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CategoryDto Category { get; set; }
        
        public CreateCategoryCommandResponse() : base()
        {
            
        }
    }
}