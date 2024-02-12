using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberService.Models
{
    public class Member
    {
       public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public short PostalCode { get; set; }
    public string? City { get; set; }
    public string? ContactName { get; set; }
    public string? TaxNumber { get; set; } 
    }
}