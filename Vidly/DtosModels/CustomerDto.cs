using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.DtosModels
{
    public class CustomerDto
    {
        public int Id { get; set; }
  
        public string Name { get; set; }

        public bool IsSubscribedToNewletter { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}