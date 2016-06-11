using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal_FA7_WP.model
{
    [Table]
    class Usuario
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }

        [Column()]
        public string Nome { get; set; }
    }
}
