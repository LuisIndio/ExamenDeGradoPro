using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class AccountDto
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Balance { get; private set; }

    }
}
