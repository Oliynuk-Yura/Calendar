using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Data.Domain
{
    public class Identifiable
    {
        public Guid Id { get; set; }

        public Identifiable()
        {
            Id = new Guid();
        }
    }
}
