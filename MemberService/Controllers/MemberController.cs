using Microsoft.AspNetCore.Mvc;
using MemberService.Models;
using System.Diagnostics;
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
        },
         new () {
        Id = new Guid("c9fcbc4b-d2d1-4664-9079-dae78a1de555"),
        Name = "August",
        Address1 = "Søndergade 3",
        City = "Harboøre",
        PostalCode = 7673,
        ContactName = "Jens Peter Olesen",
        TaxNumber = "133466789"
        },
         new () {
        Id = new Guid("c9fcbc4b-d2d1-4664-9079-dae78a1de669"),
        Name = "Welat",
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

      [HttpGet]
    public IEnumerable<Member> Get()
    {
        return _members;
    }
    

   [HttpGet("{customerId}", Name = "GetCustomerById")]
    public Member Get(Guid customerId)
    {
    return _members.Where(c => c.Id == customerId).First();
    }

    [HttpGet("version")]
    public async Task<Dictionary<string, string>> GetVersion()
    {
        var properties = new Dictionary<string, string>();
        var assembly = typeof(Program).Assembly;
        properties.Add("service", "qgt-customer-service");
        var ver = FileVersionInfo.GetVersionInfo(typeof(Program)
        .Assembly.Location).ProductVersion;
        properties.Add("version", ver!);
        try
        {
            var hostName = System.Net.Dns.GetHostName();
            var ips = await System.Net.Dns.GetHostAddressesAsync(hostName);
            var ipa = ips.First().MapToIPv4().ToString();
            properties.Add("hosted-at-address", ipa);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            properties.Add("hosted-at-address", "Could not resolve IP-address");
        }

        return properties;
    }
