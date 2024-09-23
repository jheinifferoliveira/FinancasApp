using AutoMapper;
using FinancasApp.Domain.Contracts.Repositories;
using FinancasApp.Domain.Contracts.Services;
using FinancasApp.Domain.Models.Dtos;
using FinancasApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Services
{
    public class CategoriaDomainService : ICategoriaDomainService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaDomainService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public CategoriaResponseDto Alterar(Guid id, CategoriaRequestDto request)
        { 
            var categoria= _categoriaRepository.GetById(id);
            if(categoria == null)
            {
                throw new ApplicationException("A categoria não foi encontrada. Verifique o ID informado.");
            }
            _mapper.Map(request, categoria);
            _categoriaRepository.Update(categoria);

            var response=_mapper.Map<CategoriaResponseDto>(categoria);
            return response;
        }

        public List<CategoriaResponseDto> Consultar(Guid usuarioId)
        {
            var categorias=_categoriaRepository.Get(usuarioId);
            var response=_mapper.Map<List<CategoriaResponseDto>>(categorias);
            return response;
        }

        public CategoriaResponseDto Criar(CategoriaRequestDto request, Guid usuarioId)
        {
            var categoria = _mapper.Map<Categoria>(request);
            categoria.Id=Guid.NewGuid();
            categoria.UsuarioId=usuarioId;


            _categoriaRepository.Add(categoria);

            var response = _mapper.Map<CategoriaResponseDto>(categoria);
            return response;
            
        }

        public CategoriaResponseDto Excluir(Guid id)
        {
            var categoria = _categoriaRepository.GetById(id);
            if(categoria == null)
            {
                throw new ApplicationException("Categoria não encontrada.Verifique o ID informado.");
            }
            _categoriaRepository.Delete(categoria);

            var response = _mapper.Map<CategoriaResponseDto>(categoria);
            return response;
        }

        public CategoriaResponseDto? ObterPorId(Guid id)
        {
            var categoria = _categoriaRepository.GetById(id);
            if (categoria == null)
            {
                throw new ApplicationException("Categoria não encontrada.Verifique o ID informado.");

            }
            var response = _mapper.Map<CategoriaResponseDto>(categoria);
            return response;
        }
    }
}
