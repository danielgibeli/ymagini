using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ymagi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public DateTime Nascimento { get; set; }

        public string Sexo { get; set; }


        public string EstadoCivil { get; set; }

        public string Filhos { get; set; }

        public DateTime DataCadastro { get; set; }

        public string Cep { get; set; }
        public string Endereco { get; set; }

        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public Membro Membro { get; set; }
        public int MembroId { get; set; }


        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
        public ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();
        public ICollection<Recebimento> Recebimentos { get; set; } = new List<Recebimento>();


        public Usuario()
        {
        }

        public Usuario(int id, string nome, string cpf, string rg, string telefone, string email, DateTime nascimento,
            string sexo, string estadoCivil, string filhos, DateTime dataCadastro, string cep, string endereco, string numero, 
            string complemento, string bairro, string cidade, string estado, Membro membro)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Rg = rg;
            Telefone = telefone;
            Email = email;
            Nascimento = nascimento;
            Sexo = sexo;
            EstadoCivil = estadoCivil;
            Filhos = filhos;
            DataCadastro = dataCadastro;
            Cep = cep;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Membro = membro;
        }
    }
}
