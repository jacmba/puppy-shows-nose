using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingList : IShoppingList {
  private List<ShoppingItemType> list;

  public class ShoppingListBuilder {
    public ShoppingList Build (int size) {
      ShoppingList shoppingList = new ShoppingList ();

      for (int i = 0; i < size; i++) {
        shoppingList.list.Add (ShoppingItemType.MILK);
      }

      return shoppingList;
    }
  }

  private ShoppingList () {
    list = new List<ShoppingItemType> ();
  }

  public List<ShoppingItemType> GetList () {
    return list;
  }

  public void ClearItem (ShoppingItemType item) { }
}