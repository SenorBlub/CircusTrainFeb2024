namespace CircusTrainFeb2024;

public class Cart
{
    List<IAnimal> animals = new List<IAnimal>(10);

    public int RemainingSpace()
    {
        return 10 - animals.Count;
    }

    public bool CanBePlaced(IAnimal animal)
    {
        foreach (IAnimal spot in animals)
        {
            if (spot.diet == Diet.Carnivore)
            {
                if (spot.size > animal.size)
                    return false;
            }
            else
            {
                if (animal.size > this.RemainingSpace())
                    return false;
            }
        }

        return true;
    }

    public void PlaceAnimal(IAnimal animal)
    {
        for (int i = 0; i < animal.size; i++)
        {
            animals.Insert(10 - this.RemainingSpace() + i, animal);
        }
    }

}