namespace CircusTrainFeb2024;

public static class AnimalGenerator
{
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
        Random random = new Random(DateTime.Now.Millisecond);

        if (random.Next(0, 1) == 1)
        {
            int randomNum = random.Next(0, 2);
            if (randomNum == 0)
            {
                return new Carnivore(1);
            }
            else if (randomNum == 1)
            {
                return new Carnivore(3);
            }
            else
            {
                return new Carnivore(5);
            }
            
        }
        else
        {
            int randomNum = random.Next(0, 2);
            if (randomNum == 0)
            {
                return new Herbivore(1);
            }
            else if (randomNum == 1)
            {
                return new Herbivore(3);
            }
            else
            {
                return new Herbivore(5);
            }
        }
    }
}