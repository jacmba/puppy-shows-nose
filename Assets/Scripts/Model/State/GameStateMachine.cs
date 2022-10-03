using System.Collections;
using System.Collections.Generic;
using System;

public class GameStateMachine : IStateMachine {
  private List<GameState> states;
  private GameState currentState;

  public GameStateMachine() {
    states = new List<GameState>();
    currentState = null;
  }

  public void AddTransition(IState from, IState to, Func<bool> condition) {
    GameState gameFrom = (GameState)from;
    GameState gameTo = (GameState)to;
    GameState prev = states.Find(s => s.GetState() == gameFrom.GetState());

    if(prev != null) {
      prev.AddTransition(gameTo, condition);
    } else {
      gameFrom.AddTransition(gameTo, condition);
      states.Add(gameFrom);
    }

    if(currentState == null) {
      currentState = gameFrom;
    }
  }

  public IState CurrentState() {
    return currentState;
  }

  public void Tick() {
    if(currentState == null) {
      return;
    }

    var transitions = currentState.GetTransitions();
    foreach(var t in transitions) {
      GameState transition = (GameState)t;
      if(currentState.To(transition)) {
        currentState = transition;
        EventBus.GameStateChanged(transition.GetState());
      }
    }
  }
}
