using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ClockActionTests
{
  private IClock gameClock;
  private IClock puppyClock;
  private bool gameEnded;
  private bool puppyShown;

  [SetUp]
  public void Setup() {
    IClockAbstractFactory abstractFactory = new ClockAbstractFactory(1);
    IClockFactory gameClockFactory = abstractFactory.GetFactory(ClockType.GAME);
    IClockFactory puppyClockFactory = abstractFactory.GetFactory(ClockType.PUPPY);

    gameClock = gameClockFactory.GetClock();
    puppyClock = puppyClockFactory.GetClock();

    EventBus.OnGameEnd += OnGameEnd;
    EventBus.OnPuppyShown += OnPuppyShown;
  }

  [TearDown]
  public void TearDown() {
    EventBus.OnGameEnd -= OnGameEnd;
    EventBus.OnPuppyShown -= OnPuppyShown;
  }

  [UnityTest]
  public IEnumerator TestGameClockAction() {
    gameEnded = false;
    gameClock.Tick();
    Assert.AreEqual(0, gameClock.GetTime());
    yield return new WaitForSeconds(1);

    Assert.IsTrue(gameEnded);
  }

  [UnityTest]
  public IEnumerator TestPuppyClockAction() {
    puppyShown = false;
    
    for (int i = 10; i > 0; i --) {
      Debug.Log("Time: " + i);
      Assert.AreEqual(i, puppyClock.GetTime());
      puppyClock.Tick();
    }

    Assert.AreEqual(0, puppyClock.GetTime());

    yield return new WaitForSeconds(1);

    Assert.IsTrue(puppyShown);
  }

  private void OnGameEnd() {
    Debug.Log("Game ended!");
    gameEnded = true;
  }

  private void OnPuppyShown() {
    Debug.Log("Puppy shown!");
    puppyShown = true;
  }
}
