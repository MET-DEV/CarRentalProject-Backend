using MyCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOS
{
    public class RentalDetailDto:IDto
    {
        
        public string CarName { get; set; }
        public string CustomerName { get; set; }
        public int CarId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
