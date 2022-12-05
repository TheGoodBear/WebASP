namespace MVC2.ViewModels.Sample1;

public class View2VM
{

    public string Title { get; set; }
    public string? Name { get; set; }


    public View2VM(
        string? Name = null)
    {
        this.Title = "Nom du candidat";
        this.Name = Name;
    }

}
