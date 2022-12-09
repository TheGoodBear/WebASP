ASP.Net Core (6.0) MVC EF (7.0)
-------------------------------

Démarrage
---------

Après avoir créé le(s) modèle(s)
Ouvrir Tools → Nuget package manager → Package manager console
Exécuter : Add-Migration InitialCreate
Si erreur, fermer puis relancer VS.
Exécuter : Update-Database


Mise à jour d'un modèle
-----------------------

Add-Migration <Nom de la migration>
Update-Database


Changer le nom et l'emplacement de la base de données
-----------------------------------------------------

Dans appsettings.json modifier DBContext :
    "DBContext": "Server=(localdb)\\mssqllocaldb;AttachDBFilename=[Full path]\\[DB name].mdf;Initial Catalog=[DB name];Trusted_Connection=True;MultipleActiveResultSets=true"


Bugs et manques de fonctionnalités Core EF 7 / Razor
----------------------------------------------------

Lier une liste select à une énumération
---------------------------------------

Dans les vues (cshtml) :
<select 
    asp-for="<field name>" 
    asp-items="@Html.GetEnumSelectList<[Model].[Enumeration]>()"
    class="form-control">
    <option selected="selected" value="">...</option>
</select>


Lier une clé étrangère à une table
----------------------------------

Dans les controlleurs :
ViewData["<Clé étrangère>"] = new SelectList(_context.<Table liée>, "Id", "<Champ affiché>", <modèle actuel>.<clé étrangère>);

 
Liaison des tables par clé étrangère dans le controlleur
--------------------------------------------------------

    public async Task<IActionResult> Index()
    {
        var ReturnValue = _context
            .Group
            .Include(t => t.Project)
            .ToListAsync();

        return View(await ReturnValue);
    }


Conventions Entity Framework et Propriétés nullables 
----------------------------------------------------

Conventions :
    PK : Id (ID ?) (id ?)
    Foreign Key : TableId

Exemple : 
    Person peut avoir 1 et un 1 seul Group
    Group peut avoir 0 à n Person
    Group peut avoir 1 et 1 seul Project
    Project peut avoir 0 à n Group

    Extrait de Group (convention FK Project, relation 0-n avec Person):
        public int IdProject { get; set; }
        //relations
        [ForeignKey("IdProject")]
        public virtual Project? Project { get; set; }
        public virtual List<Person>? Persons { get; set; }

    Extrait de Project (Description peut être null) : 
        // read/write (get/set) properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

