using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface IHorarioServices
    {
        public List<Horario> GetHorarios();
            public Horario GetHorarioById(int id);
            public Horario CreateHorario(Horario horario);
            public Horario UpdateHorario(int id, Horario horario);
            public void DeleteHorario(int id);
    }
}
