using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal_FA7_WP.bd
{
    class UsuarioDataContext: DataContext
    {
        public UsuarioDataContext(): base("isostore:/usuario.sdf") { }

        public Table<model.Usuario> usuarios;
    }
}
