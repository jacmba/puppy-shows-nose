public class Option : IOption {
  private IDifficulty difficulty;

  private Option() { }

  public class OptionBuilder {
    private IDifficulty difficulty;

    public OptionBuilder Difficulty(IDifficulty difficulty) {
      this.difficulty = difficulty;
      return this;
    }

    public IOption Build() {
      var option = new Option();
      option.difficulty = difficulty;

      return option;
    }
  }

  public IDifficulty GetDifficulty() {
    return difficulty;
  }
}
