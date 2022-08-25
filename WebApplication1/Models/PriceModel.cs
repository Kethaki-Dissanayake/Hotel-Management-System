using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PriceModel
    {

        [Key]

        public int PriceId { get; set; }
        public string Code { get; set; }
        public string CurrentPrice { get; set; }
        
    }
}
