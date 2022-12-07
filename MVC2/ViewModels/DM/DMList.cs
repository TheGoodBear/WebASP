using MVC3.Models;

namespace MVC3.ViewModels.DM;

public class DMListVM
{

    // view properties
    public string Title { get; set; }


    // model data properties
    public List<Person> Persons { get; set; } = new List<Person>();


    // constructor
    public DMListVM()
    {
        InitializeData();
        Title = $"Liste des {Persons.Count} étudiants";
    }

    private void InitializeData()
    {
        //Persons.Add(new Person("Micalaudie", "Alain", "M", 1967));
        Persons.Add(new Person("Audisso", "Julien", Person.eSex.Masculin, 1985, Person.eITLevel.Intermédiaire, Person.eLocation.Présentiel, 1));
        Persons.Add(new Person("Moniz", "David", Person.eSex.Masculin, 1996, Person.eITLevel.Intermédiaire, Person.eLocation.Présentiel, 4));
        Persons.Add(new Person("Ibombo", "Borel", Person.eSex.Masculin, 2001, Person.eITLevel.Intermédiaire, Person.eLocation.Présentiel, 5));
        Persons.Add(new Person("Velin", "Daïka", Person.eSex.Féminin, 1989, Person.eITLevel.Débutant, Person.eLocation.Présentiel, 4));
        Persons.Add(new Person("Chaieb", "Rania", Person.eSex.Féminin, 1996, Person.eITLevel.Intermédiaire, Person.eLocation.Distanciel, 4));
        Persons.Add(new Person("Ghaem", "Hamid", Person.eSex.Masculin, 1963, Person.eITLevel.Intermédiaire, Person.eLocation.Présentiel, 2));
        Persons.Add(new Person("Hijazi", "Samer", Person.eSex.Masculin, 1972, Person.eITLevel.Intermédiaire, Person.eLocation.Présentiel, 2));
        Persons.Add(new Person("Molla", "Jean-Pierre", Person.eSex.Masculin, 1984, Person.eITLevel.Avancé, Person.eLocation.Présentiel, 1));
        Persons.Add(new Person("Lependu", "Thierry", Person.eSex.Masculin, 1995, Person.eITLevel.Avancé, Person.eLocation.Présentiel, 3));
        Persons.Add(new Person("Diaby", "Alhousseny", Person.eSex.Masculin, 2000, Person.eITLevel.Intermédiaire, Person.eLocation.Présentiel, 5));
        Persons.Add(new Person("Sadat", "Lyes", Person.eSex.Masculin, 1987, Person.eITLevel.Débutant, Person.eLocation.Présentiel, 3));
        Persons.Add(new Person("Haj kacem", "Slim", Person.eSex.Masculin, 1986, Person.eITLevel.Avancé, Person.eLocation.Présentiel, 2));
        Persons.Add(new Person("Aliouchouche", "Tarek", Person.eSex.Masculin, 1971, Person.eITLevel.Intermédiaire, Person.eLocation.Présentiel, 1));
        Persons.Add(new Person("Ait Ben Ahmed", "Mohamed", Person.eSex.Masculin, 1986, Person.eITLevel.Intermédiaire, Person.eLocation.Présentiel, 5));
    }


}
