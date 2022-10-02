using System.Collections;
using System.Collections.Generic;

public class PuppyClock : AbstractClock
{
  public PuppyClock() : base(10) { }

  public override void Tick() {
    base.Tick();

    if (time <= 0) {
      EventBus.PuppyShown();
    }
  }
}
