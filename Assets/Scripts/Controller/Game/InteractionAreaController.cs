using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionAreaController : MonoBehaviour {
  [SerializeField] private InteractionType interaction;
  [SerializeField] private string message;
  [SerializeField] private ShoppingItemType item;

  private bool inside;

  // Start is called before the first frame update
  void Start() {
    inside = false;
  }

  // Update is called once per frame
  void Update() {
    if (inside && Input.GetButton("Fire1")) {
      Interact();
    }
  }

  void OnTriggerEnter(Collider other) {
    if(other.gameObject.name != "Player") {
      Debug.Log("Unknown object entered");
      return;
    }

    Debug.Log("Player entered on area " + interaction);
    inside = true;
    EventBus.MessageShow(message);
  }

  void OnTriggerExit(Collider other) {
    if(other.gameObject.name != "Player") {
      Debug.Log("Unknown object exited");
      return;
    }

    Debug.Log("Player exited area " + interaction);
    inside = false;
  }

  void Interact() {
    switch (interaction) {
      case InteractionType.DEPLOY:
        EventBus.ToiletEnter();
        break;
      case InteractionType.PICK_ITEM:
        EventBus.ItemPick(item);
        break;
      default:
        break;
    }
  }
}
