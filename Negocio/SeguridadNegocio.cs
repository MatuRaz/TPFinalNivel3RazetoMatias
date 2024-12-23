using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class SeguridadNegocio
    {
        public static bool SesionActiva(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario != null)
                return true;
            else
                return false;
        }

        public static bool EsAdmin(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario == null || usuario.Admin != true)
                return false;
            else
                return true;
        }


    }
}
