namespace CircusTrainFeb2024;

public static class AnimalGenerator
{
    private static Random random = new Random();

    public static List<IAnimal> GenerateAnimals(int count)
    {
        var animals = new List<IAnimal>();
        for (int i = 0; i < count; i++)
        {
            animals.Add(RandomAnimal());
        }
        return animals;
    }

    public static IAnimal RandomAnimal()
    {
        bool isCarnivore = random.Next(0, 2) == 0;
        int size = (random.Next(0, 3) + 1) * 2 - 1;

        return isCarnivore ? new Carnivore(size) : new Herbivore(size);
    }
}