using AutoMapper;
using taller_mecanico.Domain.DTOs;
using taller_mecanico.Filters;
using taller_mecanico.Service.Command;
using taller_mecanico.Service.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Service.Command;

namespace taller_mecanico.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ServiceFilter(typeof(LanguageFilter))]
        [ServiceFilter(typeof(ModelValidationAttributeFilter))]
        [HttpPost("create")]
        public async Task<ActionResult> Create(CustomerDTO model)
        {
            CultureInfo.CurrentUICulture = HttpContext.Items["Lang"] as CultureInfo;
            var createCommand = new CreateCustomerCommand { CustomerDTO = model };
            var response = await _mediator.Send(createCommand);
            return Created($"/api/get/{response.Id}", response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("all/{currentPage}/{itemByPage}")]
        public async Task<ActionResult> All(int currentPage, int itemByPage)
        {
            try
            {
                var response = await _mediator.Send(new GetAllCustomer()
                {
                    CurrentPage = currentPage,
                    ItemByPage = itemByPage
                });
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ErrorMessage = ex.Message });
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("customer-by-id/{id}")]
        public async Task<ActionResult> CustomerById(Guid id)
        {
            try
            {
                var getByIdQuery = new GetCustomerByIdQuery { Id = id };
                var response = await _mediator.Send(getByIdQuery);
                return Ok(response);
            }
            catch (Exception ex)
            {
                if (ex is KeyNotFoundException)
                    return NotFound(new { ErrorMessage = ex.Message });
                else
                    return StatusCode(500, new { ErrorMessage = ex.Message });
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var deleteCommand = new DeleteCustomerCommand { Id = id };
                var response = await _mediator.Send(deleteCommand);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex is KeyNotFoundException)
                    return NotFound(new { ErrorMessage = ex.Message });
                else
                    return StatusCode(500, new { ErrorMessage = ex.Message });
            }
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(Guid id, CustomerDTO model)
        {
            try
            {
                var updateCommand = new UpdateCustomerCommand
                {
                    Customer = model,
                    Id = id
                };
                var response = await _mediator.Send(updateCommand);
                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex is KeyNotFoundException)
                    return NotFound(new { ErrorMessage = ex.Message });
                else
                    return StatusCode(500, new { ErrorMessage = ex.Message });
            }
        }
    }
}
