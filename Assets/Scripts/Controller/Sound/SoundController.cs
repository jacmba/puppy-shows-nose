using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
  [SerializeField] AudioClip itemSound;
  [SerializeField] AudioClip mascletaSound;

  private AudioSource source;

  void Awake() {
    source = GetComponent<AudioSource>();
    EventBus.OnShoppingItemClear += OnItemPick;
    EventBus.OnToiletEnter += OnMascleta;
    EventBus.OnPuppyShown += OnMascleta;
  }

  void OnDestroy() {
    EventBus.OnItemPick -= OnItemPick;
    EventBus.OnToiletEnter -= OnMascleta;
    EventBus.OnPuppyShown -= OnMascleta;
  }

  private void OnItemPick(ShoppingItemType item) {
    source.clip = itemSound;
    source.Play();
  }

  private void OnMascleta() {
    source.clip = mascletaSound;
    source.Play();
  }
}
