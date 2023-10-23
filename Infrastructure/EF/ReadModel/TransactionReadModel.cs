using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.ReadModel
{
    internal class TransactionReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Type { get; set; }
        public CategoryReadModel Category { get; set; }
        public Guid CategoryId { get; set; }
        public AccountReadModel Account { get; set; }
        public Guid AccountId { get; set; }
        public UserReadModel User { get; set; }
        public Guid UserId { get; set;}
    }
}
