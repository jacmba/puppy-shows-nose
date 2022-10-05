using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameController : MonoBehaviour {
  [SerializeField] private GameData data;
  [SerializeField] private int gameTime;
  [SerializeField] private int puppyTime;

  IGame game;

  // Start is called before the first frame update
  void Start() {
    var difficultyBuilder = new Difficulty.DifficultyBuilder();
    var optionBuilder = new Option.OptionBuilder();
    var gameBuilder = new Game.GameBuilder();

    var difficulty = difficultyBuilder
      .TimeLimit(data.timeLimit)
      .ListSize(data.listSize)
      .Type(data.difficulty)
      .Build();

    var option = optionBuilder
      .Difficulty(difficulty)
      .Build();

    game = gameBuilder
      .Option(option)
      .Build();

    UpdateTime();
    EventBus.ClocksUpdated(gameTime, puppyTime);
    UpdateItems();

    EventBus.OnListShow += OnListShow;
    EventBus.OnGameStart += OnGameStart;

    StartCoroutine(GameTick());
  }

  void OnDestroy() {
    EventBus.OnListShow -= OnListShow;
    EventBus.OnGameStart -= OnGameStart;
  }

  // Update is called once per frame
  void Update() {
    UpdateTime();
  }

  private IEnumerator GameTick() {
    while(game.GetState() != GameStateType.LOSE && game.GetState() != GameStateType.WIN) {
      yield return new WaitForSeconds(1);
      game.Tick();
      EventBus.ClocksUpdated(gameTime, puppyTime);
    }
  }

  private void UpdateTime() {
    gameTime = game.GetGameTime();
    puppyTime = game.GetPuppyTime();
  }

  private void UpdateItems() {
    var items = game.GetShoppingList().GetList()
      .Select(i => i.ToFriendlyString())
      .ToList<string>();

    EventBus.ItemsUpdated(items);
  }

  private void OnListShow() {
    UpdateItems();
  }

  private void OnGameStart() {
    Debug.Log("Starting game");
    game.OnPlay();
  }
}
