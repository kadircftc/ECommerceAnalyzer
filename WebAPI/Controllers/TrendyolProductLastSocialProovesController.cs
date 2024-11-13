
using Business.Handlers.TrendyolProductLastSocialProoves.Commands;
using Business.Handlers.TrendyolProductLastSocialProoves.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Entities.Concrete;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    /// <summary>
    /// TrendyolProductLastSocialProoves If controller methods will not be Authorize, [AllowAnonymous] is used.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TrendyolProductLastSocialProovesController : BaseApiController
    {
        ///<summary>
        ///List TrendyolProductLastSocialProoves
        ///</summary>
        ///<remarks>TrendyolProductLastSocialProoves</remarks>
        ///<return>List TrendyolProductLastSocialProoves</return>
        ///<response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TrendyolProductLastSocialProof>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await Mediator.Send(new GetTrendyolProductLastSocialProovesQuery());
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        ///<summary>
        ///It brings the details according to its id.
        ///</summary>
        ///<remarks>TrendyolProductLastSocialProoves</remarks>
        ///<return>TrendyolProductLastSocialProoves List</return>
        ///<response code="200"></response>  
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TrendyolProductLastSocialProof))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetTrendyolProductLastSocialProofQuery { Id = id });
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        /// <summary>
        /// Add TrendyolProductLastSocialProof.
        /// </summary>
        /// <param name="createTrendyolProductLastSocialProof"></param>
        /// <returns></returns>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTrendyolProductLastSocialProofCommand createTrendyolProductLastSocialProof)
        {
            var result = await Mediator.Send(createTrendyolProductLastSocialProof);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        /// <summary>
        /// Update TrendyolProductLastSocialProof.
        /// </summary>
        /// <param name="updateTrendyolProductLastSocialProof"></param>
        /// <returns></returns>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTrendyolProductLastSocialProofCommand updateTrendyolProductLastSocialProof)
        {
            var result = await Mediator.Send(updateTrendyolProductLastSocialProof);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        /// <summary>
        /// Delete TrendyolProductLastSocialProof.
        /// </summary>
        /// <param name="deleteTrendyolProductLastSocialProof"></param>
        /// <returns></returns>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteTrendyolProductLastSocialProofCommand deleteTrendyolProductLastSocialProof)
        {
            var result = await Mediator.Send(deleteTrendyolProductLastSocialProof);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
