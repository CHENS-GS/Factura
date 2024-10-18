using System;
using System.Collections.Generic;

namespace Factura.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public string NumeroFactura { get; set; } = null!;

    public string Ruc { get; set; } = null!;

    public string RazonSocial { get; set; } = null!;

    public DateTime FechaEmision { get; set; }

    public decimal Total { get; set; }

    public decimal Subtotal { get; set; }

    public decimal MontoIgv { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
