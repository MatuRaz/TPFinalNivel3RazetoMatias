using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class LogicaNegocio
    {

        public bool hayNumero(string texto) 
        {
            foreach (char item in texto) 
            {
                if(char.IsDigit(item))
                {
                    return true;
                }
            }
            return false;
        }

        public bool hayLetras(string texto)
        {
            foreach (char item in texto)
            {
                if (char.IsLetter(item))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
