using E3Starter.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3Starter.Contracts.Services
{
    public interface IReferenceService
    {
        Task<List<RoleDto>> GetRolesAsync();
    }
}
