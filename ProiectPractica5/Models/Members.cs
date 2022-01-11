using System;
using System.ComponentModel.DataAnnotations;

namespace ProiectPractica5.Models
{
    public class Members
    {
        [Key]
        public Guid IdMembers { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string Resume { get; set; }
    }
}
