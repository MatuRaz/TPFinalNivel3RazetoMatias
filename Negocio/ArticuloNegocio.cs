using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        private AccesoDatos datos = new AccesoDatos();
        public List<Articulo> Listar() 
        {
			List<Articulo> lista = new List<Articulo>();

			try
			{
				datos.SetearConsulta("select IdCategoria, a.Id, Codigo, Nombre, a.Descripcion, m.Descripcion Marca, c.Descripcion Categoria, ImagenUrl, Precio from ARTICULOS a, MARCAS m, CATEGORIAS c where a.IdMarca = m.Id and a.IdCategoria = c.Id");
				datos.EjecutarLectura();

				while (datos.Lector.Read()) 
				{
					Articulo aux = new Articulo();	

					aux.Id = (int)datos.Lector["Id"];
					aux.Codigo = (string)datos.Lector["Codigo"];
					aux.Nombre = (string)datos.Lector["Nombre"];
					aux.Descripcion = (string)datos.Lector["Descripcion"];
					aux.Marca = new Marca();
					aux.Marca.Descripcion = (string)datos.Lector["Marca"];
					aux.Categoria = new Categoria();
					aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
					aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];				
					aux.Precio = (decimal)datos.Lector["Precio"];

					

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

		public void Agregar(Articulo nuevo) 
		{
			try
			{
				datos.SetearConsulta("insert ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
				datos.SetearParametros("@Id", nuevo.Id);
                datos.SetearParametros("@Nombre", nuevo.Nombre);
                datos.SetearParametros("@Codigo", nuevo.Codigo);
                datos.SetearParametros("@Descripcion", nuevo.Descripcion);
                datos.SetearParametros("@IdMarca", nuevo.Marca.Id);
                datos.SetearParametros("@IdCategoria", nuevo.Categoria.Id);
                datos.SetearParametros("ImagenUrl", nuevo.ImagenUrl);
                datos.SetearParametros("Precio", nuevo.Precio);

				datos.EjecutarAccion();
            }
			catch (Exception ex)
			{

				throw ex;
			}
			finally { datos.CerrarConexion(); }
		}

		public void Modificar(Articulo selecionado) 
		{
			try
			{
				datos.SetearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio where Id = @Id");
                datos.SetearParametros("@Id", selecionado.Id);
                datos.SetearParametros("@Codigo", selecionado.Codigo);
				datos.SetearParametros("@Nombre", selecionado.Nombre);
                datos.SetearParametros("@Descripcion", selecionado.Descripcion);
                datos.SetearParametros("@IdMarca", selecionado.Marca.Id);
                datos.SetearParametros("@IdCategoria", selecionado.Categoria.Id);
                datos.SetearParametros("@ImagenUrl", selecionado.ImagenUrl);
                datos.SetearParametros("@Precio", selecionado.Precio);

                datos.EjecutarAccion();
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally { datos.CerrarConexion(); }
		}

		public void EliminarFisico(int Id) 
		{

			try
			{
                datos.SetearConsulta("delete from ARTICULOS where Id = @Id");
                datos.SetearParametros("@Id", Id);

				datos.EjecutarAccion();
            }
			catch (Exception ex)
			{

				throw ex;
			}
			finally { datos.CerrarConexion(); }
			
		}

		public List<Articulo> FiltroAvanzado(string campo, string criterio, string filtro)
		{
			List<Articulo> lista = new List<Articulo>();
			string consulta = "select a.Id, Codigo, Nombre, a.Descripcion, m.Descripcion Marca, c.Descripcion Categoria, ImagenUrl, Precio from ARTICULOS a, MARCAS m, CATEGORIAS c where a.IdMarca = m.Id and a.IdCategoria = c.Id and ";
			try
			{
				if(campo == "Codigo") 
				{
					if (criterio == "Igual") 
					{
						consulta += "Codigo like'" + filtro + "'";
					}
                    else if (criterio == "Empieza")
                    {
						consulta += "Codigo like '" + filtro +"%'";
                    }
                    else if (criterio == "Termina")
                    {
                        consulta += "Codigo like '%" + filtro + "'";
                    }
                }
                else if (campo == "Categoria")
                {
                    if (criterio == "Igual")
                    {
                        consulta += "c.Descripcion like '" + filtro + "'";
                    }
                    else if (criterio == "Empieza")
                    {
                        consulta += "c.Descripcion like '" + filtro + "%'";
                    }
                    else if (criterio == "Termina")
                    {
                        consulta += "c.Descripcion like '%" + filtro + "'";
                    }
                }   
                else if(campo == "Precio")
                {
                    if (criterio == "Igual")
                    {
                        consulta += "Precio =" + filtro;
                    }
                    else if (criterio == "Mayor")
                    {
                        consulta += "Precio > " + filtro;
                    }
                    else if (criterio == "Menor")
                    {
                        consulta += "Precio < " + filtro;
                    }
                }
 
                datos.SetearConsulta(consulta);
				datos.EjecutarLectura();

				while (datos.Lector.Read())
				{
                    Articulo aux = new Articulo();
					decimal auxx;

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
					
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

    }
}
