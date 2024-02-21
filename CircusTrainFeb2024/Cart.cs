namespace CircusTrainFeb2024;

public class Cart
{
    public List<IAnimal> animals { get; } = new List<IAnimal>(10);

    public int RemainingSpace()
    {
        int usedSpace = 0;
        foreach (var animal in animals)
        {
            usedSpace += animal.size;
        }
        return 10 - usedSpace;
    }

    public bool CanBePlaced(IAnimal animal)
    {
        if (animal.size > this.RemainingSpace())
        {
            return false;
        }

        foreach (var spot in animals)
        {
            if ((spot.diet == Diet.Carnivore && spot.size >= animal.size) ||
                (animal.diet == Diet.Carnivore && animal.size >= spot.size))
            {
                return false;
            }
        }

        return true;
    }

    public void PlaceAnimal(IAnimal animal)
    {
        if (CanBePlaced(animal))
        {
            animals.Add(animal);
        }
    }

}