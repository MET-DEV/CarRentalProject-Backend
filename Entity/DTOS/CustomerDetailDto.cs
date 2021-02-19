using MyCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOS
{
    public class CustomerDetailDto:IDto
    {
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerMailAdress { get; set; }
        
    }
}
