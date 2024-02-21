namespace CircusTrainFeb2024;

public class Cart
{
    List<IAnimal> animals = new List<IAnimal>(10);

    public int RemainingSpace()
    {
        return animals.Count - 10;
    }
}