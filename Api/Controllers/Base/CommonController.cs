using System;
using System.Linq;
using System.Threading.Tasks;
using Framework.Basic;
using Framework.Core;
using Framework.Core.UOW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers.Base
{
    [Route("api/[controller]")]
    //[Authorize]
    public class CommonController : ControllerBase
    {
        protected IActionResult ResCreateOk()
        {
            return Ok();
        }

        protected IActionResult ResCreateOk(object result)
        {
            if (result != null)
                return Ok(result);
            else
                return ResCreateNotFound();
        }

        protected IActionResult ResCreateServerError(Exception ex)
        {
            return BadRequest(ex);
        }
        protected IActionResult ResCreateServerError(SaveResult saveResult)
        {
            return BadRequest(saveResult);
        }

        protected IActionResult ResCreateServerError(ModelStateDictionary modelState)
        {
            return BadRequest(modelState);
        }

        protected IActionResult ResCreateNotFound()
        {
            return NotFound();
        }

        protected object GetErrors(ModelStateDictionary modelstate)
        {
           return modelstate.Values.SelectMany(a => a.Errors).Select(a => a.ErrorMessage);
        }

       

    }
}
