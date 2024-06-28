using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheshmAsali.Domain.Models
{
    public class Customer :BaseEntity
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set;}

        public required string CellPhone { get; set;}



        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
