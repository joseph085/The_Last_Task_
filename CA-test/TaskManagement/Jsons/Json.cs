using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System;
using System.IO;


namespace TaskManagement.Jsons
{
    public class Json
    {

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }
        }

        public class PersonRepository
        {
            private readonly string _filePath;

            public PersonRepository(string filePath)
            {
                _filePath = filePath;
            }

            public Person GetPerson(string name)
            {
                var json = File.ReadAllText(_filePath);
                var people = JsonConvert.DeserializeObject<Person[]>(json);

                foreach (var person in people)
                {
                    if (person.Name == name)
                    {
                        return person;
                    }
                }

                return null;
            }

            public void SavePerson(Person person)
            {
                var json = File.ReadAllText(_filePath);
                var people = JsonConvert.DeserializeObject<Person[]>(json).ToList();
                people.Add(person);

                var updatedJson = JsonConvert.SerializeObject(people.ToArray(), Formatting.Indented);
                File.WriteAllText(_filePath, updatedJson);
            }
        }

        public class Program
        {
            public static void Main()
            {
                var repository = new PersonRepository("people.json");
                var person = new Person
                {
                    Name = "John",
                    Age = 30,
                    Address = "123 Main St"
                };

                repository.SavePerson(person);

                var retrievedPerson = repository.GetPerson("John");
                Console.WriteLine($"Name: {retrievedPerson.Name}, Age: {retrievedPerson.Age}, Address: {retrievedPerson.Address}");
            }
        }



    }
}
