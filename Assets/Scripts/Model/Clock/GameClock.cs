using System.Collections;
using System.Collections.Generic;

public class GameClock : AbstractClock
{
  public GameClock(int time) : base(time) { }

  public new void Tick() {
    base.Tick();

    // ToDo call GameEnd event when timer is 0
  }
}
