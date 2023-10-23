using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.ReadModel
{
    internal class TransferReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid AccountId2 { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public UserReadModel User { get; set; }
        public Guid UserId { get; set; }
    }
}
