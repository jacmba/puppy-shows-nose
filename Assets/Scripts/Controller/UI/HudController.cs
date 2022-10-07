using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour {
  [SerializeField] private Text gameTimeText;
  [SerializeField] private Text puppyTimeText;
  [SerializeField] private List<Text> shoppingItems;
  [SerializeField] private Color criticalColor;
  private Color normalColor;

  private GameObject winText;
  private GameObject gameOver;

  // Start is called before the first frame update
  void Start() {
    normalColor = gameTimeText.color;
    winText = transform.Find("WinText").gameObject;
    gameOver = transform.Find("GameOver").gameObject;

    EventBus.OnClocksUpdated += OnClocksUpdated;
    EventBus.OnItemsUpdated += OnItemsUpdated;
    EventBus.OnListComplete += OnWin;
    EventBus.OnGameEnd += OnLose;
    EventBus.OnPuppyShown += OnLose;
  }

  void OnDestroy() {
    EventBus.OnClocksUpdated -= OnClocksUpdated;
    EventBus.OnItemsUpdated -= OnItemsUpdated;
    EventBus.OnListComplete -= OnWin;
    EventBus.OnGameEnd -= OnLose;
    EventBus.OnPuppyShown -= OnLose;
  }

  private void OnClocksUpdated(int gameClock, int puppyClock) {
    gameTimeText.text = "Time left: " + gameClock;
    puppyTimeText.text = "Time for puppy: " + puppyClock;

    gameTimeText.color = gameClock <= 10 ? criticalColor : normalColor;
    puppyTimeText.color = puppyClock <= 3 ? criticalColor : normalColor;
  }

  private void OnItemsUpdated(List<string> items) {
    for(int i = 0; i < shoppingItems.Count; i++) {
      var txt = i < items.Count ? "- " + items[i] : "";
      shoppingItems[i].text = txt;
    }
  }

  private void OnWin() {
    winText.SetActive(true);
  }

  private void OnLose() {
    gameOver.SetActive(true);
  }
}
