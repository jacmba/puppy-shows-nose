using System.Collections;
using System.Collections.Generic;
using System;

public static class EventBus {
  public static event Action OnGameEnd;
  public static event Action OnPuppyShown;
  public static event Action OnListComplete;
  public static event Action<ShoppingItemType> OnShoppingItemClear;
  public static event Action<GameStateType> OnGameStateChanged;
  public static event Action<int, int> OnClocksUpdated;
  public static event Action<List<string>> OnItemsUpdated;
  public static event Action OnListShow;
  public static event Action OnGameStart;
  public static event Action OnToiletEnter;
  public static event Action OnToiletExit;
  public static event Action<ShoppingItemType> OnItemPick;
  public static event Action<string> OnMessageShow;

  public static void GameEnd() {
    OnGameEnd?.Invoke();
  }

  public static void PuppyShown() {
    OnPuppyShown?.Invoke();
  }

  public static void ListComplete() {
    OnListComplete?.Invoke();
  }

  public static void ShoppingItemClear(ShoppingItemType item) {
    OnShoppingItemClear?.Invoke(item);
  }

  public static void GameStateChanged(GameStateType state) {
    OnGameStateChanged?.Invoke(state);
  }

  public static void ClocksUpdated(int gameClock, int puppyClock) {
    OnClocksUpdated?.Invoke(gameClock, puppyClock);
  }

  public static void ItemsUpdated(List<string> items) {
    OnItemsUpdated?.Invoke(items);
  }

  public static void ListShow() {
    OnListShow?.Invoke();
  }

  public static void GameStart() {
    OnGameStart?.Invoke();
  }

  public static void ToiletEnter() {
    OnToiletEnter?.Invoke();
  }

  public static void ToiletExit() {
    OnToiletExit?.Invoke();
  }

  public static void ItemPick(ShoppingItemType item) {
    OnItemPick?.Invoke(item);
  }

  public static void MessageShow(string message) {
    OnMessageShow?.Invoke(message);
  }
}
