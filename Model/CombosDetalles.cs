using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnmanuelGomez_AP1_P2.Model;

public class CombosDetalles
{
    [Key]
    public int DetalleId { get; set; }

    [ForeignKey("Combos")]
    public int ComboId { get; set; }

    [ForeignKey("ArticulosCombos")]
    public int ArticuloId { get; set; }
    public int Cantidad { get; set; }
    public double Precio { get; set; }


}
