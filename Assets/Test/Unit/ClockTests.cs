using NUnit.Framework;

public class ClockTests
{
  [Test]
  public void ClockTestGameClock() {
    IClockAbstractFactory abstractFactory = new ClockAbstractFactory(1);
    IClockFactory factory = abstractFactory.GetFactory(ClockType.GAME);
    IClock clock = factory.GetClock();

    Assert.AreEqual(1, clock.GetTime());
    clock.Tick();
    Assert.AreEqual(0, clock.GetTime());
    clock.Tick();
    Assert.AreEqual(0, clock.GetTime());
  }

  [Test]
  public void ClockTestPuppyClock() {
    IClockAbstractFactory abstractFactory = new ClockAbstractFactory(0);
    IClockFactory factory = abstractFactory.GetFactory(ClockType.PUPPY);
    IClock clock = factory.GetClock();

    Assert.AreEqual(10, clock.GetTime());
    for(int i = 0; i < 20; i++) {
      clock.Tick();
    }
    Assert.AreEqual(0, clock.GetTime());
  }
}
