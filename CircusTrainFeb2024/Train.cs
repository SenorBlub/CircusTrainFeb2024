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
        
        foreach (IAnimal animal in animals)
        {
            Cart newCart = new Cart();
            bool newCartMade = true;
            newCart.PlaceAnimal(animal);
            foreach (Cart cart in carts)
            {
                if (cart.CanBePlaced(animal))
                {
                    cart.PlaceAnimal(animal);
                    newCartMade = false;
                    break;
                }
            }
            if (newCartMade)
            {
                carts.Add(newCart);
            }
        }

    }

    public void BestPlace()
    {
        this.PreSortAnimals();

    }
}