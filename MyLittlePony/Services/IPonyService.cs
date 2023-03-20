
using MyLittlePony.Models;

namespace MyLittlePony.Services;
public interface IPonyService
{
    List<Pony> GetPonys();
    List<Tipo> GetTipos();
    Pony GetPony(int Numero);
    PonyDto GetPonyDto();
    DetailsDto GetDetailedPony(int Numero);
    Tipo GetTipo(string Nome);
}