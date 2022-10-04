using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour {

  // Update is called once per frame
  void Update() {
    if(Input.GetAxis("Fire1") > .1f) {
      SceneManager.LoadScene((int)SceneType.OPTIONS);
    }
  }
}
