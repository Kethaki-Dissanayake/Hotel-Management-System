using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ReservationModel
    {
        [Key]
        public int ReservationId { get; set; }

        public string CheckIn { get; set; }

        public string CheckOut { get; set; }

        public int TotalDays { get; set; }
    }
}
