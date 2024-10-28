using FinancasApp.Domain.Contracts.Services;
using FinancasApp.Domain.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancasApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {

        private readonly ICategoriaDomainService _categoriaDomainService;
        public CategoriasController(ICategoriaDomainService categoriaDomainService)
        {
            _categoriaDomainService = categoriaDomainService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CategoriaResponseDto), 201)]
        public IActionResult Post(CategoriaRequestDto request)
        {
            try
            {
                var usuarioId = Guid.Parse(User.Identity.Name);
                var retorno = _categoriaDomainService.Criar(request,usuarioId);

                return StatusCode(201, retorno);
            }
            catch (ApplicationException e)
            {

                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, CategoriaRequestDto request) 
        {
            try
            {
                var response=_categoriaDomainService.Alterar(id, request);
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {

                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var response=_categoriaDomainService.Excluir(id);
                return StatusCode(200,response);
            }
            catch (ApplicationException e)
            {

                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CategoriaResponseDto>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var usuarioId= Guid.Parse(User.Identity.Name);
                var response = _categoriaDomainService.Consultar(usuarioId);
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {

                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoriaResponseDto), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var response = _categoriaDomainService.ObterPorId(id);
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {

                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }



    }
}



