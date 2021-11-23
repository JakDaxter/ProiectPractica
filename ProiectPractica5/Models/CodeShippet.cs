using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica5.Models
{
    public class CodeShippet
    {
        public int IdCodeShippet { get; set; }
        public string Title { get; set; }
        public string ContentCode { get; set; }
        public int IdMember { get; set; }
        public int Revision { get; set; }
        public bool isPublished { get; set; }
        public DateTime DatetimeAdded { get; set; }
    }
}
