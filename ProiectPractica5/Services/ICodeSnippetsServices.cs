using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectPractica5.Models;
namespace ProiectPractica5.Services
{
    public interface ICodeSnippetsServices
    {
        public DbSet<CodeSnippets> Get();
        public void Put(CodeSnippets codeShippets);
        public void  Post(CodeSnippets codeShippets);
        public void Delete(CodeSnippets codeShippets);

    }
}
