using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class Features
    {
        [Key]
        public int FeatureId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
