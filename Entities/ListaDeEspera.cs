namespace Proyecto_Progra_II.Entities
{
    public class ListaDeEspera
    {
        public int Id { get; set; }
        
        public int CantidadPersonas { get; set; }
        public DateTime FechaSolicitud { get; set; }

        public int ClienteId { get; set; }
        public List<Turno> Turnos { get; set; } = null!;
    }
}
