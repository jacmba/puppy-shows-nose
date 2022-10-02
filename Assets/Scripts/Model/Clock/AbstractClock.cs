using System.Collections;
using System.Collections.Generic;

public abstract class AbstractClock : IClock
{
  private int time;

  public AbstractClock(int time) {
    this.time = time;
  }

  public void Tick() {
    if(time > 0) {
      time--;
    }
  }

  public int GetTime() {
    return time;
  }
}
