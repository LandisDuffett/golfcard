using System;

namespace golfcard.Models
{
  class Hole
  {
    public int Order { get; set; }
    public int Par { get; set; }

    public Hole(int order, int par)
    {
      Order = order;
      Par = par;
    }
  }
}
