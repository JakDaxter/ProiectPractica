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
        public DbSet<CodeShippets> Get();
        public void Put(CodeShippets codeShippets);
        public void  Post(CodeShippets codeShippets);
        public void Delete(CodeShippets codeShippets);

    }
}
