using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ymagi.Models
{
    public class Osc
    {
        public int Id { get; set; }

        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Display(Name = "Nome Organização")]
        public string Nome { get; set; }

        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        [Display(Name = "Responsável")]
        public string Responsavel { get; set; }

        [EmailAddress(ErrorMessage = "{0} digite um email válido!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        public string Cep { get; set; }

        [Display(Name = "Endereço: Endereco, Avenida, etc...")]
        public string Endereço { get; set; }

        [Display(Name = "Número")]
        public string Numero { get; set; }

        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Contato { get; set; }
        public string Observacao { get; set; }

        public ICollection<Membro> Membros { get; set; } = new List<Membro>();

        public Osc()
        {
        }

        public Osc(int id, string razaoSocial, string nome, string cnpj, string responsavel,
            string email, string telefone, string cep, string endereço, string numero, string complemento,
            string bairro, string cidade, string estado, string contato, string observacao)
        {
            Id = id;
            RazaoSocial = razaoSocial;
            Nome = nome;
            Cnpj = cnpj;
            Responsavel = responsavel;
            Email = email;
            Telefone = telefone;
            Endereço = endereço;
            Cep = cep;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Contato = contato;
            Observacao = observacao;
        }

        public void AddMembros(Membro membros)
        {
            Membros.Add(membros);
        }

        public void RemMembros(Membro membros)
        {
            Membros.Remove(membros);
        }

        public double TotalEntregasOsc(DateTime inicial, DateTime final)
        {
            return Membros.Sum(membros => membros.TotalEntregasMembros(inicial, final));
        }

        public double TotalRecebimentosOsc(DateTime inicial, DateTime final)
        {
            return Membros.Sum(membros => membros.TotalRecebimentosMembros(inicial, final));
        }

    }
}
