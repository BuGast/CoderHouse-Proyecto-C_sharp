using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData;
using SistemaGestionEntities;
using SistemaGestionBussiness;

namespace SistemaGestionBussiness
{
    public static class VentaBusiness
    {
        public static List<Venta> ObtenerVenta(int id)
        {
            return VentaData.ObtenerVenta(id);
        }
        public static List<Venta> ListarVenta()
        {
            return VentaData.ListarVenta();
        }
        public static void CrearVenta(Venta venta)
        {
            VentaData.CrearVenta(venta);
        }
        public static void ModificarVenta(Venta ventaModificada)
        {
            VentaData.ModificarVenta(ventaModificada);
        }
        public static void EliminarVenta(Venta ventaAEliminar)
        {
            VentaData.EliminarVenta(ventaAEliminar);
        }
    }
}
