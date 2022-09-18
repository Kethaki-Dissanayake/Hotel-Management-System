using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PropertyInfoModel
    {
        [Key]
        public int PropertyId { get; set; }

        public string Name { get; set; }
    }
}
