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
        public DateTime Data { get; set; }
        public double Total { get; set; }
        public Usuario Usuario { get; set; }
        public Membro Membro { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public int UsuarioId { get; set; }
        public int MembroId { get; set; }
        public int FornecedorId { get; set; }
        public DoacoesStatus Status { get; set; }

        public Recebimento()
        {
        }

        public Recebimento(int id, DateTime data, double total, Usuario usuario,
            Membro membro, Fornecedor fornecedor, int usuarioId, int membroId, int fornecedorId, DoacoesStatus status)
        {
            Id = id;
            Data = data;
            Total = total;
            Usuario = usuario;
            Membro = membro;
            Fornecedor = fornecedor;
            UsuarioId = usuarioId;
            MembroId = membroId;
            FornecedorId = fornecedorId;
            Status = status;
        }
    }
}
