using System;

namespace TesteAluno.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Nascimento { get; set; }

        public string Endereco { get; set; }

        public DateTime? DataCriacao { get; set; }
        
        public DateTime? DataAtualizacao { get; set; }
    }
}
 