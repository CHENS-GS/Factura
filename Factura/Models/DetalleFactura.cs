using System;
using System.Collections.Generic;

namespace Factura.Models;

public partial class DetalleFactura
{
    public int IdDetalleFactura { get; set; }

    public int IdFactura { get; set; }

    public string CodigoProducto { get; set; } = null!;

    public int Cantidad { get; set; }

    public decimal ValorUnitario { get; set; }

    public decimal Igv { get; set; }

    public decimal ImporteTotal { get; set; }

    public virtual Producto CodigoProductoNavigation { get; set; } = null!;

    public virtual Factura IdFacturaNavigation { get; set; } = null!;
}
