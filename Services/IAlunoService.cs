using System.Collections.Generic;
using TesteAluno.Models;

namespace TesteAluno.Services
{
    public interface IAlunoService
    {
        List<Aluno> All();

        Aluno Get(int? id);

        bool Create(Aluno aluno);

        bool Update(Aluno aluno);

        bool Delete(int? id);
    }
}
