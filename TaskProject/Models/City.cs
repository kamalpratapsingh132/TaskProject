using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskProject.Models
{
    public class City
    {
        [Key]
        public int ID { get; set; }
        public int  Zipcode { get; set; }
        public string CityName { get; set; }
    }
}
