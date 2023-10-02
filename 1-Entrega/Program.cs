using _1_Entrega;

Menu();

void Menu()
{
    Console.WriteLine("-----------------------------------------" +
                    "\n Menu" +
                    "\n 1: Menu Producto" +
                    "\n 2: Menu Usuario" +
                    "\n 3: Menu Venta" +
                    "\n 4: Menu ProductoVendido" +
                    "\n 5: Salir" +
                    "\n-----------------------------------------");
string op = Console.ReadLine();
    switch (op)
    {
        case "1":
            MenuProducto();
            break;
        case "2":
            MenuUsuario();
            break;
        case "3":
            MenuVenta();
            break;
        case "4":
            MenuProductoVendido();
            break;
        case "5":
            break;
        default:
            Console.WriteLine("La opcion ingresada es incorrecta");
            Menu();
            break;
    }
}


// Inicio Funciones Producto
void MenuProducto()
{
    Console.WriteLine("-----------------------------------------" +
                    "\n Menu Producto " +
                    "\n 1: Mostrar un Producto" +
                    "\n 2: Mostrar todos los productos" +
                    "\n 3: Crear un producto" +
                    "\n 4: Modificar un producto" +
                    "\n 5: Borrar un producto" +
                    "\n 6: Salir" +
                    "\n-----------------------------------------");
    string op = Console.ReadLine();
    switch (op)
    {
        case "1":
            MostrarUnProducto();
            MenuProducto();
            break;
        case "2":
            MostrarProductos();
            MenuProducto();
            break;
        case "3":
            AltaProducto();
            MenuProducto();
            break;
        case "4":
            ModificarProducto();
            MenuProducto();
            break;
        case "5":
            BajaProducto();
            MenuProducto();
            break;
        case "6":
            Menu();
            break;
        default:
            Console.WriteLine("La opcion ingresada es incorrecta");
            MenuProducto();
            break;
    }
}
void MostrarUnProducto() {

    Console.WriteLine("Ingrese un id para mostrar el producto respectivo");
    int Id = Convert.ToInt16(Console.ReadLine());
    List<Producto> productos = ProductoData.ObtenerProducto(Id);

    foreach (var producto in productos)
    {
        Console.WriteLine($"ID: {producto.Id}");
        Console.WriteLine($"Descripción: {producto.Descripciones}");
        Console.WriteLine($"Costo: {producto.Costo}");
        Console.WriteLine($"Precio de Venta: {producto.PrecioVenta}");
        Console.WriteLine($"Stock: {producto.Stock}");
        Console.WriteLine($"ID de Usuario: {producto.IdUsuario}");
    }
}
void MostrarProductos()
{
    List<Producto> productos = ProductoData.ListarProductos();


    foreach (var producto in productos)
    {
        Console.WriteLine($"ID: {producto.Id}");
        Console.WriteLine($"Descripción: {producto.Descripciones}");
        Console.WriteLine($"Costo: {producto.Costo}");
        Console.WriteLine($"Precio de Venta: {producto.PrecioVenta}");
        Console.WriteLine($"Stock: {producto.Stock}");
        Console.WriteLine($"ID de Usuario: {producto.IdUsuario}");
    }
}
void AltaProducto()
{
    Producto producto = new Producto();

    Console.Write("Ingrese la descripción del producto: ");
    producto.Descripciones = Console.ReadLine();

    Console.Write("Ingrese el costo del producto: ");
    producto.Costo = Convert.ToDouble(Console.ReadLine());

    Console.Write("Ingrese el precio de venta del producto: ");
    producto.PrecioVenta = Convert.ToDouble(Console.ReadLine());

    Console.Write("Ingrese el stock del producto: ");
    producto.Stock = Convert.ToInt32(Console.ReadLine());

    Console.Write("Ingrese el ID de usuario asociado al producto: ");
    producto.IdUsuario = Convert.ToInt32(Console.ReadLine());

    ProductoData.CrearProducto(producto);
    Console.WriteLine("Se creo el producto");
}
void ModificarProducto()
{
    Console.WriteLine("Ingrese la ID del producto que desea modificar:");
    if (int.TryParse(Console.ReadLine(), out int idProductoAModificar))
    {
        List<Producto> productoExistente = ProductoData.ObtenerProducto(idProductoAModificar);

        if (productoExistente.Count > 0)
        {
            Console.WriteLine("Ingrese la nueva descripción del producto:");
            string nuevaDescripcion = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo costo del producto:");
            if (double.TryParse(Console.ReadLine(), out double nuevoCosto))
            {
                Console.WriteLine("Ingrese el nuevo precio de venta del producto:");
                if (double.TryParse(Console.ReadLine(), out double nuevoPrecioVenta))
                {
                    Console.WriteLine("Ingrese el nuevo stock del producto:");
                    if (int.TryParse(Console.ReadLine(), out int nuevoStock))
                    {
                        Console.WriteLine("Ingrese la nueva ID de usuario:");
                        if (int.TryParse(Console.ReadLine(), out int nuevaIdUsuario))
                        {
                            Producto productoModificado = new Producto
                            {
                                Id = idProductoAModificar,
                                Descripciones = nuevaDescripcion,
                                Costo = nuevoCosto,
                                PrecioVenta = nuevoPrecioVenta,
                                Stock = nuevoStock,
                                IdUsuario = nuevaIdUsuario
                            };

                            ProductoData.ModificarProducto(productoModificado);
                            Console.WriteLine("Producto modificado con éxito.");
                        }
                        else
                        {
                            Console.WriteLine("Error: La ID de usuario ingresada no es válida.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: El stock ingresado no es válido.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: El precio de venta ingresado no es válido.");
                }
            }
            else
            {
                Console.WriteLine("Error: El costo ingresado no es válido.");
            }
        }
        else
        {
            Console.WriteLine("Error: El producto con la ID especificada no existe en la base de datos.");
        }
    }
    else
    {
        Console.WriteLine("Error: Ingrese una ID de producto válida.");
    }
}
void BajaProducto()
{
    Console.WriteLine("Ingrese la ID del producto que desea eliminar:");
    if (int.TryParse(Console.ReadLine(), out int idProductoAEliminar))
    {
        List<Producto> productoExistente = ProductoData.ObtenerProducto(idProductoAEliminar);

        if (productoExistente.Count > 0)
        {
            Console.WriteLine("¿Está seguro de que desea eliminar este producto? (S/N)");
            string confirmacion = Console.ReadLine().Trim().ToUpper();

            if (confirmacion == "S")
            {
                Producto productoAEliminar = new Producto { Id = idProductoAEliminar };

                ProductoData.EliminarProducto(productoAEliminar);
                Console.WriteLine("Producto eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("Eliminación cancelada.");
            }
        }
        else
        {
            Console.WriteLine("Error: El producto con la ID especificada no existe en la base de datos.");
        }
    }
    else
    {
        Console.WriteLine("Error: Ingrese una ID de producto válida.");
    }
}
// Fin Funciones Producto

// Inicio Funciones Usuario
void MenuUsuario()
{
    Console.WriteLine("-----------------------------------------" +
                    "\n Menu Usuario " +
                    "\n 1: Mostrar un Usuario" +
                    "\n 2: Mostrar todos los usuarios" +
                    "\n 3: Crear un usuario" +
                    "\n 4: Modificar un usuario" +
                    "\n 5: Borrar un usuario" +
                    "\n 6: Salir" +
                    "\n-----------------------------------------");
    string op = Console.ReadLine();
    switch (op)
    {
        case "1":
            MostrarUnUsuario();
            MenuUsuario();
            break;
        case "2":
            MostrarUsuarios();
            MenuUsuario();
            break;
        case "3":
            AltaUsuario();
            MenuUsuario();
            break;
        case "4":
            ModificarUsuario();
            MenuUsuario();
            break;
        case "5":
            BajaUsuario();
            MenuUsuario();
            break;
        case "6":
            Menu();
            break;
        default:
            Console.WriteLine("La opción ingresada es incorrecta");
            MenuUsuario();
            break;
    }
}
void MostrarUnUsuario()
{
    Console.WriteLine("Ingrese un ID para mostrar el usuario respectivo");
    int Id = Convert.ToInt16(Console.ReadLine());
    List<Usuario> usuarios = UsuarioData.ObtenerUsuario(Id);

    foreach (var usuario in usuarios)
    {
        Console.WriteLine($"ID: {usuario.Id}");
        Console.WriteLine($"Nombre: {usuario.Nombre}");
        Console.WriteLine($"Apellido: {usuario.Apellido}");
        Console.WriteLine($"Nombre de Usuario: {usuario.NombreUsuario}");
        Console.WriteLine($"Contraseña: {usuario.Contraseña}");
        Console.WriteLine($"Mail: {usuario.Mail}");
    }
}
void MostrarUsuarios()
{
    List<Usuario> usuarios = UsuarioData.ListarUsuarios();

    foreach (var usuario in usuarios)
    {
        Console.WriteLine($"ID: {usuario.Id}");
        Console.WriteLine($"Nombre: {usuario.Nombre}");
        Console.WriteLine($"Apellido: {usuario.Apellido}");
        Console.WriteLine($"Nombre de Usuario: {usuario.NombreUsuario}");
        Console.WriteLine($"Contraseña: {usuario.Contraseña}");
        Console.WriteLine($"Mail: {usuario.Mail}");
    }
}
void AltaUsuario()
{
    Usuario usuario = new Usuario();

    Console.Write("Ingrese el nombre del usuario: ");
    usuario.Nombre = Console.ReadLine();

    Console.Write("Ingrese el apellido del usuario: ");
    usuario.Apellido = Console.ReadLine();

    Console.Write("Ingrese el nombre de usuario: ");
    usuario.NombreUsuario = Console.ReadLine();

    Console.Write("Ingrese la contraseña del usuario: ");
    usuario.Contraseña = Console.ReadLine();

    Console.Write("Ingrese el correo electrónico del usuario: ");
    usuario.Mail = Console.ReadLine();

    UsuarioData.CrearUsuario(usuario);
    Console.WriteLine("Se creó el usuario con éxito.");
}
void ModificarUsuario()
{
    Console.WriteLine("Ingrese la ID del usuario que desea modificar:");
    if (int.TryParse(Console.ReadLine(), out int idUsuarioAModificar))
    {
        List<Usuario> usuarioExistente = UsuarioData.ObtenerUsuario(idUsuarioAModificar);

        if (usuarioExistente.Count > 0)
        {
            Console.WriteLine("Ingrese el nuevo nombre del usuario:");
            string nuevoNombre = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo apellido del usuario:");
            string nuevoApellido = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo nombre de usuario:");
            string nuevoNombreUsuario = Console.ReadLine();

            Console.WriteLine("Ingrese la nueva contraseña del usuario:");
            string nuevaContraseña = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo correo electrónico del usuario:");
            string nuevoMail = Console.ReadLine();

            Usuario usuarioModificado = new Usuario
            {
                Id = idUsuarioAModificar,
                Nombre = nuevoNombre,
                Apellido = nuevoApellido,
                NombreUsuario = nuevoNombreUsuario,
                Contraseña = nuevaContraseña,
                Mail = nuevoMail
            };

            UsuarioData.ModificarUsuario(usuarioModificado);
            Console.WriteLine("Usuario modificado con éxito.");
        }
        else
        {
            Console.WriteLine("Error: El usuario con la ID especificada no existe en la base de datos.");
        }
    }
    else
    {
        Console.WriteLine("Error: Ingrese una ID de usuario válida.");
    }
}
void BajaUsuario()
{
    Console.WriteLine("Ingrese la ID del usuario que desea eliminar:");
    if (int.TryParse(Console.ReadLine(), out int idUsuarioAEliminar))
    {
        List<Usuario> usuarioExistente = UsuarioData.ObtenerUsuario(idUsuarioAEliminar);

        if (usuarioExistente.Count > 0)
        {
            Console.WriteLine("¿Está seguro de que desea eliminar este usuario? (S/N)");
            string confirmacion = Console.ReadLine().Trim().ToUpper();

            if (confirmacion == "S")
            {
                Usuario usuarioAEliminar = new Usuario { Id = idUsuarioAEliminar };

                UsuarioData.EliminarUsuario(usuarioAEliminar);
                Console.WriteLine("Usuario eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("Eliminación cancelada.");
            }
        }
        else
        {
            Console.WriteLine("Error: El usuario con la ID especificada no existe en la base de datos.");
        }
    }
    else
    {
        Console.WriteLine("Error: Ingrese una ID de usuario válida.");
    }
}
// Fin Funciones Usuario

// Inicio Funciones Venta
void MenuVenta()
{
    Console.WriteLine("-----------------------------------------" +
                    "\n Menu Venta " +
                    "\n 1: Mostrar una Venta" +
                    "\n 2: Mostrar todas las ventas" +
                    "\n 3: Crear una venta" +
                    "\n 4: Modificar una venta" +
                    "\n 5: Borrar una venta" +
                    "\n 6: Salir" +
                    "\n-----------------------------------------");
    string op = Console.ReadLine();
    switch (op)
    {
        case "1":
            MostrarUnaVenta();
            MenuVenta();
            break;
        case "2":
            MostrarVentas();
            MenuVenta();
            break;
        case "3":
            AltaVenta();
            MenuVenta();
            break;
        case "4":
            ModificarVenta();
            MenuVenta();
            break;
        case "5":
            BajaVenta();
            MenuVenta();
            break;
        case "6":
            Menu();
            break;
        default:
            Console.WriteLine("La opción ingresada es incorrecta");
            MenuVenta();
            break;
    }
}
void MostrarUnaVenta()
{
    Console.WriteLine("Ingrese un ID para mostrar la venta respectiva");
    int Id = Convert.ToInt16(Console.ReadLine());
    List<Venta> ventas = VentaData.ObtenerVenta(Id);

    foreach (var venta in ventas)
    {
        Console.WriteLine($"ID: {venta.Id}");
        Console.WriteLine($"Comentarios: {venta.Comentarios}");
        Console.WriteLine($"ID de Usuario: {venta.IdUsuario}");
    }
}
void MostrarVentas()
{
    List<Venta> ventas = VentaData.ListarVenta();

    foreach (var venta in ventas)
    {
        Console.WriteLine($"ID: {venta.Id}");
        Console.WriteLine($"Comentarios: {venta.Comentarios}");
        Console.WriteLine($"ID de Usuario: {venta.IdUsuario}");
    }
}
void AltaVenta()
{
    Venta venta = new Venta();

    Console.Write("Ingrese los comentarios de la venta: ");
    venta.Comentarios = Console.ReadLine();

    Console.Write("Ingrese el ID de usuario asociado a la venta: ");
    venta.IdUsuario = Convert.ToInt32(Console.ReadLine());

    VentaData.CrearVenta(venta);
    Console.WriteLine("Se creó la venta con éxito.");
}
void ModificarVenta()
{
    Console.WriteLine("Ingrese la ID de la venta que desea modificar:");
    if (int.TryParse(Console.ReadLine(), out int idVentaAModificar))
    {
        List<Venta> ventaExistente = VentaData.ObtenerVenta(idVentaAModificar);

        if (ventaExistente.Count > 0)
        {
            Console.WriteLine("Ingrese los nuevos comentarios de la venta:");
            string nuevosComentarios = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo ID de usuario asociado a la venta:");
            if (int.TryParse(Console.ReadLine(), out int nuevoIdUsuario))
            {
                Venta ventaModificada = new Venta
                {
                    Id = idVentaAModificar,
                    Comentarios = nuevosComentarios,
                    IdUsuario = nuevoIdUsuario
                };

                VentaData.ModificarVenta(ventaModificada);
                Console.WriteLine("Venta modificada con éxito.");
            }
            else
            {
                Console.WriteLine("Error: El nuevo ID de usuario ingresado no es válido.");
            }
        }
        else
        {
            Console.WriteLine("Error: La venta con la ID especificada no existe en la base de datos.");
        }
    }
    else
    {
        Console.WriteLine("Error: Ingrese una ID de venta válida.");
    }
}
void BajaVenta()
{
    Console.WriteLine("Ingrese la ID de la venta que desea eliminar:");
    if (int.TryParse(Console.ReadLine(), out int idVentaAEliminar))
    {
        List<Venta> ventaExistente = VentaData.ObtenerVenta(idVentaAEliminar);

        if (ventaExistente.Count > 0)
        {
            Console.WriteLine("¿Está seguro de que desea eliminar esta venta? (S/N)");
            string confirmacion = Console.ReadLine().Trim().ToUpper();

            if (confirmacion == "S")
            {
                Venta ventaAEliminar = new Venta { Id = idVentaAEliminar };

                VentaData.EliminarVenta(ventaAEliminar);
                Console.WriteLine("Venta eliminada con éxito.");
            }
            else
            {
                Console.WriteLine("Eliminación cancelada.");
            }
        }
        else
        {
            Console.WriteLine("Error: La venta con la ID especificada no existe en la base de datos.");
        }
    }
    else
    {
        Console.WriteLine("Error: Ingrese una ID de venta válida.");
    }
}
// Fin Funciones Venta

// Inicio Funciones ProductoVendido
void MenuProductoVendido()
{
    Console.WriteLine("-----------------------------------------" +
        "\n Menu Producto Vendido " +
        "\n 1: Mostrar un Producto Vendido" +
        "\n 2: Mostrar todos los Productos Vendidos" +
        "\n 3: Agregar un Producto Vendido" +
        "\n 4: Modificar un Producto Vendido" +
        "\n 5: Borrar un Producto Vendido" +
        "\n 6: Salir" +
        "\n-----------------------------------------");
    string op = Console.ReadLine();
    switch (op)
    {
        case "1":
            MostrarProductoVendido();
            MenuProductoVendido();
            break;
        case "2":
            MostrarProductosVendidos();
            MenuProductoVendido();
            break;
        case "3":
            AltaProductoVendido();
            MenuProductoVendido();
            break;
        case "4":
            ModificarProductoVendido();
            MenuProductoVendido();
            break;
        case "5":
            BajaProductoVendido();
            MenuProductoVendido();
            break;
        case "6":
            Menu();
            break;
        default:
            Console.WriteLine("La opción ingresada es incorrecta");
            MenuProductoVendido();
            break;
    }
}
void MostrarProductoVendido()
{
    Console.WriteLine("Ingrese un ID para mostrar el Producto Vendido respectivo:");
    int Id = Convert.ToInt32(Console.ReadLine());
    List<ProductoVendido> productosVendidos = ProductoVendidoData.ObtenerProductoVendido(Id);

    foreach (var productoVendido in productosVendidos)
    {
        Console.WriteLine($"ID: {productoVendido.Id}");
        Console.WriteLine($"Stock: {productoVendido.Stock}");
        Console.WriteLine($"ID del Producto: {productoVendido.IdProducto}");
        Console.WriteLine($"ID de la Venta: {productoVendido.IdVenta}");
    }
}
void MostrarProductosVendidos()
{
    List<ProductoVendido> productosVendidos = ProductoVendidoData.ListarProductoVendido();

    foreach (var productoVendido in productosVendidos)
    {
        Console.WriteLine($"ID: {productoVendido.Id}");
        Console.WriteLine($"Stock: {productoVendido.Stock}");
        Console.WriteLine($"ID del Producto: {productoVendido.IdProducto}");
        Console.WriteLine($"ID de la Venta: {productoVendido.IdVenta}");
    }
}
void AltaProductoVendido()
{
    ProductoVendido productoVendido = new ProductoVendido();

    Console.Write("Ingrese el stock del Producto Vendido: ");
    productoVendido.Stock = Convert.ToInt32(Console.ReadLine());

    Console.Write("Ingrese el ID del Producto: ");
    productoVendido.IdProducto = Convert.ToInt32(Console.ReadLine());

    Console.Write("Ingrese el ID de la Venta: ");
    productoVendido.IdVenta = Convert.ToInt32(Console.ReadLine());

    ProductoVendidoData.CrearProductoVendido(productoVendido);
    Console.WriteLine("Se creó el Producto Vendido con éxito.");
}
void ModificarProductoVendido()
{
    Console.WriteLine("Ingrese la ID del Producto Vendido que desea modificar:");
    if (int.TryParse(Console.ReadLine(), out int idProductoVendidoAModificar))
    {
        List<ProductoVendido> productoVendidoExistente = ProductoVendidoData.ObtenerProductoVendido(idProductoVendidoAModificar);

        if (productoVendidoExistente.Count > 0)
        {
            Console.WriteLine("Ingrese el nuevo stock del Producto Vendido:");
            int nuevoStock = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el nuevo ID del Producto:");
            int nuevoIdProducto = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el nuevo ID de la Venta:");
            int nuevoIdVenta = Convert.ToInt32(Console.ReadLine());

            ProductoVendido productoVendidoModificado = new ProductoVendido
            {
                Id = idProductoVendidoAModificar,
                Stock = nuevoStock,
                IdProducto = nuevoIdProducto,
                IdVenta = nuevoIdVenta
            };

            ProductoVendidoData.ModificarProductoVendido(productoVendidoModificado);
            Console.WriteLine("Producto Vendido modificado con éxito.");
        }
        else
        {
            Console.WriteLine("Error: El Producto Vendido con la ID especificada no existe en la base de datos.");
        }
    }
    else
    {
        Console.WriteLine("Error: Ingrese una ID válida.");
    }
}
void BajaProductoVendido()
{
    Console.WriteLine("Ingrese la ID del Producto Vendido que desea eliminar:");
    if (int.TryParse(Console.ReadLine(), out int idProductoVendidoAEliminar))
    {
        List<ProductoVendido> productoVendidoExistente = ProductoVendidoData.ObtenerProductoVendido(idProductoVendidoAEliminar);

        if (productoVendidoExistente.Count > 0)
        {
            Console.WriteLine("¿Está seguro de que desea eliminar este Producto Vendido? (S/N)");
            string confirmacion = Console.ReadLine().Trim().ToUpper();

            if (confirmacion == "S")
            {
                ProductoVendido productoVendidoAEliminar = new ProductoVendido { Id = idProductoVendidoAEliminar };

                ProductoVendidoData.EliminarProductoVendido(productoVendidoAEliminar);
                Console.WriteLine("Producto Vendido eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("Eliminación cancelada.");
            }
        }
        else
        {
            Console.WriteLine("Error: El Producto Vendido con la ID especificada no existe en la base de datos.");
        }
    }
    else
    {
        Console.WriteLine("Error: Ingrese una ID válida.");
    }
}
// Fin Funciones ProductoVendido