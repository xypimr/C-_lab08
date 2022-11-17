using System.Xml.Serialization;
using Animals;
namespace task01;

static class Program
{
    static void Main(string[] args)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Animal));
        var animalToSererialize = new Animal("RU", false, "Oleg", "Copibara");
        using (FileStream fs = new FileStream("../../../animal.xml", FileMode.Truncate))
        {
            xmlSerializer.Serialize(fs, animalToSererialize);
            Console.WriteLine("Object has been serialized");
            
        }

        using (FileStream fs = new FileStream("../../../animal.xml", FileMode.OpenOrCreate))
        {
            var deserializeAnimal = xmlSerializer.Deserialize(fs) as Animal;
            Console.WriteLine($"deserialized object: " +
                              $"\ntype: {deserializeAnimal}:" +
                              $"\n\tcountry: {deserializeAnimal.Country}" +
                              $"\n\tname: {deserializeAnimal.Name}" +
                              $"\n\thide from animals: {deserializeAnimal.HideFromOtherAnimals}" +
                              $"\n\twhat animal: {deserializeAnimal.WhatAnimal}");
            
        }
    }
}