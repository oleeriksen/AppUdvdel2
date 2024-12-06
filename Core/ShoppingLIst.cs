namespace Core;

public class ShoppingList
{
    public int Id { get; set; }
    public string Name { get; set; } = "No Name";
    public List<ShoppingItem> ShoppingItems { get; set; } = new();
    public int Amount => ShoppingItems.Count;
    
}