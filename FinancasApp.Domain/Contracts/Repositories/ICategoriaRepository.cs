using FinancasApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Contracts.Repositories
{
    public interface ICategoriaRepository:IBaseRepository<Categoria>
    {
        Categoria? GetById(Guid id);
        List<Categoria> Get(Guid usuarioId);
    }
}
