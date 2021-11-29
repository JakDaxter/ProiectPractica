using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica5.Models
{
    public class Announcements
    {
        [Key]
        public Guid IdAnnouncement { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime EventDateTime { get; set; }
        public string Tags { get; set; }
    }
}
