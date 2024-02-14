using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class BuggyController : BaseApiController
{
    private DataContext _dataContext;
    public BuggyController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [Authorize]
    [HttpGet("auth")]
    public ActionResult<string> GetSecret()
    {
        return "some secret text";
    }

    [HttpGet("not-found")]
    public ActionResult<string> GetNotFound()
    {
        var thing = _dataContext.Users.Find(-1);
        if(thing == null)
        {
            return NotFound();
        }
        return Ok(thing);
    }

    [HttpGet("server-error")]
    public ActionResult<string> GetServerError()
    {
        var thing = _dataContext.Users.Find(-1);
        var thingToReturn = thing.ToString();
        return thingToReturn;
    }

    [HttpGet("bad-request")]
    public ActionResult<string> GetBadRequest()
    {
        return BadRequest("bad request.");
    }
}
