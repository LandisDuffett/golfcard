using System;

namespace golfcard.Models
{
  class Player
  {
    public string Name { get; set; }
    public int Score { get; set; }
    public void addScore(int round)
    {
      Score += round;
    }

    public Player(string name)
    {
      Name = name;
      Score = 0;
    }
  }
}
