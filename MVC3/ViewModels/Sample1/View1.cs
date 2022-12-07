namespace MVC3.ViewModels.Sample1;

public class View1VM
{

    public string Title { get; set; }
    public string? Name { get; set; }
    public int? BirthYear { get; set; }
    public int? Age => DateTime.Now.Year - BirthYear;
    //public int? Age
    //{
    //    get
    //    {
    //        return DateTime.Now.Year - BirthYear;
    //    }
    //}


    public View1VM(
        string? Name = null,
        int? BirthYear = null)
    {
        this.Title = "Page d'informations";
        this.Name = Name;
        this.BirthYear = BirthYear;
    }

}
