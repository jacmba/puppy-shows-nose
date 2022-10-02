public class ClockAbstractFactory : IClockAbstractFactory
{
  private int gameTime;

  public ClockAbstractFactory(int gameTime) {
    this.gameTime = gameTime;
  }

  public IClockFactory GetFactory(ClockType type) {
    switch (type) {
      case ClockType.GAME:
        return new GameClockFactory(gameTime);
      case ClockType.PUPPY:
        return new PuppyClockFactory();
      default:
        return null;
    }
  }
}
