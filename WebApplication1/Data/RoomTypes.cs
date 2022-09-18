using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class RoomTypes
    {
        [Key]
        public int RoomTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Navigation Propaties

        public List<Features_RoomTypes> Features_RoomTypes { get; set; }

        public  Rooms Rooms { get; set; }

        public List<Prices> Prices { get; set; }
    }
}
