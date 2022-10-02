public enum ShoppingItemType {
  MILK,
  WATER,
  BREAD,
  BREWDRINK,
  MEAT,
  FRUIT,
  FISH,
  PANTS,
  SHIRT,
  SKIRT,
  SHOES,
  POPCORNS,
  LOLLIPOP,
  CANDY,
  JELLY,
  NUTS,
}

public static class ShoppingItemTypeExtension {
  public static string ToString (this ShoppingItemType item) {
    switch (item) {
      case ShoppingItemType.MILK:
        return "Milk";
      case ShoppingItemType.WATER:
        return "Water";
      case ShoppingItemType.BREWDRINK:
        return "Brew drink";
      case ShoppingItemType.MEAT:
        return "Meat";
      case ShoppingItemType.FRUIT:
        return "Fruit";
      case ShoppingItemType.FISH:
        return "Fish";
      case ShoppingItemType.PANTS:
        return "Pants";
      case ShoppingItemType.SHIRT:
        return "Shirt";
      case ShoppingItemType.SHOES:
        return "Shoes";
      case ShoppingItemType.POPCORNS:
        return "Pop corns";
      case ShoppingItemType.LOLLIPOP:
        return "Lollipop";
      case ShoppingItemType.CANDY:
        return "Candy";
      case ShoppingItemType.JELLY:
        return "Jelly";
      case ShoppingItemType.NUTS:
        return "NUTS";
      default:
        return "";
    }
  }
}