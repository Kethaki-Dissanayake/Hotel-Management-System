using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class Features_RoomTypes
    {
        public int Id { get; set; }



        public int FeatureId { get; set; }
        public Features Features { get; set; }



        public int RoomTypeId { get; set; }
        public RoomTypes RoomTypes { get; set; }

    }
}
