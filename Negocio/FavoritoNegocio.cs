using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FavoritoNegocio
    {
        public void Agregar(int IdArticulo, int IdUser)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("insert into FAVORITOS (IdUser, IdArticulo) values (@IdUser, @IdArticulo)");
                datos.SetearParametros("@IdUser", IdUser);
                datos.SetearParametros("@IdArticulo", IdArticulo);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.CerrarConexion(); }

        }

        public List<Favorito> Listar(int IdUser)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Favorito> lista = new List<Favorito>();
            try
            {

                datos.SetearConsulta("select Id, IdArticulo from FAVORITOS where IdUser = @IdUser");
                datos.SetearParametros("@IdUser", IdUser);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Favorito aux = new Favorito();

                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.CerrarConexion(); }

        }

        public void Eliminar(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("delete from FAVORITOS where IdArticulo = @Id");
                datos.SetearParametros("@Id", Id);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.CerrarConexion(); }

        }






    }
}
