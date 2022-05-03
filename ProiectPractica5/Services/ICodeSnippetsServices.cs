using Microsoft.EntityFrameworkCore;
using ProiectPractica5.Models;
using System.Threading.Tasks;

namespace ProiectPractica5.Services
{
    public interface ICodeSnippetsServices
    {
        public Task<DbSet<CodeSnippets>> Get();
        public Task Put(CodeSnippets codeShippets);
        public Task  Post(CodeSnippets codeShippets);
        public Task Delete(CodeSnippets codeShippets);

    }
}
