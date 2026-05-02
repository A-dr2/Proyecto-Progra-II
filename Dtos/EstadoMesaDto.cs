using Proyecto_Progra_II.Entities;


namespace Proyecto_Progra_II.Dtos
    {
        public class EstadoMesaDto
        {
            public DateTime? FechaInicio { get; set; }
            public DateTime? FechaFin { get; set; }
            public string? Motivo { get; set; }
            public TipoBloqueo TipoBloqueo { get; set; }
        }
    }


