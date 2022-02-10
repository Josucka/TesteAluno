using System;
using System.ComponentModel.DataAnnotations;

namespace TesteAluno.Models
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? Nascimento { get; set; }

        public string Endereco { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataCriacao { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? DataAtualizacao { get; set; }
    }
}
 