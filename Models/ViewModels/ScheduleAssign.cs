using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models.ViewModels
{
    public class ScheduleAssign
    {
        public int UserId { get; set; }
        public string Type { get; set; }
        public DateTime Day { get; set; }
        public string[] Assigned { get; set; }
        public string Section { get; set; }
    }
}
