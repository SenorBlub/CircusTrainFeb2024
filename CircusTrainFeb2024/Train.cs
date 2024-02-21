using System.Xml.Linq;

namespace CircusTrainFeb2024;

public class Train
{
    public List<Cart>? carts;

    public List<IAnimal> animals;

    public Train(List<IAnimal> _animals)
    {
        animals = _animals;
    }

    public long CalculatePlacementEfficiency()
    {
        int totalSize = 0;
        foreach (IAnimal animal in animals)
        {
            totalSize += animal.size;
        }

        if(totalSize>0)
            return carts.Count/totalSize;
        return 1000000;
    }

    public void PreSortAnimals()
    {

        List<IAnimal> carnivores = new List<IAnimal>();
        List<IAnimal> herbivores = new List<IAnimal>();
        foreach (IAnimal animal in animals)
        {
            if (animal.diet == Diet.Carnivore)
            {
                carnivores.Add(animal);
            }
            else
            {
                herbivores.Add(animal);
            }
        }

        carnivores.Sort((animal1, animal2) => animal1.size.CompareTo(animal2.size));
        herbivores.Sort((animal1, animal2) => animal1.size.CompareTo(animal2.size));

        List<IAnimal> newAnimals = new List<IAnimal>();

        newAnimals.AddRange(carnivores);
        newAnimals.AddRange(herbivores);

        animals = newAnimals;
    }

    public void QuickPlace()
    {
        this.PreSortAnimals();
        carts = new List<Cart>();

        foreach (IAnimal animal in animals)
        {
            Cart newCart = new Cart();
            bool newCartMade = true;
            newCart.PlaceAnimal(animal);
            if (carts.Count > 0)
            {
                foreach (Cart cart in carts)
                {
                    if (cart.CanBePlaced(animal))
                    {
                        cart.PlaceAnimal(animal);
                        newCartMade = false;
                        break;
                    }
                }
            }
            else
            {
                carts.Add(newCart);
            }

            if (newCartMade)
            {
                carts.Add(newCart);
            }
        }
    }

    public void DisplayTrain()
    {
        Console.WriteLine("Train");
        foreach (var cart in carts)
        {
            Console.WriteLine();
            Console.WriteLine("Cart");
            bool first = true;
            foreach (var animal in cart.animals)
            {
                if (!first)
                    Console.Write(" - ");
                first = false;
                if (animal.diet == Diet.Carnivore)
                {
                    Console.Write("C" + animal.size);
                }
                else
                {
                    Console.Write("H" + animal.size);
                }
            }
        }
    }

    public void OutputToFile()
    {
        var train = new XElement("Train");

        foreach (var cart in carts)
        {
            var cartElement = new XElement("Cart");
            foreach (var animal in cart.animals)
            {
                var animalElement = new XElement("Animal",
                    new XAttribute("type", animal.diet == Diet.Carnivore ? "Carnivore" : "Herbivore"),
                    new XAttribute("size", animal.size.ToString()));
                cartElement.Add(animalElement);
            }
            train.Add(cartElement);
        }

        var doc = new XDocument(train);
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Train.xml");
        doc.Save(filePath);
        Console.Write("File can be found at: ");
        Console.Write(filePath);
    }
}