using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Company
{
    [Key]
    public int CompanyId { get; set; }
    [Required]
    public string CompanyName { get; set; }
    [Required]
    public string ContactPersonName { get; set; }
    public string ContactPersonEmail { get; set; }

    public List<ServiceRequest> RequiredServices {get; set;}
}