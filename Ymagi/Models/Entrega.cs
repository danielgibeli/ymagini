    using System;
using System.Collections.Generic;
using Ymagi.Models.Enums;

namespace Ymagi.Models
{
    public class Entrega
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public Produto Produto { get; set; }
        public double Quantidade { get; set; }
        public double ValorUnit { get; set; }
        public double ValorTotal { get; set; }
        public Usuario Usuario { get; set; }
        public Membro Membro { get; set; }
        public DoacoesStatus Status { get; set; }

        public int ProdutoId { get; set; }
        public int UsuarioId { get; set; }
        public int MembroId { get; set; }



        public Entrega()
        {
        }

        public Entrega(int id, DateTime data, Produto produto, double quantidade, 
            double valorUnit, double valorTotal, Usuario usuario, 
            Membro membro, DoacoesStatus status)
        {
            Id = id;
            Data = data;
            Produto = produto;
            Quantidade = quantidade;
            ValorUnit = valorUnit;
            ValorTotal = valorTotal;
            Usuario = usuario;
            Membro = membro;
            Status = status;
        }
    }
}
