using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ymagi.Models.ViewModels
{
    public class UserViewModel
    {
        public Usuario Usuario { get; set; }

        public ICollection<Membro> Membros { get; set; }
    }
}
