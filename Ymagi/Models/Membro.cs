using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ymagi.Models
{
    public class Membro
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int Cpf { get; set; }

        public int Rg { get; set; }

        public int Telefone { get; set; }

        public string Email { get; set; }

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
        public Osc Osc { get; set; }
        public int OscId { get; set; }

        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public ICollection<Fornecedor> Fornecedores { get; set; } = new List<Fornecedor>();
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
        public ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();
        public ICollection<Recebimento> Recebimentos { get; set; } = new List<Recebimento>();

        public Membro()
        {
        }

        public Membro(int id, string nome, int cpf, int rg, int telefone, string email, DateTime nascimento, 
            string sexo, string estadoCivil, int filhos, DateTime dataCadastro, int cep, string rua, int numero, 
            string complemento, string bairro, string cidade, string estado, Osc osc)
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
            Osc = osc;
        }

        public void AddFornecedor(Fornecedor fornecedor)
        {
            Fornecedores.Add(fornecedor);
        }

        public void RemFornecedor(Fornecedor fornecedor)
        {
            Fornecedores.Remove(fornecedor);
        }


        public void AddProduto(Produto produto)
        {
            Produtos.Add(produto);
        }

        public void RemProduto(Produto produto)
        {
            Produtos.Remove(produto);
        }

        public void AddEntrega(Entrega entrega)
        {
            Entregas.Add(entrega);
        }

        public void AddRecebimento(Recebimento recebe)
        {
            Recebimentos.Add(recebe);
        }

        public void RemEntrega(Entrega entrega)
        {
            Entregas.Remove(entrega);
        }

        public void RemRecebimento(Recebimento recebe)
        {
            Recebimentos.Remove(recebe);
        }

        public double TotalEntregasMembros(DateTime inicial, DateTime final)
        {
            return Entregas.Where(ent => ent.Data >= inicial && ent.Data <= final).Sum(ent => ent.Total);
        }

        public double TotalRecebimentosMembros(DateTime inicial, DateTime final)
        {
            return Recebimentos.Where(rec => rec.Data >= inicial && rec.Data <= final).Sum(rec => rec.Total);
        }
    }
}
