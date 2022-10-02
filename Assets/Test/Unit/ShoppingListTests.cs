using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ShoppingListTests {
  // A Test behaves as an ordinary method
  [Test]
  public void TestShoppingListShouldCreateListWithOneElement() {
    ShoppingList.ShoppingListBuilder builder = new ShoppingList.ShoppingListBuilder ();
    ShoppingList shoppingList = builder
      .Size(1)
      .Build();

    List<ShoppingItemType> items = shoppingList.GetList ();
    Assert.AreEqual (1, items.Count);
  }

  [Test]
  public void TestShoppingListShouldCreateListWith3DifferentElements() {
    ShoppingList.ShoppingListBuilder builder = new ShoppingList.ShoppingListBuilder();
    ShoppingList shoppingList = builder
      .Size(3)
      .Build();

    List<ShoppingItemType> items = shoppingList.GetList();
    Assert.AreEqual(3, items.Count);
    Assert.AreNotEqual(items[0], items[1]);
    Assert.AreNotEqual(items[0], items[2]);
    Assert.AreNotEqual(items[1], items[2]);
  }

  [Test]
  public void TestShoppingListShouldCreateListWithMinimumOneElement() {
    ShoppingList.ShoppingListBuilder builder = new ShoppingList.ShoppingListBuilder();
    ShoppingList shoppingList = builder
      .Size(-1)
      .Build();

    List<ShoppingItemType> items = shoppingList.GetList();
    Assert.AreEqual(1, items.Count);
  }

  [Test]
  public void TestShoppingListShouldNotCreateListWithMoreElementsThanAvailable() {
    ShoppingList.ShoppingListBuilder builder = new ShoppingList.ShoppingListBuilder();
    ShoppingList shoppingList = builder
      .Size(100)
      .Build();

    Assert.LessOrEqual(shoppingList.GetList().Count, (int)ShoppingItemType.NUTS + 1);
  }

  [Test]
  public void TestShoppingListShouldRemoveExistingItem() {
    ShoppingList.ShoppingListBuilder builder = new ShoppingList.ShoppingListBuilder();
    ShoppingList shoppingList = builder
      .Size(1)
      .Build();

    ShoppingItemType item = shoppingList.GetList()[0];
    shoppingList.ClearItem(item);

    Assert.AreEqual(0, shoppingList.GetList().Count);
  }

  [Test]
  public void TestShoppingListShouldRemainSameWhenMovingNonExistingItem() {
    ShoppingList.ShoppingListBuilder builder = new ShoppingList.ShoppingListBuilder();
    ShoppingList shoppingList = builder
      .Size(1)
      .Build();

    ShoppingItemType item = shoppingList.GetList()[0];
    if((int) item == 0) {
      item++;
    } else {
      item--;
    }

    shoppingList.ClearItem(item);

    Assert.AreEqual(1, shoppingList.GetList().Count);
  }
}