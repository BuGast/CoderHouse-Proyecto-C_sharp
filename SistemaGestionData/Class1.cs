using SistemaGestionEntities;
using System.Data;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestionData
{
    public static class ProductoData
    {
        public static List<Producto> ObtenerProducto(int IdProducto)
        {
            List<Producto> lista = new List<Producto>();
            string connectionString = @"Server=GASTONCAMU;DataBase=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario FROM producto where Id = @IdProducto;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "IdProducto";
                    parametro.SqlDbType = SqlDbType.Int;
                    parametro.Value = IdProducto;

                    comando.Parameters.Add(parametro);

                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var producto = new Producto();
                                producto.Id = Convert.ToInt32(dr["Id"]);
                                producto.Descripciones = dr["Descripciones"].ToString();
                                producto.Costo = Convert.ToDouble(dr["Costo"]);
                                producto.PrecioVenta = Convert.ToDouble(dr["PrecioVenta"]);
                                producto.Stock = Convert.ToInt32(dr["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                                lista.Add(producto);
                            }
                        }
                    }
                }
            }
            return lista;
        }
        public static List<Producto> ListarProductos()
        {
            List<Producto> lista = new List<Producto>();
            string connectionString = @"Server=GASTONCAMU;DataBase=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario FROM producto";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var producto = new Producto();
                                producto.Id = Convert.ToInt32(dr["Id"]);
                                producto.Descripciones = dr["Descripciones"].ToString();
                                producto.Costo = Convert.ToDouble(dr["Costo"]);
                                producto.PrecioVenta = Convert.ToDouble(dr["PrecioVenta"]);
                                producto.Stock = Convert.ToInt32(dr["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                                lista.Add(producto);
                            }
                        }
                    }
                }
            }
            return lista;
        }
        public static void CrearProducto(Producto producto)
        {
            string connectionString = @"Server=GASTONCAMU;DataBase=SistemaGestion;Trusted_Connection=True;";

            var query = "INSERT INTO producto (Descripciones, Costo, PrecioVenta, Stock, IDUsuario) VALUES(@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario)";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.Descripciones });
                    comando.Parameters.Add(new SqlParameter("Costo", SqlDbType.Money) { Value = producto.Costo });
                    comando.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Money) { Value = producto.PrecioVenta });
                    comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = producto.Stock });
                    comando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.Int) { Value = producto.IdUsuario });

                    comando.ExecuteNonQuery();
                }
                conexion.Close();

            }
        }
        public static void ModificarProducto(Producto producto)
        {
            string connectionString = @"Server=GASTONCAMU;DataBase=SistemaGestion;Trusted_Connection=True;";

            var query = "UPDATE Producto" +
                        " SET Descripciones = @Descripciones," +
                        " Costo = @Costo," +
                        " PrecioVenta = @PrecioVenta," +
                        " Stock = @Stock," +
                        " IdUsuario = @IdUsuario" +
                        " WHERE Id = @Id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.Descripciones });
                    comando.Parameters.Add(new SqlParameter("Costo", SqlDbType.Money) { Value = producto.Costo });
                    comando.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Money) { Value = producto.PrecioVenta });
                    comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = producto.Stock });
                    comando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.Int) { Value = producto.IdUsuario });
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = producto.Id });

                    comando.ExecuteNonQuery();
                }
                conexion.Close();

            }
        }
        public static void EliminarProducto(Producto producto)
        {
            string connectionString = @"Server=GASTONCAMU;DataBase=SistemaGestion;Trusted_Connection=True;";

            var query = "DELETE FROM Producto WHERE Id = @Id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = producto.Id });

                    comando.ExecuteNonQuery();
                }
                conexion.Close();

            }
        }



    }

    public static class ProductoVendidoData
    {
        public static List<ProductoVendido> ObtenerProductoVendido(int Id)
        {
            List<ProductoVendido> lista = new List<ProductoVendido>();
            string connectionString = @"Server=GASTONCAMU;DataBase=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id, Stock, IdProducto, IdVenta FROM ProductoVendido Where Id=@Id;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "Id";
                    parametro.SqlDbType = SqlDbType.Int;
                    parametro.Value = Id;

                    comando.Parameters.Add(parametro);
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var productoVendido = new ProductoVendido();
                                productoVendido.Id = Convert.ToInt32(dr["Id"]);
                                productoVendido.Stock = Convert.ToInt32(dr["Stock"]);
                                productoVendido.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                                productoVendido.IdVenta = Convert.ToInt32(dr["IdVenta"]);
                                lista.Add(productoVendido);
                            }
                        }
                    }
                }

            }
            return lista;
        }


        public static List<ProductoVendido> ListarProductoVendido()
        {
            List<ProductoVendido> lista = new List<ProductoVendido>();
            string connectionString = @"Server=GASTONCAMU;DataBase=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id, Stock, IdProducto, IdVenta FROM ProductoVendido;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var productoVendido = new ProductoVendido();
                                productoVendido.Id = Convert.ToInt32(dr["Id"]);
                                productoVendido.Stock = Convert.ToInt32(dr["Stock"]);
                                productoVendido.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                                productoVendido.IdVenta = Convert.ToInt32(dr["IdVenta"]);
                                lista.Add(productoVendido);
                            }
                        }
                    }
                }

            }
            return lista;
        }



        public static void CrearProductoVendido(ProductoVendido productoVendido)
        {
            string connectionString = @"Server=GASTONCAMU;DataBase=SistemaGestion;Trusted_Connection=True;";
            var query = "INSERT INTO ProductoVendido (Stock,IdProducto,IdVenta) VALUES(@Stock,@IdProducto,@IdVenta)";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = productoVendido.Stock });
                    comando.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.Int) { Value = productoVendido.IdProducto });
                    comando.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.Int) { Value = productoVendido.IdVenta });

                    comando.ExecuteNonQuery();
                }
            }
        }



        public static void ModificarProductoVendido(ProductoVendido productoVendido)
        {
            string connectionString = @"Server=GASTONCAMU;DataBase=SistemaGestion;Trusted_Connection=True;";
            var query = "UPDATE ProductoVendido SET Stock=@Stock,IdProducto=@IdProducto,IdVenta=@IdVenta WHERE Id=@Id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = productoVendido.Id });
                    comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = productoVendido.Stock });
                    comando.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.Int) { Value = productoVendido.IdProducto });
                    comando.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.Int) { Value = productoVendido.IdVenta });

                    comando.ExecuteNonQuery();
                }
            }
        }
        public static void EliminarProductoVendido(ProductoVendido productovendido)
        {
            string connectionString = @"Server=GASTONCAMU;DataBase=SistemaGestion;Trusted_Connection=True;";

            var query = "DELETE FROM ProductoVendido WHERE Id = @Id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = productovendido.Id });

                    comando.ExecuteNonQuery();
                }
                conexion.Close();

            }
        }

    }

    public static class UsuarioData
    {
        public static List<Usuario> ObtenerUsuario(int Id)
        {
            List<Usuario> lista = new List<Usuario>();
            string connectionString = @"Server=GASTONCAMU;DataBase=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail FROM Usuario Where Id=@Id;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "Id";
                    parametro.SqlDbType = SqlDbType.Int;
                    parametro.Value = Id;

                    comando.Parameters.Add(parametro);
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var usuario = new Usuario();
                                usuario.Id = Convert.ToInt32(dr["Id"]);
                                usuario.Nombre = dr["Nombre"].ToString();
                                usuario.Apellido = dr["Apellido"].ToString();
                                usuario.NombreUsuario = dr["NombreUsuario"].ToString();
                                usuario.Contraseña = dr["Contraseña"].ToString();
                                usuario.Mail = dr["Mail"].ToString();
                                lista.Add(usuario);
                            }
                        }
                    }
                }

            }
            return lista;
        }


        public static List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            string connectionString = @"Server=GASTONCAMU;DataBase=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail FROM Usuario";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var usuario = new Usuario();
                                usuario.Id = Convert.ToInt32(dr["Id"]);
                                usuario.Nombre = dr["Nombre"].ToString();
                                usuario.Apellido = dr["Apellido"].ToString();
                                usuario.NombreUsuario = dr["NombreUsuario"].ToString();
                                usuario.Contraseña = dr["Contraseña"].ToString();
                                usuario.Mail = dr["Mail"].ToString();
                                lista.Add(usuario);
                            }
                        }
                    }
                }

            }
            return lista;
        }



        public static void CrearUsuario(Usuario usuario)
        {
            string connectionString = @"Server=GASTONCAMU;DataBase=SistemaGestion;Trusted_Connection=True;";
            var query = "INSERT INTO Usuario (Nombre,Apellido,NombreUsuario,Contraseña,Mail) VALUES(@Nombre,@Apellido,@NombreUsuario,@Contraseña,@Mail)";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.Nombre });
                    comando.Parameters.Add(new SqlParameter("Apellido", SqlDbType.VarChar) { Value = usuario.Apellido });
                    comando.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario });
                    comando.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = usuario.Contraseña });
                    comando.Parameters.Add(new SqlParameter("Mail", SqlDbType.VarChar) { Value = usuario.Mail });

                    comando.ExecuteNonQuery();
                }
            }
        }



        public static void ModificarUsuario(Usuario usuario)
        {
            string connectionString = @"Server=GASTONCAMU;DataBase=SistemaGestion;Trusted_Connection=True;";
            var query = "UPDATE Usuario SET Nombre=@Nombre,Apellido=@Apellido,NombreUsuario=@NombreUsuario,Contraseña=@Contraseña,Mail=@Mail WHERE Id=@Id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = usuario.Id });
                    comando.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.Nombre });
                    comando.Parameters.Add(new SqlParameter("Apellido", SqlDbType.VarChar) { Value = usuario.Apellido });
                    comando.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario });
                    comando.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = usuario.Contraseña });
                    comando.Parameters.Add(new SqlParameter("Mail", SqlDbType.VarChar) { Value = usuario.Mail });

                    comando.ExecuteNonQuery();
                }
            }
        }
        public static void EliminarUsuario(Usuario usuario)
        {
            string connectionString = @"Server=GASTONCAMU;DataBase=SistemaGestion;Trusted_Connection=True;";

            var query = "DELETE FROM Usuario WHERE Id = @Id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = usuario.Id });

                    comando.ExecuteNonQuery();
                }
                conexion.Close();

            }
        }

    }

    public static class VentaData
    {
        public static List<Venta> ObtenerVenta(int Id)
        {
            List<Venta> lista = new List<Venta>();
            string connectionString = @"Server=GASTONCAMU;DataBase=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id, Comentarios, IdUsuario FROM Venta Where Id=@Id;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "Id";
                    parametro.SqlDbType = SqlDbType.Int;
                    parametro.Value = Id;

                    comando.Parameters.Add(parametro);
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var venta = new Venta();
                                venta.Id = Convert.ToInt32(dr["Id"]);
                                venta.Comentarios = dr["Comentarios"].ToString();
                                venta.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                                lista.Add(venta);
                            }
                        }
                    }
                }

            }
            return lista;
        }


        public static List<Venta> ListarVenta()
        {
            List<Venta> lista = new List<Venta>();
            string connectionString = @"Server=GASTONCAMU;DataBase=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id, Comentarios, IdUsuario FROM Venta;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var venta = new Venta();
                                venta.Id = Convert.ToInt32(dr["Id"]);
                                venta.Comentarios = dr["Comentarios"].ToString();
                                venta.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                                lista.Add(venta);
                            }
                        }
                    }
                }

            }
            return lista;
        }



        public static void CrearVenta(Venta venta)
        {
            string connectionString = @"Server=GASTONCAMU;DataBase=SistemaGestion;Trusted_Connection=True;";
            var query = "INSERT INTO Venta (Comentarios,IdUsuario) VALUES(@Comentarios,@IdUsuario)";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = venta.Comentarios });
                    comando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.Int) { Value = venta.IdUsuario });

                    comando.ExecuteNonQuery();
                }
            }
        }



        public static void ModificarVenta(Venta venta)
        {
            string connectionString = @"Server=GASTONCAMU;DataBase=SistemaGestion;Trusted_Connection=True;";
            var query = "UPDATE Venta SET Comentarios=@Comentarios,IdUsuario=@IdUsuario WHERE Id=@Id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = venta.Id });
                    comando.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = venta.Comentarios });
                    comando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.Int) { Value = venta.IdUsuario });

                    comando.ExecuteNonQuery();
                }
            }
        }
        public static void EliminarVenta(Venta venta)
        {
            string connectionString = @"Server=GASTONCAMU;DataBase=SistemaGestion;Trusted_Connection=True;";

            var query = "DELETE FROM Venta WHERE Id = @Id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = venta.Id });

                    comando.ExecuteNonQuery();
                }
                conexion.Close();

            }
        }

    }
}