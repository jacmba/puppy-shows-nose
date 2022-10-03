public interface IGame {
  void Tick();
  IDifficulty GetDifficulty();
  int GetGameTime();
  int GetPuppyTime();
  GameStateType GetState();
  void OnPlay();
  void OnPauseToggle();
  void OnWin();
  void OnLose();
  void ResetTimer();
}
