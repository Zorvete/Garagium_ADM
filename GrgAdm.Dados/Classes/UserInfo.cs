using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrgAdm.Dados.Classes
{
    public class UserInfo
    {

        public int id { get; set; }
        public string username { get; set; }
        public string codigo { get; set; }
        public int perfil { get; set; }
        public string Nome { get; set; }
        public int n_acessos { get; set; }
        public DateTime criacao_data { get; set; }

        public UserInfo()
        {

        }
    }
}
