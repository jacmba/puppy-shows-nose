using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ShoppingList : IShoppingList {
  private List<ShoppingItemType> list;

  public class ShoppingListBuilder {
    private int size = 0;

    public ShoppingListBuilder Size(int val) {
      size = val;
      if(size < 1) {
        size = 1;
      } else if(size > (int) ShoppingItemType.NUTS + 1) {
        size = (int) ShoppingItemType.NUTS;
      }
      return this;
    }

    public ShoppingList Build () {
      List<ShoppingItemType> types = new List<ShoppingItemType> ();

      for (int i = 0; i <= (int) ShoppingItemType.NUTS; i++) {
        types.Add ((ShoppingItemType) i);
      }

      ShoppingList shoppingList = new ShoppingList();
      shoppingList.list = types.OrderBy(x => System.Guid.NewGuid()).Take(size).ToList<ShoppingItemType>();
      return shoppingList;
    }
  }

  private ShoppingList () {
    list = new List<ShoppingItemType> ();
  }

  public List<ShoppingItemType> GetList () {
    return list.ToList();
  }

  public void ClearItem (ShoppingItemType item) {
    var removed = list.Remove(item);
    if (removed) {
      EventBus.ShoppingItemClear(item);
    }

    if(list.Count <= 0) {
      EventBus.ListComplete();
    }
  }
}