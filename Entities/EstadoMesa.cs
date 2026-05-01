namespace Proyecto_Progra_II.Entities
{
    public class EstadoMesa
    {
        public int Id { get; set; }
        public enum TipoBloqueo
        {
            Mantenimiento,
            EventoEspecial,
            Reserva
        }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public required string Motivo { get; set; }



        //???  public List<ListaDeEspera> ListasDeEspera { get; set; } = null!;

        /*  public class EstadoMesa
          {
              public int Id { get; set; }
                                                                        // Este funcionaria para estados personalisados, pero no es necesario si tienes una idea distinta
              public string Nombre { get; set; } = "";
              // Ej: Disponible, Ocupada, Bloqueada, Mantenimiento
          } */
    }
}
