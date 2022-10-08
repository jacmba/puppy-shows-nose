using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
  [SerializeField] AudioClip itemSound;

  private AudioSource source;

  void Start() {
    source = GetComponent<AudioSource>();
    EventBus.OnShoppingItemClear += OnItemPick;
  }

  void OnDestroy() {
    EventBus.OnItemPick -= OnItemPick;
  }

  private void OnItemPick(ShoppingItemType item) {
    source.PlayOneShot(itemSound);
  }
}
