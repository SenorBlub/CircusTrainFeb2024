namespace CircusTrainFeb2024;

public class Herbivore : IAnimal
{
    public Diet diet { get; }

    public int size { get; }

    public Herbivore(int _size)
    {
        diet = Diet.Herbivore;
        size = _size;
    }
}