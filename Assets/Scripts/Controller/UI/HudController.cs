using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour {
  [SerializeField] private Text gameTimeText;
  [SerializeField] private Text puppyTimeText;
  [SerializeField] private List<Text> shoppingItems;

  // Start is called before the first frame update
  void Start() {
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
  }

  private void OnItemsUpdated(List<string> items) {
    for(int i = 0; i < shoppingItems.Count; i++) {
      var txt = i < items.Count ? "- " + items[i] : "";
      shoppingItems[i].text = txt;
    }
  }
}
