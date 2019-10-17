using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.TemplateFeature.Commands;
using Application.TemplateFeature.Queries;
using Application.TemplateFeature.Queries.GetTemplateAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class TemplateController : BaseController
    {
        [HttpGet("")]
        public async Task<ActionResult<TemplateAllVm>> GetAll()
        {
            return Ok(await Mediator.Send(new GetTemplateAllQuery()));
        }

        [HttpPost("")]
        public async Task<ActionResult> Create([FromBody] CreateTemplateEntityCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }
    }
}
