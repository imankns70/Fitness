using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class Schedule
    {

        [Key]
        public int Id { get; set; }
        public DateTime SelectedDay { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
