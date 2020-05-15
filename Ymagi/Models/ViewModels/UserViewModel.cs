﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ymagi.Models.ViewModels
{
    public class UserViewModel
    {
        public Usuario Usuario { get; set; }

        public ICollection<Membro> Membros { get; set; }

        public Membro Membro { get; set; }

        public ICollection<Osc> Oscs { get; set; }

    }
}
