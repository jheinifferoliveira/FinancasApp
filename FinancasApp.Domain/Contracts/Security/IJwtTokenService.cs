using FinancasApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Contracts.Security
{
    public interface IJwtTokenService
    {
        string GetJwtToken(Usuario usuario);
    }
}
