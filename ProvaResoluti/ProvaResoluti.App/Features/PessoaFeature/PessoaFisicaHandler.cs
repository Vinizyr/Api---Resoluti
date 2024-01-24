using ProvaResoluti.App.Features.Autenticacao;
using ProvaResoluti.App.Features.PessoaFeature.Commands;
using ProvaResoluti.Domain.IRepository;
using ProvaResoluti.Domain.Models;
using ProvaResoluti.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ProvaResoluti.App.Features.PessoaFeature
{
    public class PessoaFisicaHandler : ICommandHandler<PessoaFisicaCommand>,
                                       ICommandHandler<UpdatePessoaFisicaCommand>,
                                       ICommandHandler<DeletePessoaFisicaCommand> 
    {
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;
        private readonly TokenService _tokenService;

        public PessoaFisicaHandler(IPessoaFisicaRepository pessoaFisicaRepository, TokenService tokenService)
        {
            _pessoaFisicaRepository = pessoaFisicaRepository;
            _tokenService = tokenService;
        }

        public async Task<ICommandResult> Handle(PessoaFisicaCommand command)
        {
            
            bool existe = await _pessoaFisicaRepository.PessoaExiste(command.CPF);
            bool existeUsername = await _pessoaFisicaRepository.UsernameExiste(command.Username);
            if (existe)
            {
                return new PessoaFisicaResult()
                {
                    Sucesso = false,
                    Mensagem = "CPF já utilizado. "
                };
            }
            if(existeUsername)
            {
                return new PessoaFisicaResult()
                {
                    Sucesso = false,
                    Mensagem = "Username já utilizado. "
                };
            }

            PessoaFisica novaPessoa = new PessoaFisica()
            {
                Nome = command.Nome,
                SobreNome = command.Sobrenome,
                CPF = command.CPF,
                RG = command.RG,
                DataNascimento = command.DataNascimento.Date,
                Email = command.Email,
                
            };
            
            Enderecos enderecos = new Enderecos()
            {
                Logradouro = command.Logradouro,
                Cidade = command.Cidade,
                Estado = command.Estado,
                CEP = command.CEP,
                Numero = command.Numero,
                Complemento = command.Complemento,

            };
            novaPessoa.Enderecos.Add(enderecos);

            Contatos contato = new Contatos()
            {
                Telefone = command.TelefoneCelular,
                Email = command.Email
            };
            novaPessoa.Contatos.Add(contato);

            var senhaCriptografada = _tokenService.CriptografarSenha(command.Senha);

            Usuario usuario = new Usuario()
            {
                Username = command.Username,
                Senha = senhaCriptografada
            };
            novaPessoa.Usuario = usuario;

            await _pessoaFisicaRepository.Save(novaPessoa);

            return new PessoaFisicaResult()
            {
                Sucesso = true,
                Mensagem = $"{command.Nome} foi cadastrada(o) com sucesso. "
            };

        }

        public async Task<ICommandResult> Handle(UpdatePessoaFisicaCommand command)
        {

            if (command.PessoaLogada == null)
            {
                return new PessoaFisicaResult()
                {
                    Sucesso = false,
                    Mensagem = "O usuário deve estar logado. "
                };
            }

            var pessoa = await _pessoaFisicaRepository.GetById(command.PessoaId);

            if (pessoa == null)
            {
                return new PessoaFisicaResult()
                {
                    Sucesso = false,
                    Mensagem = "Pessoa não encontrada. "
                };
            }

            var dataNova = DateTime.Parse(command.DataNascimento);

            //Pra simplificar, sei que os outros campos devem ser editáveis
            pessoa.Nome = command.Nome;
            pessoa.SobreNome = command.Sobrenome;
            pessoa.DataNascimento = dataNova;
            pessoa.RG = command.RG;
            pessoa.CPF = command.CPF;

            await _pessoaFisicaRepository.Edit(pessoa);

            return new PessoaFisicaResult()
            {
                Sucesso = true,
                Mensagem = "Dados Atualizados com sucesso."
            };

        }

        public async Task<ICommandResult> Handle(DeletePessoaFisicaCommand command)
        {
            if (command.PessoaLogada == null)
            {
                return new PessoaFisicaResult()
                {
                    Sucesso = false,
                    Mensagem = "O usuário deve estar logado. "
                };
            }
            var pessoa = await _pessoaFisicaRepository.GetById(command.PessoaId);
            if (pessoa == null)
            {
                return new PessoaFisicaResult()
                {
                    Sucesso = false,
                    Mensagem = "Pessoa não encontrada. "
                };
            }

            await _pessoaFisicaRepository.Delete(command.PessoaId);
            return new PessoaFisicaResult()
            {
                Sucesso = true,
                Mensagem = "Pessoa excluída. "
            };

        }
    }
}
