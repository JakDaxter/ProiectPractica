using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProiectPractica5.Models
{
    public class CodeSnippets
    {
        [Key]
        public Guid IdCodeShippet { get; set; }
        public string Title { get; set; }
        public string ContentCode { get; set; }
        public Guid IdMember { get; set; }
        public int Revision { get; set; }
        public bool IsPublished { get; set; }
        public DateTime DatetimeAdded { get; set; }

        public static implicit operator DbSet<object>(CodeSnippets v)
        {
            throw new NotImplementedException();
        }
    }
}
