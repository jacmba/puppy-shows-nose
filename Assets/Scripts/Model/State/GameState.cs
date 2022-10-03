using System.Collections;
using System.Collections.Generic;
using System;

public class GameState : IGameState {
  private GameStateType type;
  private Dictionary<GameState, List<Func<bool>>> transitions;

  public GameState(GameStateType type) {
    this.type = type;
    transitions = new Dictionary<GameState, List<Func<bool>>>();
  }

  public void AddTransition(IState to, Func<bool> condition) {
    GameState gameStateTo = (GameState)to;
    List<Func<bool>> conditions;
    bool exist = transitions.TryGetValue(gameStateTo, out conditions);

    if(!exist) {
      conditions = new List<Func<bool>>();
      transitions.Add(gameStateTo, conditions);
    }

    conditions.Add(condition);
  }

  public GameStateType GetState() {
    return type;
  }

  public bool To(IState to) {
    List<Func<bool>> conditions;
    bool exist = transitions.TryGetValue((GameState)to, out conditions);

    if(!exist) {
      return false;
    }

    foreach(var condition in conditions) {
      if(condition()) {
        return true;
      }
    }

    return false;
  }

  public List<IState> GetTransitions() {
    return new List<IState>(transitions.Keys);
  }
}
