using System.Collections;
using System.Collections.Generic;

public interface IShoppingList {
  List<ShoppingItemType> GetList ();
  void ClearItem (ShoppingItemType item);
}