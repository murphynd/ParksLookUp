using System;
namespace ParksLookUp.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public string Desc { get; set; }
    public DateTime Date { get; set; }

    public int Rating { get; set; }
  }
}