using Lab1;

Dictionary<int, int> coinStorage = new()
{
    {20, 2},
    {15, 1},
    {10, 3},
    {5, 3},
    {2, 4},
    {1, 5}
};

Dictionary<Product, int> inventory = new()
{
    {new Product("Ruffles Original Chips", 3, "A1"), 1},
    {new Product("Skittles", 2, "A2"), 3},
    {new Product("Doritos Nacho Cheese", 4, "A3"), 2},
    {new Product("Pretzels", 1, "A4"), 0}
};

VendingMachine vendingMachine = new(4832541, coinStorage, inventory);
Console.WriteLine(vendingMachine.StockItem(new Product("Ruffles Original Chips", 3, "A1"), 4));
Console.WriteLine(vendingMachine.StockFloat(5, 4));
Console.WriteLine();

string? input = "";
string moneyInput = "";
string itemInput = "";

int phase = 0;

while (input != "CANCEL")
{
    if (phase == 0)
    {
        Console.WriteLine("Please enter money amount (or 'CANCEL'):");
        input = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(input))
        {
            moneyInput = input;
            phase++;
        }
    }
    else if (phase == 1)
    {
        Console.WriteLine("Please enter item code (or 'CANCEL'):");
        input = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(input))
        {
            itemInput = input.ToUpper();
            phase++;
        }
    }
    else
    {
        int money = int.Parse(moneyInput);

        string message = vendingMachine.VendItem(itemInput, new List<int>() {money});
        Console.WriteLine(message);
        break;
    }
}