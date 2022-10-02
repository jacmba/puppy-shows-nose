using System.Collections;
using System.Collections.Generic;

public class PuppyClock : AbstractClock
{
  public PuppyClock() : base(10) { }

  public new void Tick() {
    base.Tick();

    // ToDo call PuppyShown event when time reaches 0
  }
}
