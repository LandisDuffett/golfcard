using System;
using golfcard.Models;

namespace golfcard
{
  class App
  {
    Game game;
    Boolean active;
    public void Run()
    {
      game = new Game();
      active = true;
      Console.Clear();
      Console.WriteLine("Please Select a course:");
      game.PrintCourses();
      Console.WriteLine("Course: ");
      string choice = Console.ReadLine();
      game.SelectCourse(choice);
      GamePlay();
    }
    public void GamePlay()
    {
      game.HoleByHole();
      game.WrapUp();
    }
  }
}