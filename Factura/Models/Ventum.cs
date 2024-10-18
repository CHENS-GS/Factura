using System;
using System.Collections.Generic;

namespace Factura.Models;

public partial class Ventum
{
    public int IdVenta { get; set; }

    public int IdFactura { get; set; }

    public string IdProducto { get; set; } = null!;

    public decimal Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Igv { get; set; }

    public decimal Importe { get; set; }

    public DateTime FechaEmision { get; set; }

    public virtual Factura IdFacturaNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
