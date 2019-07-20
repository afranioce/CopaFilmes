using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCup.Shared.Commands;
using System;
using System.Collections.Generic;

namespace MovieCup.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected new IActionResult Response(object result = null)
        {

            try
            {
                if (result == null)
                {
                    return NoContent();
                }
                else if (result is ValidationFailureEvent)
                {
                    NotifyModelStateErrors((result as ValidationFailureEvent).Failures);
                    return ValidationProblem();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        private void NotifyModelStateErrors(IEnumerable<ValidationFailure> failures)
        {
            foreach (var error in failures)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}