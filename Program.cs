// if we expect some things to change about a class, and some things to stay the same
// and some classes can reuse the behaviour of others, but not all, we should use the 
// strategy pattern

// code against interfaces

BeverageVendor driveThru = new DriveThruVendor();
driveThru.Order("coffee");
BeverageVendor MoonDollars = new FancyVendor();
MoonDollars.Order("coffee");

public abstract class BeverageVendor
{
    // beverage vendor ALWAYS runs the factory method and then the Pour, Lid, Sell methods
    public Beverage Order(string order)
    {
        Beverage beverage;
        beverage = createBeverage(order);
        beverage.Pour();
        beverage.Lid();
        beverage.Sell();

        return beverage;
    }

    public abstract Beverage createBeverage(string type);
}

public class DriveThruVendor: BeverageVendor
{
    // only serves coffee and tea
    public override Beverage createBeverage(string type)
    {
        Beverage beverage;
        if(type == "tea")
        {
            beverage = new Tea();
            return beverage;
        } else if (type == "coffee")
        {
            beverage = new Coffee();
            return beverage;
        } else
        {
            throw new Exception("We don't serve that here, you maniac.");
        }
    }
}
public class FancyVendor : BeverageVendor
{
    // only serves coffee and tea
    public override Beverage createBeverage(string type)
    {
        Beverage beverage;
         if (type == "coffee")
        {
            beverage = new Espresso();
            return beverage;
        } else if (type == "tea")
        {
            beverage = new Tea();
            return beverage;
        }
        else
        {
            throw new Exception("We don't serve that here, you maniac.");
        }
    }
}
public class BlackMarketVendor


public abstract class Beverage
{
    protected string _description { get; set; }
    public virtual string Description()
    {
        return _description;
    }

    protected double _cost { get; set; }
    public virtual double Cost()
    {
        return _cost;
    }
    public void Pour()
    {
        Console.WriteLine($"Pouring the {Description()}");
    }
    public void Lid()
    {
        Console.WriteLine("Putting a lid on it");
    }
    public void Sell()
    {
        Console.WriteLine($"Selling the drink for {Cost()}");
    }
}
public class Coffee: Beverage
{
    public Coffee()
    {
        _description = "Arabica Coffee";
        _cost = 1.25;
    }
}
public class Latte : Beverage
{
    public Latte()
    {
        _description = "Latte Coffee";
        _cost = 1.50;
    }
}
public class Espresso : Beverage
{
    public Espresso()
    {
        _description = "Espresso";
        _cost = 1.75;
    }
}
public class Tea: Beverage
{
    public Tea()
    {
        _description = "Loose Leaf Tea";
        _cost = 0.50;
    }
}
public class Smoothie: Beverage
{
    public Smoothie()
    {
        _description = "Fruit Smoothie";
        _cost = 3.50;
    }
}

public abstract class AddOnDecorator: Beverage
{
    // whatever beverage this decorates is the property
    public Beverage Beverage { get; set; }
    public abstract override string Description();
    public abstract override double Cost();

}
public class AddOnSaltedCaramel: AddOnDecorator
{
    public AddOnSaltedCaramel(Beverage beverage)
    {
        Beverage = beverage;
    }
    public override string Description()
    {
        return Beverage.Description() + ", Salted Caramel";
    }

    public override double Cost()
    {
        return Beverage.Cost() + 1.00;
    }
}
public class AddOnSugar : AddOnDecorator
{
    public AddOnSugar(Beverage beverage)
    {
        Beverage = beverage;
    }
    public override string Description()
    {
        return Beverage.Description() + ", Sugar";
    }

    public override double Cost()
    {
        return Beverage.Cost() + 0.05;
    }
}
public class AddOnCream: AddOnDecorator
{
    public AddOnCream(Beverage beverage)
    {
        Beverage = beverage;
    }
    public override string Description()
    {
        return Beverage.Description() + ", Cream";
    }
    public override double Cost()
    {
        return Math.Round(Beverage.Cost() + 0.1, 2);
    }
}
public class AddOnSpeakingDrink: AddOnDecorator
{
    public AddOnSpeakingDrink(Beverage beverage)
    {
        Beverage = beverage;
    }
    public override string Description()
    {
        return Beverage.Description() + ", and it talks to you.";
    }

    public override double Cost()
    {
        return Beverage.Cost() + 5.00;
    }
}


