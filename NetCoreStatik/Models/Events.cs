using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreStatik.Models
{
    public class Events
    {
        [Key]
        public int eventId { get; set; }
        public string? userIp { get; set; }
        public string? pageName { get; set; }
        public DateTime? enterDate { get; set; }
        public DateTime? exitDate { get; set; }
        public string connectionId { get; set; }

    }
}
