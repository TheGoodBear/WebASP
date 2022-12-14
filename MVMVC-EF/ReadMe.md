ASP.Net Core (6.0) MVC EF (7.0)
-------------------------------

Pour un nouveau projet C# ASP.Net Core MVC avec Entity Framework

1 - Vérification du nouveau projet
----------------------------------

Vérifier que le nouveau projet s'exécute avec le code minimum généré à la création du projet


2 - Vérification des packages
-----------------------------

Vérifier l'installation des packages Nuget pour le projet

Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.VisualStudio.Web.CodeGeneration.Design

La version testée et fonctionnelle est 6.0.10


3 - Configurer le DBContext
---------------------------

Dans appsettings.json ajouter ou modifier :
    "ConnectionStrings": {
        "DBContext": "Server=(localdb)\\mssqllocaldb;AttachDBFilename=[Full path]\\[DB name].mdf;Initial Catalog=[DB name];Trusted_Connection=True;MultipleActiveResultSets=true"
    }

Remplacer [Full path] et [DB name] par vos propres informations
Penser à n'avoir que des \\ (pas de simple ni de quadruple)


4 - Modèles
-----------

Créer ou copier les modèles dans le dossier Models (bien vérifier les namespaces)


5 - Créer un premier controlleur
--------------------------------

Clic droit sur le dossier "Controllers" puis sélectionner "MVC Controller with views using Entity Framework" 

Dans la fenêtre suivante :
- Model class : sélectionner votre modèle
- DBContext class : cliquer sur "+" puis renommer la classe (le dernier membre) DBContext
- laisser toutes les options cochées
- renommer le nom du Controller en [Modèle]Controller où [Model] est le nom exacte (non pluralisé) de votre modèle

Lancer la génération du code


6 - Création de la base de données
----------------------------------

Ouvrir Tools → Nuget package manager → Package manager console
Exécuter : Add-Migration InitialCreate
Si erreur, fermer puis relancer VS.
Exécuter : Update-Database



Après chaque mise à jour d'un modèle
------------------------------------

Add-Migration <Nom de la migration>
Update-Database



Résolution des bugs et manques de fonctionnalités Core EF 7 / Razor
-------------------------------------------------------------------


Lier une liste select à une énumération
---------------------------------------

Dans les vues (cshtml) :
<select 
    asp-for="[FieldName]" 
    asp-items="@Html.GetEnumSelectList<[Model].[Enumeration]>()"
    class="form-control">
    <option selected="selected" value="">...</option>
</select>

Remplacer [FieldName], [Model] et [Enumeration] par vos informations


Lier une liste select à une autre table via une clé étrangère
-------------------------------------------------------------

Dans les controlleurs :
ViewData["<Clé étrangère>"] = new SelectList(_context.<Table liée>, "Id", "<Champ affiché>", <modèle actuel>.<clé étrangère>);

Remplacer <Clé étrangère>, <Table liée>, <Champ affiché> et <modèle actuel> par vos informations
 

Liaison des tables via une clé étrangère dans le controlleur
------------------------------------------------------------

Par exemple :

    public async Task<IActionResult> Index()
    {
        var ReturnValue = _context
            .Group
            .Include(t => t.Group)
            .ThenInclude(t => t.Project)
            .ToListAsync();

        return View(await ReturnValue);
    }

Maximum un .Include, plusieurs .ThenInclude possibles selon les besoins (suivre le chemin dans le modèle de données comme pour des INNER JOIN SQL)


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


Ressources diverses
-------------------

Bootstrap
---------

Icônes : https://icons.getbootstrap.com/ 
Propriétés : https://www.w3schools.com/bootstrap/bootstrap_ref_all_classes.asp
