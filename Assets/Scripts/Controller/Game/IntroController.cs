using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroController : MonoBehaviour {
  [SerializeField] private Text introText;
  [SerializeField] private Camera mainCam;
  [SerializeField] private Camera kebabCam;
  [SerializeField] private Camera playerCam;
  [SerializeField] private GameObject player;
  [SerializeField] private Transform kebabSpot;
  [SerializeField] private GameObject hud;
  [SerializeField] private GameObject timers;
  [SerializeField] private float transitionSeconds = 5;

  // Start is called before the first frame update
  void Start() {
    StartCoroutine(IntroRoutine());
  }

  private IEnumerator IntroRoutine() {
    introText.text = "Just a great day for shopping in this wonderful mall";
    yield return new WaitForSeconds(transitionSeconds);
    hud.SetActive(true);
    introText.text = "I have to buy all these items on time if I don't wanna get in trouble";
    yield return new WaitForEndOfFrame();
    EventBus.ListShow();
    yield return new WaitForSeconds(transitionSeconds);
    kebabCam.enabled = true;
    mainCam.enabled = false;
    player.transform.position = kebabSpot.position;
    player.transform.rotation = kebabSpot.rotation;
    introText.text = "But I'm so hungry. First I need my super extra-spicy doner!";
    yield return new WaitForSeconds(transitionSeconds);
    introText.text = "Oh no! That doner broke my stomach!";
    yield return new WaitForSeconds(transitionSeconds);
    introText.text = "I don't think I can stand for 10 seconds before the puppy shows nose";
    yield return new WaitForSeconds(transitionSeconds);
    introText.text = "I hope there's a nearby toilet. Let's go shopping!";
    timers.SetActive(true);
    yield return new WaitForSeconds(transitionSeconds);
    playerCam.enabled = true;
    mainCam.enabled = false;
    introText.gameObject.SetActive(false);
    EventBus.GameStart();
  }
}
