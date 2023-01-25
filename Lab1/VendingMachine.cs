using System.Text;

namespace Lab1
{
    public class VendingMachine
    {
        public int SerialNumber { get; }
        public Dictionary<int, int> MoneyFloat { get; }
        public Dictionary<Product, int> Inventory { get; }

        public VendingMachine(int serialNumber, Dictionary<int, int> moneyFloat, Dictionary<Product, int> inventory)
        {
            SerialNumber = serialNumber;
            MoneyFloat = moneyFloat;
            Inventory = inventory;
        }

        public string StockItem(Product product, int quantity)
        {
            Product? existingProduct = null;

            foreach (Product p in Inventory.Keys)
            {
                if (p.Code == product.Code)
                {
                    existingProduct = p;
                    break;
                }
            }

            if (existingProduct != null)
            {
                Inventory[existingProduct] += quantity;
            }
            else
            {
                existingProduct = product;
                Inventory[existingProduct] = quantity;
            }

            return $"Name: {product.Name} | Code: {product.Code} | Price: ${product.Price} | Quantity: {Inventory[existingProduct]}";
        }

        public string StockFloat(int moneyDenomination, int quantity)
        {
            if (MoneyFloat.ContainsKey(moneyDenomination))
            {
                MoneyFloat[moneyDenomination] += quantity;
            }

            return $"Float stock: {string.Join(',', MoneyFloat)}";
        }

        public string VendItem(string code, List<int> money)
        {
            Product? selectedProduct = null;

            foreach (Product product in Inventory.Keys)
            {
                if (code == product.Code)
                {
                    selectedProduct = product;
                    break;
                }
            }

            if (selectedProduct == null)
                return $"Error, no item with code '{code}' exists";

            if (Inventory[selectedProduct] == 0)
                return "Error, item is out of stock";

            int totalMoney = money.Sum();

            if (totalMoney < selectedProduct.Price)
                return $"Error, insufficient money provided. That item costs ${selectedProduct.Price}";

            int change = totalMoney - selectedProduct.Price;
            Dictionary<int, int> coinReturn = new();

            while (change > 0)
            {
                int greatest = 0;

                foreach (KeyValuePair<int, int> pair in MoneyFloat)
                    if (pair.Value > 0 && greatest < pair.Key && change >= pair.Key)
                        greatest = pair.Key;

                if (greatest == 0)
                    return "Operation cancelled, insufficient change";

                MoneyFloat[greatest]--;
                change -= greatest;

                coinReturn[greatest] = coinReturn.ContainsKey(greatest) ? coinReturn[greatest] + 1 : 1;
            }

            if (coinReturn.Count > 0)
            {
                Console.WriteLine("Returned coins:");

                foreach (KeyValuePair<int, int> pair in coinReturn)
                    Console.WriteLine($"${pair.Key}: {pair.Value}");
            }

            Inventory[selectedProduct]--;

            return $"You have successfully purchased {selectedProduct.Name} for ${selectedProduct.Price}";
        }
    }
}
