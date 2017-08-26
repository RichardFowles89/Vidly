using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyTakeTwo.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }//All entities in EF need an ID property to act as a primary key in the db
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}