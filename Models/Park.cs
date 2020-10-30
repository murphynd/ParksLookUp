using System;
using System.ComponentModel.DataAnnotations;
namespace ParksLookUp.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Location { get; set; }
    [Required]
    public string Desc { get; set; }
    [Required]
    public string Kind { get; set; }
    public DateTime Date { get; set; }

    public int Rating { get; set; }
  }
}