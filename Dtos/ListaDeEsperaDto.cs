using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Dtos
{
  
        public class ListaDeEsperaDto
        {
            public int CantidadPersonas { get; set; }
            public int ClienteId { get; set; }
            public string? Comentarios { get; set; }
            public EstadoListaEspera Estado { get; set; }
        }

    }

