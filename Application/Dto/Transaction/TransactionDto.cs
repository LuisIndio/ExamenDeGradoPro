using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Transaction
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Type { get; set; }
        public Guid CategoryId { get; set; }
        public Guid AccountId { get; set; }
        public Guid UserId { get; set; }

    }
}
