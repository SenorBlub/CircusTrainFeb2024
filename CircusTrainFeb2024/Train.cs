namespace CircusTrainFeb2024;

public class Train
{
    public List<Cart> carts;

    public List<IAnimal> animals;

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
}