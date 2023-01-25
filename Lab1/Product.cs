namespace Lab1
{
    public class Product
    {
        public string Name { get; }
        public int Price { get; }
        public string Code { get; }

        public Product(string name, int price, string code)
        {
            Name = name;
            Price = price;
            Code = code;
        }
    }
}
