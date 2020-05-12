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

        public int Cpf { get; set; }

        public int Rg { get; set; }

        public int Telefone { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }

        public string Sexo { get; set; }


        public string EstadoCivil { get; set; }

        public int Filhos { get; set; }

        public DateTime DataCadastro { get; set; }

        public int Cep { get; set; }
        public string Rua { get; set; }

        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public Membro Membro { get; set; }
        public int MembroId { get; set; }
        public Osc Osc { get; set; }
        public int OscId { get; set; }


        public ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();
        public ICollection<Recebimento> Recebimentos { get; set; } = new List<Recebimento>();


        public Usuario()
        {
        }

        public Usuario(int id, string nome, int cpf, int rg, int telefone, string email, DateTime nascimento,
            string sexo, string estadoCivil, int filhos, DateTime dataCadastro, int cep, string rua, int numero, 
            string complemento, string bairro, string cidade, string estado, Membro membro, Osc osc)
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
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Membro = membro;
            Osc = osc;
        }
    }
}
