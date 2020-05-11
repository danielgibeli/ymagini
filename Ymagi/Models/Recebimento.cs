using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ymagi.Models.Enums;

namespace Ymagi.Models
{
    public class Recebimento
    {
        public int Id { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public DateTime Data { get; set; }
        public double Total { get; set; }
        public Usuario Usuario { get; set; }
        public Membro Membro { get; set; }
        public DoacoesStatus Status { get; set; }

        public Recebimento()
        {
        }

        public Recebimento(int id, DateTime data, Fornecedor fornecedor, 
            double total, Usuario usuario, Membro membro, DoacoesStatus status)
        {
            Id = id;
            Data = data;
            Fornecedor = fornecedor;
            Total = total;
            Usuario = usuario;
            Membro = membro;
            Status = status;
        }
    }
}
