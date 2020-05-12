﻿using System;
using Ymagi.Models.Enums;

namespace Ymagi.Models
{
    public class Entrega
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Total { get; set; }
        public Usuario Usuario { get; set; }
        public Membro Membro { get; set; }
        public int UsuarioId { get; set; }
        public int MembroId { get; set; }
        public DoacoesStatus Status { get; set; }

        public Entrega()
        {
        }

        public Entrega(int id, DateTime data, double total,
        Usuario usuario, Membro membro, int usuarioId, int membroId, DoacoesStatus status)
        {
            Id = id;
            Data = data;
            Total = total;
            Usuario = usuario;
            Membro = membro;
            UsuarioId = usuarioId;
            MembroId = membroId;
            Status = status;
        }
    }
}
