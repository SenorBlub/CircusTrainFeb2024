using CircusTrainFeb2024;

string input;
bool random = false;
while (true)
{
    Console.Write("Do you want to use random animals or fill in your own?(Random/Custom)");
    input = Console.ReadLine();
    if (input == "Random")
    {
        random = true;
        break;
    }else if (input == "Custom")
    {
        random = false;
        break;
    }
    else
    {
        Console.WriteLine("Please provide a valid input option (Random/Custom)");
    }
}

List<IAnimal> animals = new List<IAnimal>();
if (random)
{
    int inputNumber;
    while (true)
    {
        Console.Write("Please enter number of animals: ");
        if (int.TryParse(Console.ReadLine(), out inputNumber))
        {
            animals.AddRange(AnimalGenerator.GenerateAnimals(inputNumber));
            break;
        }

        Console.WriteLine("Invalid input, please enter a valid number.");

    }
}
else
{
    bool done = false;
    while (true)
    {
        if (done)
        {
            break;
        }
        Console.Write("Carnivore or Herbivore?(C/H)");
        input = Console.ReadLine();
        if (input == "C")
        {
            int inputNumber;
            while (true)
            {
                Console.Write("Size of the animal: ");
                if (int.TryParse(Console.ReadLine(), out inputNumber))
                {
                    animals.Add(new Carnivore(inputNumber));
                    break;
                }
                Console.WriteLine("Invalid input, please enter a valid number.");
            }
        }
        else if (input == "H")
        {
            int inputNumber;
            while (true)
            {
                Console.Write("Size of the animal: ");
                if (int.TryParse(Console.ReadLine(), out inputNumber))
                {
                    animals.Add(new Herbivore(inputNumber));
                    break;
                }
                Console.WriteLine("Invalid input, please enter a valid number.");
            }
        }
        else
        {
            Console.WriteLine("Please provide a valid input option (C/H)");
        }

        while (true)
        {
            Console.Write("Do you want to generate another animal?(Y/N) ");
            input = Console.ReadLine();
            if (input == "Y")
            {
                break;
            }else if (input == "N")
            {
                done = true;
                break;
            }
            else
            {
                Console.WriteLine("Please provide a valid input option (Y/N)");
            }
        }
    }
}
Train train = new Train(animals);

bool loading = true;

Thread workThread;
workThread = new Thread(() =>
    {
        train.QuickPlace();

        loading = false;
    });

    Thread loadingThread = new Thread(() =>
{
    string[] sequence = { "|", "/", "-", "\\" };
    int index = 0;
    while (loading)
    {
        Console.Write($"\r{sequence[index++ % sequence.Length]} Processing...");
        Thread.Sleep(100);
    }
});

loadingThread.Start();
workThread.Start();

workThread.Join();
loadingThread.Join();

Console.WriteLine("\rDone!          ");

while (true)
{
    Console.WriteLine("Choose output medium (Console/File): ");
    input = Console.ReadLine();
    if (input == "Console")
    {
        Console.WriteLine("Resulting train layout: ");
        train.DisplayTrain();
        break;
    }else if (input == "File")
    {
        loading = true;

        workThread = new Thread(() =>
        {
            train.OutputToFile();

            loading = false;
        });

        loadingThread = new Thread(() =>
        {
            string[] sequence = { "|", "/", "-", "\\" };
            int index = 0;
            while (loading)
            {
                Console.Write($"\r{sequence[index++ % sequence.Length]} Processing...");
                Thread.Sleep(100);
            }
        });

        loadingThread.Start();
        workThread.Start();

        workThread.Join();
        loadingThread.Join();

        Console.WriteLine("\rDone!          ");
        break;
    }
    else
    {
        Console.WriteLine("Please provide a valid input option (Console/File)");
    }
}

Console.WriteLine();
Console.WriteLine("Press enter to close application");

