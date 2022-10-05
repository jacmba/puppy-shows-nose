public interface IGame {
  void Tick();
  void Tick(bool updateTime);
  IDifficulty GetDifficulty();
  int GetGameTime();
  int GetPuppyTime();
  GameStateType GetState();
  void OnPlay();
  void OnPauseToggle();
  void OnWin();
  void OnLose();
  void ResetTimer();
  IShoppingList GetShoppingList();
}
