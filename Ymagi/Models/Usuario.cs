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

        [Display(Name = "Número CPF")]
        public int Cpf { get; set; }

        [Display(Name = "Número RG")]
        public int Rg { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DataType(DataType.PhoneNumber)]
        public int Telefone { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [EmailAddress(ErrorMessage = "{0} digite um email válido!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }

        [Display(Name = "Homen ou Mulher?")]
        public string Sexo { get; set; }


        [Display(Name = "Estado Civil")]
        public string EstadoCivil { get; set; }

        [Display(Name = "Tem Filhos? Quantos?")]
        public int Filhos { get; set; }

        [Display(Name = "Data de cadastro")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "CEP")]
        public int Cep { get; set; }
        public string Rua { get; set; }

        [Display(Name = "Número")]
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public Membro Membro { get; set; }
        public Osc Osc { get; set; }
        public int MembroId { get; set; }
        public int OscId { get; set; }


        public ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();
        public ICollection<Recebimento> Recebimentos { get; set; } = new List<Recebimento>();


        public Usuario()
        {
        }

        public Usuario(int id, string nome, int cpf, int rg, int telefone,
            string email, DateTime nascimento, string sexo, string estadoCivil,
            int filhos, DateTime dataCadastro, int cep, string rua, int numero,
            string complemento, string bairro, string cidade, string estado)
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
        }
    }
}
