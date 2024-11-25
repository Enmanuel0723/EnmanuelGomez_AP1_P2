using System.ComponentModel.DataAnnotations;

namespace EnmanuelGomez_AP1_P2.Model;


public class ArticulosCombos
{
    [Key]
    public int ArticuloId { get; set; }

    [Required(ErrorMessage = "La Descripcion no puede estar en blanco")]

    public required string Descripcion { get; set; }


    public double Costo { get; set; }

    public double Precio { get; set; }

    public int Existencia { get; set; }
}