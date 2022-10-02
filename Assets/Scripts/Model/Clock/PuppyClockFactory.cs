using System.Collections;
using System.Collections.Generic;

public class PuppyClockFactory : IClockFactory
{
  public IClock GetClock() {
    return new PuppyClock();
  }
}
