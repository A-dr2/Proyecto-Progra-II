using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IHorarioServices
    {
        public List<Horarios> GetHorarios();
            public Horarios GetHorarioById(int id);
            public Horarios CreateHorario(Horarios horario);
            public Horarios UpdateHorario(int id, Horarios horario);
            public void DeleteHorario(int id);
    }
}
