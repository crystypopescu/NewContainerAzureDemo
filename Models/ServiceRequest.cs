using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class ServiceRequest
{
    [Key]
    public int ServiceRequestId { get; set; }
    [Required]
    public int CompanyId { get; set; }
    [ForeignKey("CompanyId")]
    public Company Company {get; set;}
    public string ServicesNeeded { get; set; }
    public int Duration { get; set; }
    public DateTime TimeLimit { get; set; }
}