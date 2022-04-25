//Requirements:

using Models;
using Enums;


// Find and print all persons firstnames starting with 'R', ordered by Age - DESCENDING ORDER
List<Person> reqOne = DataBase.People.Where(person => person.FirstName[0] == 'R').OrderByDescending(person => person.Age).ToList();
HelperMethods<Person>.PrintEntity(reqOne);

// Find and print all persons firstnames and lastnames with job Dentist with age below 32
Console.WriteLine("===================================");
List<Person> reqTwo = DataBase.People.Where(person => person.Occupation == Job.Dentist && person.Age <= 32).ToList();
HelperMethods<Person>.PrintEntity(reqTwo);

// Find and print all brown dogs names and ages older than 3 years, ordered by Age - ASCENDING ORDER
Console.WriteLine("===================================");
List<Dog> reqThree = DataBase.Dogs.OrderBy(dog => dog.Age).Where(dog => dog.Color == "Brown" && dog.Age >= 3).ToList();
HelperMethods<Dog>.PrintEntity(reqThree);

// Find and print all persons names with more than 2 dogs, ordered by Name - DESCENDING ORDER
Console.WriteLine("===================================");
List<Person> reqFour = DataBase.People.Where(person => person.Dogs.Count > 2).OrderByDescending(person => person.FirstName).ToList();
HelperMethods<Person>.PrintEntity(reqFour);

// Find and print all black dogs names from race dalmatins, order by Age - ASCENDING ORDER
Console.WriteLine("===================================");
List<Dog> reqFive = DataBase.Dogs.Where(dog => dog.Color == "Black" && dog.Race == Race.Dalmatian).OrderBy(dog => dog.Age).ToList();
HelperMethods<Dog>.PrintEntity(reqFive);

// Find and print all Freddy`s dogs names older than 1 year
Console.WriteLine("===================================");
List<Dog> reqSix = DataBase.People.Single(person => person.FirstName == "Freddy").Dogs.Where(dog => dog.Age > 1).ToList();
HelperMethods<Dog>.PrintEntity(reqSix);

// Find and print all persons firstnames with job developer, don't have dogs and are younger than 25 years, order by age - ASCENDING ORDER
Console.WriteLine("===================================");
List<Person> reqSeven = DataBase.People.Where(person => person.Occupation == Job.Developer && person.Dogs.Count == 0 && person.Age < 25).OrderBy(person => person.Age).ToList();
HelperMethods<Person>.PrintEntity(reqSeven);

// Find and print Nathen`s first dog
Console.WriteLine("===================================");
Dog nathenDog = DataBase.People.SingleOrDefault(person => person.FirstName == "Nathen").Dogs[0];
Console.WriteLine(nathenDog.PrintInfo());

// Find and print all Freddy Gordin's dogs from race boxer and bulldog older than 1 year, ordered by name - DESCENDING ORDER
Console.WriteLine("===================================");
List<Dog> reqNine = DataBase.People.Single(person => person.FirstName == "Freddy" && person.LastName == "Gordon")
    .Dogs.Where(dog => dog.Race == Race.Boxer && dog.Age > 1 || dog.Race == Race.Bulldog).OrderByDescending(dog => dog.Name).ToList();
HelperMethods<Dog>.PrintEntity(reqNine);

// Find and print all white dogs names from Cristofer, Freddy, Erin and Amelia, ordered by Name - ASCENDING ORDER
Console.WriteLine("===================================");
List<Dog> reqTen = DataBase.People.Where(person => person.FirstName == "Cristofer" || person.FirstName == "Erin" || person.FirstName == "Amelia" || person.FirstName == "Freddy")
    .SelectMany(dog => dog.Dogs).Where(dog => dog.Color == "White").OrderBy(dog => dog.Name).ToList();
HelperMethods<Dog>.PrintEntity(reqTen);
