using System.Collections;
using System.Collections.Generic;

public class GameClock : AbstractClock
{
  public GameClock(int time) : base(time) { }

  public override void Tick() {
    base.Tick();

    if (time <= 0) {
      EventBus.GameEnd();
    }
  }
}
