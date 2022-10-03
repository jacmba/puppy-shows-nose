using System;
using System.Collections;
using System.Collections.Generic;

public interface IState {
  void AddTransition(IState to, Func<bool> condition);
  bool To(IState to);
  List<IState> GetTransitions();
}
