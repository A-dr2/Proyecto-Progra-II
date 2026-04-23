using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface ITurnoServices
    {
        public List<Turno> GetTurnos();
            public Turno GetTurnoById(int id);
            public Turno CreateTurno(Turno turno);
            public Turno UpdateTurno(int id, Turno turno);
            public void DeleteTurno(int id);
    }
}
