public interface IClockAbstractFactory
{
  IClockFactory GetFactory(ClockType type);
}
