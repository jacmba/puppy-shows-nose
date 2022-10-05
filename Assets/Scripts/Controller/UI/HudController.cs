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

  // Start is called before the first frame update
  void Start() {
    normalColor = gameTimeText.color;
    EventBus.OnClocksUpdated += OnClocksUpdated;
    EventBus.OnItemsUpdated += OnItemsUpdated;
  }

  void OnDestroy() {
    EventBus.OnClocksUpdated -= OnClocksUpdated;
    EventBus.OnItemsUpdated -= OnItemsUpdated;
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
}
