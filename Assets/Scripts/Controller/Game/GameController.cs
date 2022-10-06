using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameController : MonoBehaviour {
  [SerializeField] private GameData data;
  [SerializeField] private int gameTime;
  [SerializeField] private int puppyTime;
  [SerializeField] private int deploymentTime = 5;
  [SerializeField] private GameObject player;
  [SerializeField] private Transform toiletInSpawn;
  [SerializeField] private Transform toiletOutSpawn;
  [SerializeField] private Camera playerCam;
  [SerializeField] private Camera toiletCam;

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
    EventBus.OnToiletEnter += OnToiletEnter;
    EventBus.OnPuppyShown += OnPuppyShown;
    EventBus.OnItemPick += OnItemPick;
    EventBus.OnShoppingItemClear += OnShoppingItemClear;

    StartCoroutine(GameTick());
  }

  void OnDestroy() {
    EventBus.OnListShow -= OnListShow;
    EventBus.OnGameStart -= OnGameStart;
    EventBus.OnToiletEnter -= OnToiletEnter;
    EventBus.OnPuppyShown -= OnPuppyShown;
    EventBus.OnItemPick -= OnItemPick;
    EventBus.OnShoppingItemClear -= OnShoppingItemClear;
  }

  // Update is called once per frame
  void Update() {
    UpdateTime();
  }

  private IEnumerator GameTick() {
    while(true) {
      yield return new WaitForSeconds(1);
      game.Tick(true);
      UpdateTime();
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

  private void OnToiletEnter() {
    EventBus.MessageShow("Deploying puppy");
    game.OnPauseToggle();
    game.ResetTimer();
    UpdateTime();
    toiletCam.enabled = true;
    playerCam.enabled = false;
    player.transform.position = toiletInSpawn.position;
    StartCoroutine(DeployPuppy());
  }

  private IEnumerator DeployPuppy() {
    yield return new WaitForSeconds(deploymentTime);
    player.transform.position = toiletOutSpawn.position;
    player.transform.rotation = toiletOutSpawn.rotation;
    playerCam.enabled = true;
    toiletCam.enabled = false;
    game.OnPauseToggle();
    EventBus.ToiletExit();
  }

  private void OnPuppyShown() {
    game.OnLose();
  }

  private void OnItemPick(ShoppingItemType item) {
    Debug.Log("Attempting to pick " + item);
    game.GetShoppingList().ClearItem(item);
    UpdateItems();
  }

  private void OnShoppingItemClear(ShoppingItemType item) {
    Debug.Log("Cleared item " + item);
    EventBus.MessageShow("You picked " + item.ToFriendlyString());
  }
}
