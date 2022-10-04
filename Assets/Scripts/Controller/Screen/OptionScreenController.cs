using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionScreenController : MonoBehaviour {
  [SerializeField] Text levelText;
  [SerializeField] GameData data;

  private bool canInteract;
  private bool canPress;
  private List<IOption> options;
  private byte optionIndex;

  // Start is called before the first frame update
  void Start() {
    levelText.text = "";
    canInteract = false;
    canPress = false;
    optionIndex = 0;

    IOptionsFactory optionsFactory = new OptionsFactory();
    options = optionsFactory.GetOptions();

    StartCoroutine(Init());
  }

  // Update is called once per frame
  void Update() {
    DifficultyType difficulty = options[optionIndex].GetDifficulty().GetDifficultyType();
    levelText.text = difficulty.ToString();

    if(!canInteract) {
      return;
    }

    if(Mathf.Abs(Input.GetAxis("Horizontal")) < .1f && Input.GetAxis("Fire1") < .1f) {
      canPress = true;
    }

    if(canPress && Input.GetAxis("Horizontal") < -.1f && optionIndex > 0) {
      canPress = false;
      optionIndex--;
    }

    if(canPress && Input.GetAxis("Horizontal") > .1f && optionIndex < options.Count - 1) {
      canPress = false;
      optionIndex++;
    }

    if(canPress && Input.GetAxis("Fire1") > .1f) {
      data.ParseOption(options[optionIndex]);
      SceneManager.LoadScene((int)SceneType.GAME);
    }
  }

  private IEnumerator Init() {
    yield return new WaitForSeconds(.5f);
    canInteract = true;
    canPress = true;
  }
}
