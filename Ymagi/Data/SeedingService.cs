using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ymagi.Models;

namespace Ymagi.Data
{
    public class SeedingService
    {
        private YmagiContext _context;

        public SeedingService(YmagiContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Osc.Any() ||
                _context.Membro.Any() ||
                _context.Usuario.Any() ||
                _context.Produto.Any() ||
                _context.Fornecedor.Any() ||
                _context.Recebimento.Any() ||
                _context.Entrega.Any())
            {
                return; //DB já foi populado
            }

            Osc osc1 = new Osc(1, "Ymagi Social", "Ymagi", "123456789",
                "Daniel", "daniel@ymagi", "1234567", "Holanda", 1054, "2",
                "Vila Mariana", "Ribeirao Preto", "SP", "Daniel", "Adm");

            Membro mem1 = new Membro(1, "Daniel Gibeli", 12345678, 2548255, 254455225, "email",
                new DateTime(1984, 08, 03), "Masc", "Solteiro", 2, new DateTime(2020, 09, 05), 14075240,
                "Holanda", 1054, "m", "vl mariana", "ribeirao", "SP", osc1);

            Usuario us1 = new Usuario(1, "Daniel", 123456, 123456, 25487, "daniel@gmail", new DateTime(1980, 05, 03), 
                "Masc", "Casado", 2, new DateTime(2020, 09, 05), 14075210, "Guiana", 450, "34m", "Vl Mariana", "Ribs", "SP",mem1, osc1);


            Fornecedor for1 = new Fornecedor(1, "Ymagi Gestao Ltda", "Ymagi", "123456789", "Holanda", 
                1054, "casa", "Vl Mariana", "Ribeirao Preto","SP", "Daniel", "999945651", "daniel@ymagi.com");

            Produto p1 = new Produto(1, "Arroz", "KG", 10, 10, 15, 15,new DateTime(1985, 07, 03), for1);

            Entrega en = new Entrega(1, new DateTime(2020, 09, 05), 100, us1, mem1, 0, 1, Models.Enums.DoacoesStatus.Cancelada);

            Recebimento rec = new Recebimento(1, new DateTime(2020, 09, 05), 200, us1, mem1,for1,1,2,1, Models.Enums.DoacoesStatus.Efetivada);

            _context.Osc.AddRange(osc1);
            _context.Membro.AddRange(mem1);
            _context.Usuario.AddRange(us1);
            _context.Fornecedor.AddRange(for1);
            _context.Produto.AddRange(p1);
            _context.Entrega.AddRange(en);
            _context.Recebimento.AddRange(rec);

            _context.SaveChanges();

        }
    }
}
