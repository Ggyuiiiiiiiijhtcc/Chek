using System;
class Program
{
    static void Main(string[] args)
    {
        Item item1 = new Item()
        {
            Name = "Книга 'Преступление и наказание'",
            Quantity = 2,
            PricePerUnit = 10.50m,
            Discount = 1.00m,
            TotalPrice = 20.00m,
            Message = "Спасибо за покупку!"
        };
        Item item2 = new Item()
        {
            Name = "Музыкальный альбом 'The Dark Side of the Moon'",
            Quantity = 1,
            PricePerUnit = 15.99m,
            Discount = 0.00m,
            TotalPrice = 15.99m,
            Message = "Хорошего дня!"
        };

        Chek chek = new Chek()
        {
            Items = new Item[] { item1, item2 }
        };

        chek.Print();

        Console.ReadKey();
    }
}

    struct Item
{
    public string Name;
    public int Quantity;
    public decimal PricePerUnit;
    public decimal Discount;
    public decimal TotalPrice;
    public string Message;
}

struct Chek
{
    public Item[] Items;

    public decimal Subtotal
    {
        get
        {
            decimal subtotal = 0;
            foreach (var item in Items)
            {
                subtotal += item.TotalPrice;
            }
            return subtotal;
        }
    }

    public decimal Total
    {
        get
        {
            return Subtotal - Discount;
        }
    }

    public decimal Discount
    {
        get
        {
            decimal discount = 0;
            foreach (var item in Items)
            {
                discount += item.Discount;
            }
            return discount;
        }
    }

    public void Print()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.White;
        Console.WriteLine("=======================================");
        Console.WriteLine("                ЧЕК                    ");
        Console.WriteLine("=======================================");
        Console.WriteLine("{0,-30}{1,10}{2,10}{3,10}{4,10}", "Название", "Кол-во", "Цена", "Скидка", "Итого");
        foreach (var item in Items)
        {
            Console.WriteLine("{0,-30}{1,10}{2,10:C}{3,10:C}{4,10:C}", item.Name, item.Quantity, item.PricePerUnit, item.Discount, item.TotalPrice);
        }
        Console.WriteLine("=======================================");
        Console.WriteLine("{0,50:C}", Subtotal);
        Console.WriteLine("{0,50:C}", Discount);
        Console.WriteLine("{0,50:C}", Total);
        Console.WriteLine("=======================================");
        Console.WriteLine("{0}", Items[0].Message);
        Console.ResetColor();
    }
}
