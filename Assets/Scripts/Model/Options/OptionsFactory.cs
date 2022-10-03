using System.Collections;
using System.Collections.Generic;

public class OptionsFactory : IOptionsFactory {

  public List<IOption> GetOptions() {
    var options = new List<IOption>();

    var optionBuilder = new Option.OptionBuilder();
    var difficultyBuilder = new Difficulty.DifficultyBuilder();

    var easyDifficulty = difficultyBuilder
      .TimeLimit(180)
      .ListSize(3)
      .Type(DifficultyType.EASY)
      .Build();

    var mediumDifficulty = difficultyBuilder
      .TimeLimit(120)
      .ListSize(5)
      .Type(DifficultyType.MEDIUM)
      .Build();

    var hardDifficulty = difficultyBuilder
      .TimeLimit(60)
      .ListSize(10)
      .Type(DifficultyType.HARD)
      .Build();

    var easyOption = optionBuilder
      .Difficulty(easyDifficulty)
      .Build();

    var mediumOption = optionBuilder
      .Difficulty(mediumDifficulty)
      .Build();

    var hardOption = optionBuilder
      .Difficulty(hardDifficulty)
      .Build();

    options.Add(easyOption);
    options.Add(mediumOption);
    options.Add(hardOption);

    return options;
  }
}
