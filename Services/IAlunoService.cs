using System.Collections.Generic;
using TesteAluno.Models;

namespace TesteAluno.Services
{
    public interface IAlunoService
    {
        List<Aluno> GetList();

        Aluno Get(int? id);

        AlunoModel Create(Aluno aluno);

        AlunoModel Update(Aluno aluno);

        AlunoModel Delete(int? id);
    }
}
