using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Handlers;
using MediatR;
using Questao5.Application.Queries.Requests;

namespace Questao5.Infrastructure.Services.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MovimentacaoController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromServices] IMediator mediator,
                                                [FromBody]CreateMovimentoRequest command)
        {

            CreateMovimentoResponse result = null;
            try
            {
                result = await mediator.Send(command);

                return Ok(result.IdMovimento);

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message});
            }
            
        }


        [HttpGet]
        public async Task<IActionResult> GetSaldo([FromServices]IMediator mediator,
                                                  int NumeroConta)
        {
            try
            {
                SaldoRequest query = new SaldoRequest() { Numero = NumeroConta };
                var result = await mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
