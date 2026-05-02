

using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Dtos
{
 
        public class ReservaDto
        {
            public DateTime Fecha { get; set; }
            public int CantidadPersonas { get; set; }
            public int ClienteId { get; set; }
            public int? ListaDeEsperaId { get; set; }
            public int EstadoReservaId { get; set; }
            public EstadoReserva EstadoReserva { get; set; }
        }
    
}