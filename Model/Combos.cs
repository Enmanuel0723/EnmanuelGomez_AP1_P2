namespace EnmanuelGomez_AP1_P2.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Combos
{
    [Key]
    public int ComboId { get; set; }

    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "La descripcion no puede estar en blanco")]
    public string Descripcion { get; set; }

    public double Precio { get; set; }

    public bool Vendido { get; set; } = false;

    [ForeignKey("ComboId")]
    public ICollection<CombosDetalles> CombosDetalle { get; set; } = new List<CombosDetalles>();
}
