using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplyService.Model
{
    public class ProductResponse
    {
        
        public string URI { get; set; }

        public ObjectId Id { get; set; }
      
        public string Description { get; set; }
    
        public double Availability { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}
