using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUExamen.Transactions
{
    public class CategoriaBLL
    {
        public static List<Categoria> List()
        {
            Entities db = new Entities();
            return db.Categorias.ToList();
        }
    }
}
