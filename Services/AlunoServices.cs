using System;
using System.Collections.Generic;
using System.Linq;
using TesteAluno.Data;
using TesteAluno.Models;

namespace TesteAluno.Services
{
    public class AlunoServices : IAlunoService
    {
        BancoTestContext _context;
        public AlunoServices(BancoTestContext context)
        {
            _context = context;
        }

        public List<Aluno> All()
        {
            return _context.Aluno.ToList();            
        }
       
        public Aluno Get(int? id)
        {
            return _context.Aluno.FirstOrDefault(A => A.Id == id);
        }

        public bool Create(Aluno aluno)
        {
            try
            {
                aluno.DataCriacao = DateTime.Now;
                _context.Add(aluno);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int? id)
        {
            if (!_context.Aluno.Any(A => A.Id == id))
                throw new Exception("Id do aluno nao existe");
            try
            {
                _context.Remove(this.Get(id));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Update(Aluno aluno)
        {
            try
            {
                if (!_context.Aluno.Any(A => A.Id == aluno.Id))
                    throw new Exception("Id invalido!");
                aluno.DataAtualizacao = DateTime.Now;
                _context.Update(aluno);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
