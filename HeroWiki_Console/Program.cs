using HeroWiki.Shared.Data.DB;
using HeroWiki_Console;


var HeroDAL = new HeroDAL();
var heroList = HeroDAL.Read();
foreach ( var hero in heroList ) Console.WriteLine(hero);

HeroDAL.Create(new Hero("Garoto Goma", "Flexibilidade!"));

heroList = HeroDAL.Read();
foreach (var hero in heroList) Console.WriteLine(hero);

return;

Dictionary<string, Hero> HeroDict = new();

bool exit = false;
while (!exit)
{
    Console.WriteLine("Você chegou na HEROWIKI!\n");
    Console.WriteLine("Digite 1 para registrar um herói");
    Console.WriteLine("Digite 2 para registrar um poder de herói");
    Console.WriteLine("Digite 3 para mostrar todos os heróis");
    Console.WriteLine("Digite 4 para mostrar os poderes de um herói");
    Console.WriteLine("Digite -1 para sair\n");

    Console.Write("Digite sua opção: ");
    int option = int.Parse(Console.ReadLine());

    switch (option)
    {
        case 1:
            HeroRegister();
            break;
        case 2:
            PowerRegister();
            break;
        case 3:
            HeroGet();
            break;
        case 4:
            PowerGet();
            break;
        case -1:
            Console.WriteLine("Tchau, obrigado!");
            exit = true;
            break;
        default:
            Console.WriteLine("Escolha inválida");
            break;
    }
    Thread.Sleep(1500);
    Console.Clear();
}

void PowerGet()
{
    Console.Clear();
    Console.WriteLine("Listagem de Poder\n");
    Console.Write("Digite o herói cujo poder você quer listar: ");
    string heroName = Console.ReadLine();
    if (HeroDict.ContainsKey(heroName))
    {
        Hero hero = HeroDict[heroName];
        hero.ShowPowers();
    }
    else Console.WriteLine($"Herói {heroName} não encontrado");
}

void HeroGet()
{
    Console.Clear();
    Console.WriteLine("Listagem de Heróis\n");
    foreach(var hero in HeroDict.Values)
    {
        Console.WriteLine(hero);
    }
}

void PowerRegister()
{
    Console.Clear();
    Console.WriteLine("Registro de Poder\n");
    Console.Write("Digite o herói cujo poder você quer registrar: ");
    string heroName = Console.ReadLine();
    if (HeroDict.ContainsKey(heroName))
    {
        Console.Write($"Qual o nome do poder de {heroName}? ");
        string powerName = Console.ReadLine();
        Hero hero = HeroDict[heroName];
        hero.AddPower(new Power(powerName));
        Console.WriteLine($"Poder {powerName} de {heroName} adicionado!");
    }
    else Console.WriteLine($"Herói {heroName} não encontrado");
}

void HeroRegister()
{
    Console.Clear();
    Console.WriteLine("Registro de Heróis\n");
    Console.Write("Digite o nome do herói: ");
    string name = Console.ReadLine();
    Console.Write("Digite o bordão do herói: ");
    string slogan = Console.ReadLine();
    Hero hero = new Hero(name, slogan);
    HeroDict.Add(name, hero);
    Console.WriteLine($"Herói {name} adicionado!");
}