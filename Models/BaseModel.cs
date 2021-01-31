using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Skeleton.Models
{
    public class BaseModel
    {
        public bool Successful { get; set; } = true;
        public int Status { get; set; }
        public string ErrorDescription { get; set; }
        public string ReferenceNumber { get; set; }
    }
}
