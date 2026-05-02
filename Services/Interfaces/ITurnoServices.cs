using Proyecto_Progra_II.Entities;

namespace Proyecto_Progra_II.Services.Interfaces
{
    public interface ITurnoServices
    {
        public List<Turno> GetAll();
        public Turno GetById(int id);
    }
}
