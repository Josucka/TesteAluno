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

        public List<Aluno> GetList()
        {
            List<Aluno> alunoList;
            try
            {
                alunoList = _context.Set<Aluno>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return alunoList;            
        }
       
        public Aluno Get(int? id)
        {
            Aluno aluno;
            try
            {
                aluno = _context.Find<Aluno>(id);
            }
            catch (Exception)
            {
                throw;
            }
            return aluno;
        }

        public AlunoModel Create(Aluno aluno)
        {
            AlunoModel novoAluno = new AlunoModel();
            try
            {
                Aluno _aluno = Get(aluno.Id);
                if(_aluno != null)
                {
                    _aluno.Nome = aluno.Nome;
                    _aluno.Nascimento = aluno.Nascimento;
                    _aluno.Endereco = aluno.Endereco;
                    _aluno.DataCriacao = DateTime.Now;
                    _context.Add<Aluno>(_aluno);
                    _context.SaveChanges();
                    novoAluno.Message = "Criado com Success";
                }
                else
                {
                    novoAluno.Message = "Successfully";
                }
                _context.SaveChanges();
                novoAluno.IsSuccess = true;
            }
            catch (Exception ex)
            {
                novoAluno.IsSuccess = false;
                novoAluno.Message = "Error : " + ex.Message;
            }
            return novoAluno;
        }

        public AlunoModel Delete(int? id)
        {
            AlunoModel excluirAluno = new AlunoModel();
            try
            {
                Aluno _aluno = Get(id);
                if (_aluno != null)
                {
                    _context.Remove<Aluno>(_aluno);
                    _context.SaveChanges();
                    excluirAluno.IsSuccess = true;
                    excluirAluno.Message = "Excluido com Success";
                }
                else
                {
                    excluirAluno.IsSuccess = false;
                    excluirAluno.Message = "Erro ao excluir item";
                }
            }
            catch (Exception ex)
            {
                excluirAluno.IsSuccess = false;
                excluirAluno.Message = "Error : " + ex.Message;
            }
            return excluirAluno;
        }

        public AlunoModel Update(Aluno aluno)
        {
            AlunoModel novoAluno = new AlunoModel();
            try
            {
                Aluno _aluno = Get(aluno.Id);
                if (_aluno != null)
                {
                    _aluno.Nome = aluno.Nome;
                    _aluno.Nascimento = aluno.Nascimento;
                    _aluno.Endereco = aluno.Endereco;
                    _aluno.DataAtualizacao = DateTime.Now;
                    _context.Update<Aluno>(_aluno);
                    novoAluno.Message = "Atualizado com Success";
                }
                else
                {
                    novoAluno.Message = "Successfully";
                }
                _context.SaveChanges();
                novoAluno.IsSuccess = true;
            }
            catch (Exception ex)
            {
                novoAluno.IsSuccess = false;
                novoAluno.Message = "Error : " + ex.Message;
            }
            return novoAluno;
        }
    }
}
