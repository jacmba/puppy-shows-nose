using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Game Data")]
public class GameData : ScriptableObject {
  public DifficultyType difficulty;
  public int timeLimit;
  public int listSize;

  public void ParseOption(IOption option) {
    difficulty = option.GetDifficulty().GetDifficultyType();
    timeLimit = option.GetDifficulty().GetTimeLimit();
    listSize = option.GetDifficulty().GetListSize();
  }
}
