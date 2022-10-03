public class Difficulty : IDifficulty {
  private int listSize;
  private int timeLimit;
  private DifficultyType difficultyType;

  private Difficulty() {}

  public class DifficultyBuilder {
    private int listSize = 3;
    private int timeLimit = 60;
    private DifficultyType difficultyType = DifficultyType.EASY;

    public DifficultyBuilder ListSize(int listSize) {
      this.listSize = listSize;
      return this;
    }

    public DifficultyBuilder TimeLimit(int timeLimit) {
      this.timeLimit = timeLimit;
      return this;
    }

    public DifficultyBuilder Type(DifficultyType difficultyType) {
      this.difficultyType = difficultyType;
      return this;
    }

    public IDifficulty Build() {
      var difficulty = new Difficulty();
      difficulty.listSize = listSize;
      difficulty.timeLimit = timeLimit;
      difficulty.difficultyType = difficultyType;

      return difficulty;
    }
  }

  public int GetListSize() {
    return listSize;
  }

  public DifficultyType GetDifficultyType() {
    return difficultyType;
  }

  public int GetTimeLimit() {
    return timeLimit;
  }
}
