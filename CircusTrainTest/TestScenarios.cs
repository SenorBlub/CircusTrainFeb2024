using CircusTrainFeb2024;
using Xunit;
using System.Collections.Generic;

namespace CircusTrainTest
{
    public class TestScenarios
    {
        [Fact]
        public void Scenario1()
        {
            //arrange
            var animals = new List<IAnimal>();
            animals.Add(new Herbivore(5));
            animals.Add(new Herbivore(5));
            animals.Add(new Herbivore(3));
            animals.Add(new Herbivore(3));
            animals.Add(new Herbivore(3));
            var train = new Train(animals);

            //act
            train.QuickPlace();

            //assert
            Assert.Equal(2, train.carts.Count);
        }

        [Fact]
        public void Scenario2()
        {
            //arrange
            var animals = new List<IAnimal>();
            animals.Add(new Carnivore(1));
            animals.Add(new Herbivore(5));
            animals.Add(new Herbivore(3));
            animals.Add(new Herbivore(3));
            for (int i = 0; i < 5; i++) animals.Add(new Herbivore(1));
            var train = new Train(animals);

            //act
            train.QuickPlace();

            //assert
            Assert.Equal(4, train.carts.Count);
        }

        [Fact]
        public void Scenario3()
        {
            //arrange
            var animals = new List<IAnimal>();
            animals.Add(new Carnivore(5));
            animals.Add(new Carnivore(3));
            animals.Add(new Carnivore(1));
            animals.Add(new Herbivore(5));
            animals.Add(new Herbivore(3));
            animals.Add(new Herbivore(1));
            var train = new Train(animals);

            //act
            train.QuickPlace();

            //assert
            Assert.Equal(3, train.carts.Count);
        }

        [Fact]
        public void Scenario4()
        {
            //arrange
            var animals = new List<IAnimal>();
            animals.Add(new Carnivore(5));
            animals.Add(new Carnivore(5));
            animals.Add(new Carnivore(3));
            animals.Add(new Carnivore(1));
            animals.Add(new Herbivore(5));
            for (int i = 0; i < 5; i++) animals.Add(new Herbivore(3));
            animals.Add(new Herbivore(1));
            var train = new Train(animals);

            //act
            train.QuickPlace();

            //assert
            Assert.Equal(5, train.carts.Count);
        }

        [Fact]
        public void Scenario5()
        {
            //arrange
            var animals = new List<IAnimal>();
            animals.Add(new Herbivore(5));
            animals.Add(new Herbivore(5));
            animals.Add(new Herbivore(3));
            animals.Add(new Herbivore(1));
            animals.Add(new Carnivore(1));
            var train = new Train(animals);

            //act
            train.QuickPlace();

            //assert
            Assert.Equal(2, train.carts.Count);
        }

        [Fact]
        public void Scenario6()
        {
            //arrange
            var animals = new List<IAnimal>();
            for (int i = 0; i < 3; i++) animals.Add(new Carnivore(1));
            animals.Add(new Herbivore(5));
            animals.Add(new Herbivore(5));
            animals.Add(new Herbivore(5));
            animals.Add(new Herbivore(3));
            animals.Add(new Herbivore(3));
            var train = new Train(animals);

            //act
            train.QuickPlace();

            //assert
            Assert.Equal(4, train.carts.Count);
        }

        [Fact]
        public void Scenario7_CarnivoresDominant()
        {
            //arrange
            var animals = new List<IAnimal>();
            for (int i = 0; i < 3; i++) animals.Add(new Carnivore(5));
            for (int i = 0; i < 3; i++) animals.Add(new Carnivore(3));
            for (int i = 0; i < 7; i++) animals.Add(new Carnivore(1));
            for (int i = 0; i < 6; i++) animals.Add(new Herbivore(5));
            for (int i = 0; i < 5; i++) animals.Add(new Herbivore(3));
            var train = new Train(animals);

            //act
            train.QuickPlace();

            //assert
            Assert.Equal(13, train.carts.Count); // Assuming each carnivore requires its own cart, for example
        }
    }
}