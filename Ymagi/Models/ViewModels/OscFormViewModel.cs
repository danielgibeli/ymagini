﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ymagi.Models.ViewModels
{
    public class OscFormViewModel
    {
        public Membro Membro { get; set; }

        public ICollection<Osc> Oscs { get; set; }
    }
}
