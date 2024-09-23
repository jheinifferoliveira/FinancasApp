using FinancasApp.Domain.Contracts.Repositories;
using FinancasApp.Domain.Contracts.Security;
using FinancasApp.Domain.Contracts.Services;
using FinancasApp.Domain.Helpers;
using FinancasApp.Domain.Models.Dtos;
using FinancasApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IJwtTokenService _jwtTokenService;

        public UsuarioDomainService(IUsuarioRepository usuarioRepository, IJwtTokenService jwtTokenService)
        {
            _usuarioRepository = usuarioRepository;
            _jwtTokenService = jwtTokenService;
        }

        public AutenticarUsuarioResponseDto Autenticar(AutenticarUsuarioRequestDto request)
        {
            var usuario=_usuarioRepository.Get(request.Email,CryptoHelper.GetSHA256(request.Senha));

            if (usuario == null)
            {
                throw new ApplicationException("Acesso negado. Usuário não encontrado.");
            }

            var response = new AutenticarUsuarioResponseDto()
            {
                Id=usuario.Id,
                Nome=usuario.Nome,
                Email=usuario.Email,
                Token=_jwtTokenService.GetJwtToken(usuario),
                DataHoraAcesso=DateTime.Now
            };
            return response;
        }

        public CriarUsuarioResponseDto Criar(CriarUsuarioRequestDto request)
        {
            if(_usuarioRepository.Get(request.Email) != null)
            {
                throw new ApplicationException("O email informado já está cadastrado. Tente outro.");
            }
            var usuario = new Usuario()
            {
                Id=Guid.NewGuid(),
                Nome=request.Nome,
                Email=request.Email,
                Senha=CryptoHelper.GetSHA256(request.Senha)
            };
            _usuarioRepository.Add(usuario);

            var response = new CriarUsuarioResponseDto()
            {
                Id=usuario.Id,
                Nome=usuario.Nome,
                Email=usuario.Email,
                DataHoraCadastro=DateTime.Now
            };
            return response;
        }
    }
}
