using AutoMapper;
using E3Starter.Contracts.Persistence;
using E3Starter.Contracts.Services;
using E3Starter.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3Starter.Services
{
    public class ReferenceService : IReferenceService
    {
        private readonly IMapper _mapper;
        private readonly IReferenceRepository _referenceRepository;

        public ReferenceService(IMapper mapper, IReferenceRepository referenceRepository)
        {
            _mapper = mapper;
            _referenceRepository = referenceRepository;
        }

        public async Task<List<RoleDto>> GetRolesAsync()
        {
            var roles = await _referenceRepository.GetRolesAsync();
            return _mapper.Map<List<RoleDto>>(roles);
        }
    }
}
