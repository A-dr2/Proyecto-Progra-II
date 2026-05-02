using Proyecto_Progra_II.Entities;

public class Mesa
{
    public int Id { get; set; }
    public int Capacidad { get; set; }
    public int ZonaId { get; set; }

    public int EstadoMesaId { get; set; }
    public EstadoMesa EstadoMesa { get; set; } = null!;

}