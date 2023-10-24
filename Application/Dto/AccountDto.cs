using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class AccountDto
    {
        public Guid Id { get;  set; }
        public Guid UserId { get;  set; }
        public string Name { get;  set; }
        public decimal Balance { get;  set; }

    }
}
