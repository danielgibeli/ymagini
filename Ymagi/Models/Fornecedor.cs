using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ymagi.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string Cnpj { get; set; }

        public string Endereço { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Contato { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Membro Membro { get; set; }
        public int MembroId { get; set; }


        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();

        public Fornecedor()
        {
        }

        public Fornecedor(int id, string razaoSocial, string nomeFantasia, string cnpj, 
            string endereço, string numero, string complemento, string bairro, string cidade, 
            string estado, string contato, string telefone, string email)
        {
            Id = id;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            Endereço = endereço;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Contato = contato;
            Telefone = telefone;
            Email = email;
        }
    }
}
