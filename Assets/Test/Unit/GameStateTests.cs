using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

public class GameStateTests
{
  [Test]
  public void TestGameStateShouldReturnNullCurrentState() {
    IStateMachine machine = new GameStateMachine();
    IState state = machine.CurrentState();

    Assert.IsNull(state);
  }

  [Test]
  public void TestGameStateAddTransitionShouldAddDefaultStateIfNone() {
    IStateMachine machine = new GameStateMachine();
    machine.AddTransition(new GameState(GameStateType.INTRO), new GameState(GameStateType.PLAYING), () => true);
    GameState state = (GameState)machine.CurrentState();

    Assert.IsNotNull(state);
    Assert.AreEqual(GameStateType.INTRO, state.GetState());
  }

  [Test]
  public void TestGameStateShouldAlwaysTransitionToNextState() {
    IStateMachine machine = new GameStateMachine();
    IState introState = new GameState(GameStateType.INTRO);
    IState playState = new GameState(GameStateType.PLAYING);
    IState winState = new GameState(GameStateType.WIN);
    machine.AddTransition(introState, playState, () => true);
    machine.AddTransition(playState, winState, () => true);
    machine.Tick();

    GameState state = (GameState)machine.CurrentState();

    Assert.IsNotNull(state);
    Assert.AreEqual(GameStateType.PLAYING, state.GetState());

    machine.Tick();
    state = (GameState)machine.CurrentState();

    Assert.IsNotNull(state);
    Assert.AreEqual(GameStateType.WIN, state.GetState());
  }

  [Test]
  public void TestGameStateShouldNeverTransitionToNextState() {
    IStateMachine machine = new GameStateMachine();
    machine.AddTransition(new GameState(GameStateType.INTRO), new GameState(GameStateType.PLAYING), () => false);
    machine.Tick();
    GameState state = (GameState)machine.CurrentState();

    Assert.IsNotNull(state);
    Assert.AreEqual(GameStateType.INTRO, state.GetState());
  }
}
