using System.Collections;
using System.Collections.Generic;

public class Game : IGame {
  private IOption option;
  private IClock gameClock;
  private IClock puppyClock;
  private IStateMachine fsm;

  private bool isPlaying = false;
  private bool isPaused = false;
  private bool isWon = false;
  private bool isLost = false;

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

      IClockAbstractFactory clockAbstractFactory = new ClockAbstractFactory(option.GetDifficulty().GetTimeLimit());
      IClockFactory gameClockFactory = clockAbstractFactory.GetFactory(ClockType.GAME);
      IClockFactory puppyClockFactory = clockAbstractFactory.GetFactory(ClockType.PUPPY);
      game.gameClock = puppyClockFactory.GetClock();
      game.puppyClock = puppyClockFactory.GetClock();

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
}
