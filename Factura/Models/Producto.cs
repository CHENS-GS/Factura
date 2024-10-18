using System;
using System.Collections.Generic;

namespace Factura.Models;

public partial class Producto
{
    public string IdProducto { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
