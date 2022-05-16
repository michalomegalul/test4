new TestApp().Run();
class TestApp
{
    public void Run()
    {
        var data = GetIUtemsFromData(); var sum = 0;
        foreach (var item in data)
        {
            sum += Convert.ToInt32(item.Quantity) * Convert.ToInt32(item.Price);
        }
        File.WriteAllText("./output.txt", $"Datum:{DateTime.Now}; Celkova castka:{sum}");
        Console.WriteLine($"Datum:{DateTime.Now}; Celkova castka:{sum}");
    }
    public List<Items> GetIUtemsFromData()
    {
        var data = File.ReadAllText(@"./inventory.txt");
        var list = new List<Items>();

        var parts = data.Split('#');
        foreach (var dota in parts)
        {
            var splititem = dota.Split('-');
            var Items = new Items
            {
                Price = splititem[4],
                Quantity = splititem[5],
            };
            list.Add(Items);
        }
        return list;
    }
}
public class Items
{
    public string Price { get; set; } = "";
    public string Quantity { get; set; } = "";
}