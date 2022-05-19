Beverage myCoffee = new Coffee();
myCoffee = new AddOnSaltedCaramel(myCoffee);

Console.WriteLine(myCoffee.Cost());
Console.WriteLine(myCoffee.Description());

Beverage myTea = new Tea();
myTea = new AddOnSugar(myTea);
myTea = new AddOnSugar(myTea);
myTea = new AddOnSaltedCaramel(myTea);
myTea = new AddOnCream(myTea);
myTea = new AddOnSpeakingDrink(myTea);

Console.WriteLine(myTea.Cost());
Console.WriteLine(myTea.Description());


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

