using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
  [SerializeField] private float rotationSpeed = 15f;
  [SerializeField] private float runSpeed = 30f;

  private Animator animator;
  private Rigidbody body;
  private bool run;
  private bool play;

  private float h;
  private float v;

  // Start is called before the first frame update
  void Start() {
    animator = GetComponent<Animator>();
    body = GetComponent<Rigidbody>();

    run = false;
    play = false;

    EventBus.OnGameStart += OnGameStart;
  }

  void OnDestroy() {
    EventBus.OnGameStart -= OnGameStart;
  }

  // Update is called once per frame
  void Update() {
    animator.SetBool(AnimationTriggerType.RUN.ToString(), run);

    if(!play) {
      return;
    }

    h = Input.GetAxis("Horizontal");
    v = Input.GetAxis("Vertical");

    run = Mathf.Abs(h) > .1f || Mathf.Abs(v) > .1f;

    transform.Rotate(h * Vector3.up * rotationSpeed * Time.deltaTime);
  }

  void FixedUpdate() {
    if (play) {
      transform.Translate(v * Vector3.forward * runSpeed * Time.deltaTime);
    }
  }

  private void OnGameStart() {
    play = true;
  }
}
