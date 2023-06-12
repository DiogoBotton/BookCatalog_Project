using BookCatalogAPI_Domains.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookCatalogAPI.Helpers.Utils
{
    public class ControllerBaseAPI : ControllerBase
    {
        protected ObjectResult VerifyResponse(ReturnBaseClass result)
        {
            if (result.Status)
                return Ok(result);
            else
                return StatusCode((int)result.StatusCode != 0 ? (int)result.StatusCode : (int)HttpStatusCode.InternalServerError, result.Message);
        }
    }
}
