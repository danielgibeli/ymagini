using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ymagi.Models.ViewModels
{
    public class UserViewModel
    {
        public Usuario Usuarios { get; set; }

        public ICollection<Membro> Membro { get; set; }

    }
}
