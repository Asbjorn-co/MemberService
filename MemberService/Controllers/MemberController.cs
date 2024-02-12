using Microsoft.AspNetCore.Mvc;
using MemberService.Models;
using System.Linq;

namespace MemberService.Controllers;

[ApiController]
[Route("[controller]")]
public class MemberController : ControllerBase
{
   private static List<Member> _members = new List<Member>() {
        new () {
        Id = new Guid("c9fcbc4b-d2d1-4664-9079-dae78a1de446"),
        Name = "Æ Fiskehandler",
        Address1 = "Søndergade 3",
        City = "Harboøre",
        PostalCode = 7673,
        ContactName = "Jens Peter Olesen",
        TaxNumber = "133466789"
        }
    };

    private readonly ILogger<MemberController> _logger;

    public MemberController(ILogger<MemberController> logger)
    {
        _logger = logger;
    }

   [HttpGet("{customerId}", Name = "GetCustomerById")]
    public Member Get(Guid customerId)
    {
    return _members.Where(c => c.Id == customerId).First();
    }
}
