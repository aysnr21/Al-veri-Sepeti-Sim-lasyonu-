using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        ShoppingCart cart = new ShoppingCart();
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\n--- Alışveriş Sepeti Simülasyonu ---");
            Console.WriteLine("1. Ürün ekle");
            Console.WriteLine("2. Ürün çıkar");
            Console.WriteLine("3. Sepet toplamını göster");
            Console.WriteLine("4. Çıkış");
            Console.Write("Seçiminizi yapın: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    try
                    {
                        Console.Write("Eklemek istediğiniz ürün (elma, muz, süt, ekmek): ");
                        string product = Console.ReadLine();
                        Console.Write("Miktar: ");
                        int quantity = int.Parse(Console.ReadLine());

                        cart.AddProduct(product, quantity);
                        Console.WriteLine($"{quantity} adet {product} sepetinize eklendi.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Hata: Lütfen geçerli bir sayı girin.");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Hata: {ex.Message}");
                    }
                    break;

                case "2":
                    try
                    {
                        Console.Write("Çıkarmak istediğiniz ürün: ");
                        string productToRemove = Console.ReadLine();
                        cart.RemoveProduct(productToRemove);
                        Console.WriteLine($"{productToRemove} sepetinizden çıkarıldı.");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine($"Hata: {ex.Message}");
                    }
                    break;

                case "3":
                    try
                    {
                        decimal total = cart.GetTotal();
                        Console.WriteLine($"Sepet toplamı: {total} TL");
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Hata: Sepetiniz boş.");
                    }
                    break;

                case "4":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Hata: Geçersiz seçim, lütfen tekrar deneyin.");
                    break;
            }
        }
    }
}

class ProductInfo
{
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public ProductInfo(decimal price, int quantity)
    {
        Price = price;
        Quantity = quantity;
    }
}

class ShoppingCart
{
    private Dictionary<string, ProductInfo> products;
    private static readonly Dictionary<string, decimal> productPrices = new Dictionary<string, decimal>
    {
        { "elma", 3.0m },
        { "muz", 2.5m },
        { "süt", 1.5m },
        { "ekmek", 2.0m }
    };

    public ShoppingCart()
    {
        products = new Dictionary<string, ProductInfo>();
    }

    public void AddProduct(string product, int quantity)
    {
        if (!productPrices.ContainsKey(product))
        {
            throw new ArgumentException("Stokta olmayan bir ürünü seçtiniz.");
        }

        if (quantity <= 0)
        {
            throw new ArgumentException("Miktar 0'dan büyük olmalıdır.");
        }

        if (products.ContainsKey(product))
        {
            products[product].Quantity += quantity;
        }
        else
        {
            products[product] = new ProductInfo(productPrices[product], quantity);
        }
    }

    public void RemoveProduct(string product)
    {
        if (products.Count == 0)
        {
            throw new InvalidOperationException("Sepetiniz boş.");
        }

        if (!products.ContainsKey(product))
        {
            throw new InvalidOperationException("Bu ürün sepetinizde yok.");
        }

        products.Remove(product);
    }

    public decimal GetTotal()
    {
        if (products.Count == 0)
        {
            throw new InvalidOperationException("Sepetiniz boş.");
        }

        decimal total = 0;
        foreach (var item in products)
        {
            total += item.Value.Price * item.Value.Quantity;
        }
        return total;
    }
}

