using System;

public interface IStateMachine {
  void Tick();
  IState CurrentState();
  void AddTransition(IState from, IState to, Func<bool> condition);
}
