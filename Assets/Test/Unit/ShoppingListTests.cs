using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ShoppingListTests {
  // A Test behaves as an ordinary method
  [Test]
  public void ShoppingListTestShouldCreateListWithOneElement () {
    ShoppingList.ShoppingListBuilder builder = new ShoppingList.ShoppingListBuilder ();
    ShoppingList shoppingList = builder.Build (1);

    List<ShoppingItemType> items = shoppingList.GetList ();
    Assert.AreEqual (1, items.Count);
  }
}