using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionTextController : MonoBehaviour {
  [SerializeField] private int durationSeconds = 5;

  private Text text;

  // Start is called before the first frame update
  void Start() {
    text = GetComponent<Text>();

    EventBus.OnMessageShow += OnMessageShow;
  }

  void OnDestroy() {
    EventBus.OnMessageShow -= OnMessageShow;
  }

  private void OnMessageShow(string message) {
    StartCoroutine(DisplayMessage(message));
  }

  private IEnumerator DisplayMessage(string message) {
    text.text = message;
    yield return new WaitForSeconds(durationSeconds);
    text.text = "";
  }
}
