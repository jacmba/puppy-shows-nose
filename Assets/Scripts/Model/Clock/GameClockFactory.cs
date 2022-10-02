using System.Collections;
using System.Collections.Generic;

public class GameClockFactory : IClockFactory
{
  private int time;

  public GameClockFactory(int time) {
    this.time = time;
  }

  public IClock GetClock() {
    return new GameClock(time);
  }
}
