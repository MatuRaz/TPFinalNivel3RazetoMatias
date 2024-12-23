using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public void Agregar(Usuario Nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("insert USERS(email, pass) values (@email, @pass)");
                datos.SetearParametros("@email", Nuevo.Email);
                datos.SetearParametros("@pass", Nuevo.Contraseña);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.CerrarConexion(); }
        }

        public bool Logear(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Usuario> lista = new List<Usuario>();

            try
            {
                datos.SetearConsulta("select Id, email, pass, nombre, apellido, urlImagenPerfil, admin from USERS where email = @email and pass = @pass");
                datos.SetearParametros("@email", user.Email);
                datos.SetearParametros("@pass", user.Contraseña);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    user.Id = (int)datos.Lector["Id"];
                    user.Email = (string)datos.Lector["email"];
                    user.Contraseña = (string)datos.Lector["pass"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        user.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["Apellido"] is DBNull))
                        user.Apellido = (string)datos.Lector["apellido"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        user.urlImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
                    if (!(datos.Lector["Admin"] is DBNull))
                        user.Admin = (bool)datos.Lector["admin"];

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.CerrarConexion(); }


        }

        public void Actualizar(Usuario user)
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearConsulta("update USERS set nombre = @nombre, apellido = @apellido, urlImagenPerfil = @urlImagenPerfil where Id = @Id");
                Datos.SetearParametros("@nombre", user.Nombre);
                Datos.SetearParametros("@apellido", user.Apellido);
                Datos.SetearParametros("@urlImagenPerfil", user.urlImagenPerfil);
                Datos.SetearParametros("@Id", user.Id);

                Datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { Datos.CerrarConexion(); }


        }

        public bool MailCheck(string email)
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearConsulta("select email from USERS where email = @email");
                Datos.SetearParametros("@email", email);
                Datos.EjecutarLectura();

                if (Datos.Lector.Read())
                {
                    email = (string)Datos.Lector["email"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { Datos.CerrarConexion(); }
        }
    }
}
