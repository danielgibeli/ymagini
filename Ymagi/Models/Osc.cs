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

        [Display(Name = "Nome Fantasia")]
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

        [Display(Name = "Endereço: Rua, Avenida, etc...")]
        public string Endereço { get; set; }

        [Display(Name = "Número")]
        public int Numero { get; set; }

        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Contato { get; set; }
        public string Observacao { get; set; }

        public ICollection<Membro> Membros { get; set; } = new List<Membro>();
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();
        public ICollection<Recebimento> Recebimentos { get; set; } = new List<Recebimento>();


        public Osc()
        {
        }

        public Osc(int id, string razaoSocial, string nome, string cnpj, string responsavel, 
            string email, string telefone, string endereço, int numero, string complemento, 
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

        public void AddUsuarios(Usuario usuarios)
        {
            Usuarios.Add(usuarios);
        }

        public void RemMembros(Membro membros)
        {
            Membros.Remove(membros);
        }

        public void RemUsuarios(Usuario usuarios)
        {
            Usuarios.Remove(usuarios);
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
