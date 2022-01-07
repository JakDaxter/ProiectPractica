using Microsoft.EntityFrameworkCore;
using ProiectPractica5.App_Data;
using ProiectPractica5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica5.Services
{
    public class CodeSnippetsServices : ICodeSnippetsServices
    {
        private readonly ClubMembershipDbContext _context;

        public CodeSnippetsServices(ClubMembershipDbContext context)
        {
            _context = context;
        }


        public void Delete(CodeSnippets codeShippets)
        {
            _context.Remove(codeShippets);
            _context.SaveChanges();
        }

        public DbSet<CodeSnippets> Get()
        {
            return _context.CodeShippets;
        }

        public void Post(CodeSnippets codeShippets)
        {
            var codeS = new CodeSnippets()
            {
                IdCodeShippet = Guid.NewGuid(),//nu il trimitem in swagger
                Title = codeShippets.Title,
                ContentCode = codeShippets.ContentCode,
                IdMember = codeShippets.IdMember,
                IsPublished = codeShippets.IsPublished,
                DatetimeAdded = DateTime.Now//nu il timitem in swagger
            };
            _context.Entry(codeS).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Put(CodeSnippets codeShippets)
        {
            _context.Update(codeShippets);
            _context.SaveChanges();
        }
    }
}
