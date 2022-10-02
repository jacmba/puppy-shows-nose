using System.Collections;
using System.Collections.Generic;

public abstract class AbstractClock : IClock
{
  protected int time;

  public AbstractClock(int time) {
    this.time = time;
  }

  public virtual void Tick() {
    if(time > 0) {
      time--;
    }
  }

  public int GetTime() {
    return time;
  }
}
