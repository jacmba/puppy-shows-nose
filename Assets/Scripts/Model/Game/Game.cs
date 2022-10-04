using System.Collections;
using System.Collections.Generic;

public class Game : IGame {
  private IOption option;
  private IClockAbstractFactory clockAbstractFactory;
  private IClock gameClock;
  private IClock puppyClock;
  private IStateMachine fsm;

  private bool isPlaying = false;
  private bool isPaused = false;
  private bool isWon = false;
  private bool isLost = false;

  private IShoppingList shoppingList;

  private Game() {}

  public class GameBuilder {
    private IOption option;

    public GameBuilder Option(IOption option) {
      this.option = option;
      return this;
    }

    public Game Build() {
      Game game = new Game();
      game.option = option;

      game.clockAbstractFactory = new ClockAbstractFactory(option.GetDifficulty().GetTimeLimit());
      IClockFactory gameClockFactory = game.clockAbstractFactory.GetFactory(ClockType.GAME);
      IClockFactory puppyClockFactory = game.clockAbstractFactory.GetFactory(ClockType.PUPPY);
      game.gameClock = gameClockFactory.GetClock();
      game.puppyClock = puppyClockFactory.GetClock();

      var shoppingListBuilder = new ShoppingList.ShoppingListBuilder();
      game.shoppingList = shoppingListBuilder
        .Size(option.GetDifficulty().GetListSize())
        .Build();

      game.fsm = new GameStateMachine();

      IState introState = new GameState(GameStateType.INTRO);
      IState playState = new GameState(GameStateType.PLAYING);
      IState pauseState = new GameState(GameStateType.PAUSED);
      IState winState = new GameState(GameStateType.WIN);
      IState loseState = new GameState(GameStateType.LOSE);

      game.fsm.AddTransition(introState, playState, () => game.isPlaying);
      game.fsm.AddTransition(playState, pauseState, () => game.isPaused);
      game.fsm.AddTransition(playState, winState, () => game.isWon);
      game.fsm.AddTransition(playState, loseState, () => game.isLost);
      game.fsm.AddTransition(pauseState, playState, () => !game.isPaused);

      return game;
    }
  }

  public void Tick() {
    gameClock.Tick();
    puppyClock.Tick();
    fsm.Tick();
  }

  public IDifficulty GetDifficulty() {
    return option.GetDifficulty();
  }

  public int GetGameTime() {
    return gameClock.GetTime();
  }

  public int GetPuppyTime() {
    return puppyClock.GetTime();
  }

  public GameStateType GetState() {
    var gameState = (GameState)fsm.CurrentState();
    return gameState.GetState();
  }

  public void OnPlay() {
    isPlaying = true;
  }

  public void OnPauseToggle() {
    isPaused = !isPaused;
  }

  public void OnWin() {
    isWon = true;
  }

  public void OnLose() {
    isLost = true;
  }

  public void ResetTimer() {
    IClockFactory factory = clockAbstractFactory.GetFactory(ClockType.PUPPY);
    puppyClock = factory.GetClock();
  }

  public IShoppingList GetShoppingList() {
    return shoppingList;
  }
}
