namespace MVC3.ViewModels.Home;

public class IndexVM
{

    public string Title { get; set; }
    public string? Name { get; set; }
    public string? Link { get; set; }
    public string? Skills { get; set; }


    public IndexVM(
        string? Name = null,
        string? Link = null,
        string? Skills = null)
    {
        this.Title = "Page d'accueil";
        this.Name = Name;
        this.Link = Link;
        this.Skills = Skills;
    }

}
