using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ymagi.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Unidade { get; set; }
        public double Quantidade { get; set; }
        public double ValorUnit { get; set; }
        public double ValorTotal { get; set; }
        public DateTime Date { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public Usuario Usuario { get; set; }
        public Membro Membro { get; set; }

        public ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();
        public ICollection<Recebimento> Recebimentos { get; set; } = new List<Recebimento>();


        public Produto()
        {
        }

        public Produto(int id, string nome, string unidade, double quantidade, double total, double valorUnit, 
            double valorTotal, DateTime date, Fornecedor fornecedor, Usuario usuario, Membro membro)
        {
            Id = id;
            Nome = nome;
            Unidade = unidade;
            Quantidade = quantidade;
            ValorUnit = valorUnit;
            ValorTotal = valorTotal;
            Date = date;
            Fornecedor = fornecedor;
            Usuario = usuario;
            Membro = membro;
        }
    }
}
