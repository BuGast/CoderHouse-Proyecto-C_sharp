using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_Entrega;

namespace _1_Entrega
{
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



}
