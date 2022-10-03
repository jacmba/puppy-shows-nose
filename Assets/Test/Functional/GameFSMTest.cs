using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameFSMTest {
  private GameStateType lastState;

  [SetUp]
  public void Setup() {
    EventBus.OnGameStateChanged += OnGameStateChanged;
  }

  [TearDown]
  public void TearDown() {
    EventBus.OnGameStateChanged -= OnGameStateChanged;
  }

  private void OnGameStateChanged(GameStateType state) {
    Debug.Log("Changed game state: " + state);
    lastState = state;
  }

  [UnityTest]
  public IEnumerator GameFSMTestShouldNotifyStateChanges() {
    IStateMachine machine = new GameStateMachine();
    IGameState introState = new GameState(GameStateType.INTRO);
    IGameState playState = new GameState(GameStateType.PLAYING);
    IGameState pauseState = new GameState(GameStateType.PAUSED);
    machine.AddTransition(introState, playState, () => true);
    machine.AddTransition(playState, pauseState, () => true);
    machine.Tick();

    yield return new WaitForSeconds(1);
    Assert.AreEqual(GameStateType.PLAYING, lastState);

    machine.Tick();
    yield return new WaitForSeconds(1);
    Assert.AreEqual(GameStateType.PAUSED, lastState);
  }
}
