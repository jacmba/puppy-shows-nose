public interface IGame {
  void Tick();
  IDifficulty GetDifficulty();
  int GetGameTime();
  int GetPuppyTime();
}
