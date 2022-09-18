using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class PropertyInfos
    {
        [Key]
        public int PropertyId { get; set; }

        public string Name { get; set; }

        //Navigations

        public List<Rooms> Rooms { get; set; }
        public List<Reservations> Reservations { get; set; }
    }
}
