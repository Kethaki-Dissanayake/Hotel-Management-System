using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class Rooms
    {
        [Key]
        public int RoomId { get; set; }

        public string Name { get; set; }

        //Navigations

        public PropertyInfos PropertyInfos { get; set; }

        public List<Reservations> Reservations { get; set; }

        public List<RoomTypes> RoomTypes { get; set; }
    }
}
