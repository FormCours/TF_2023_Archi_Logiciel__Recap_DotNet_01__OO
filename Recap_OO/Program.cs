using Recap_OO.Enums;
using Recap_OO.Models;


Teacher prof = new Teacher("Della", "Duck", new DateTime(1988, 2, 15), Person.GenreEnum.F, "Bstorm");
prof.AddSpecialization("Astronomie");
prof.AddSpecialization("JavaScript", "ASP.Net", "T-Sql");

Person zaza = new Student("Zaza", "Vanderquack", new DateTime(2001, 3, 4), Person.GenreEnum.F, "ZAZ01", TransportTypeEnum.BUS);

Student riri = new Student("Riri", "Duck", new DateTime(2000, 11, 3), Person.GenreEnum.M, "RFL01", TransportTypeEnum.BUS | TransportTypeEnum.CAR);
Student loulou = new Student("Loulou", "Duck", new DateTime(2001, 3, 9), Person.GenreEnum.M, "RFL02", TransportTypeEnum.BUS | TransportTypeEnum.CAR | TransportTypeEnum.BIKE);
Student fifi = new Student("Fifi", "Duck", new DateTime(2002, 5, 25), Person.GenreEnum.M, "RFL03", TransportTypeEnum.BUS | TransportTypeEnum.CAR);


Console.WriteLine("Information du prof : ");
Console.WriteLine($" - Nom : {prof.Fullname} Genre : {prof.Genre}");
Console.WriteLine($" - Entreprise : {prof.Company}");
Console.WriteLine($" - Spécialisation : {string.Join(", ", prof.Specialization)}.");
// Resultat attendu  « Spécialisation : astronomie, javascript, asp.net, t-sql. »

Formation formationFullStack = new Formation(
    "Dev FullStack .Net",
    3,
    new DateTime(2024, 1, 2),
    new DateTime(2024, 4, 10)
);
formationFullStack.MainTeacher = prof;
formationFullStack.AddCourse(".NET Fundamentals", "Intro DB", "ADO/LINQ/EF", "T-SQL", "JavaScript", "React");

formationFullStack.AddParticipant((Student) zaza);
formationFullStack.AddParticipant(riri);
formationFullStack.AddParticipant(fifi);
formationFullStack.AddParticipant(loulou);
formationFullStack.AddParticipant(loulou);

Console.WriteLine($"Limite de participant : {formationFullStack.NbMaxParticipants}");
Console.WriteLine($"Nombre de participant : {formationFullStack.Participants.Count()}");


Student s = formationFullStack["ZAZ01"];