using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionTextController : MonoBehaviour {
  [SerializeField] private int durationSeconds = 5;

  private Text text;
  private Coroutine lastCoroutine;
  private bool crRunning;

  // Start is called before the first frame update
  void Start() {
    text = GetComponent<Text>();
    crRunning = false;

    EventBus.OnMessageShow += OnMessageShow;
  }

  void OnDestroy() {
    EventBus.OnMessageShow -= OnMessageShow;
  }

  private void OnMessageShow(string message) {
    if(lastCoroutine != null && crRunning) {
      StopCoroutine(lastCoroutine);
    }
    lastCoroutine = StartCoroutine(DisplayMessage(message));
  }

  private IEnumerator DisplayMessage(string message) {
    crRunning = true;
    text.text = message;
    yield return new WaitForSeconds(durationSeconds);
    text.text = "";
    crRunning = false;
  }
}
