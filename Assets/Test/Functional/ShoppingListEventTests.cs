using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ShoppingListEventTests
{
  private IShoppingList shoppingList;
  private bool listComplete;
  private ShoppingItemType clearItem;

  [SetUp]
  public void Setup() {
    ShoppingList.ShoppingListBuilder builder = new ShoppingList.ShoppingListBuilder();
    shoppingList = builder
      .Size(2)
      .Build();

    EventBus.OnListComplete += OnListComplete;
    EventBus.OnShoppingItemClear += OnShoppingItemClear;
  }

  [TearDown]
  public void TearDown() {
    EventBus.OnListComplete -= OnListComplete;
    EventBus.OnShoppingItemClear -= OnShoppingItemClear;
  }

  private void OnListComplete() {
    Debug.Log("List complete!");
    listComplete = true;
  }

  private void OnShoppingItemClear(ShoppingItemType item) {
    Debug.Log("Item cleared: " + item.ToFriendlyString());
    clearItem = item;
  }

  [UnityTest]
  public IEnumerator ShoppingListTestShouldTriggerListCompleteEventWhenEmpty() {
    listComplete = false;
    ShoppingItemType item;

    Assert.AreEqual(2, shoppingList.GetList().Count);
    item = shoppingList.GetList()[0];
    shoppingList.ClearItem(item);
    Assert.AreEqual(1, shoppingList.GetList().Count);

    yield return new WaitForSeconds(1);
    Assert.AreEqual(item, clearItem);
    Assert.IsFalse(listComplete);
    item = shoppingList.GetList()[0];
    shoppingList.ClearItem(item);
    Assert.AreEqual(0, shoppingList.GetList().Count);

    yield return new WaitForSeconds(1);
    Assert.AreEqual(item, clearItem);
    Assert.IsTrue(listComplete);
  }
}
