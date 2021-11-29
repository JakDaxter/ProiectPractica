using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica5.Models
{
    public class CodeShippets
    {
        [Key]
        public Guid IdCodeShippet { get; set; }
        public string Title { get; set; }
        public string ContentCode { get; set; }
        public Guid IdMember { get; set; }
        public int Revision { get; set; }
        public bool IsPublished { get; set; }
        public DateTime DatetimeAdded { get; set; }
    }
}
