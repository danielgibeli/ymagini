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
        public double Total { get; set; }
        public double ValorUnit { get; set; }
        public double ValorTotal { get; set; }
        public DateTime Date { get; set; }
        public Fornecedor Fornecedor { get; set; }


        public Produto()
        {
        }

        public Produto(int id, string nome, string unidade, double quantidade, 
            double total, double valorUnit, double valorTotal, DateTime date, Fornecedor fornecedor)
        {
            Id = id;
            Nome = nome;
            Unidade = unidade;
            Quantidade = quantidade;
            Total = total;
            ValorUnit = valorUnit;
            ValorTotal = valorTotal;
            Date = date;
            Fornecedor = fornecedor;
        }
    }
}
