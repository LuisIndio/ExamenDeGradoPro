using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.ReadModel
{
    internal class AccountReadModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Balance { get; set; }
        public UserReadModel User { get; set; }
        public Guid UserId { get; set; }
    }
}
