using Microsoft.VisualBasic;
using TrabalhoForca.GameEntities;

namespace TrabalhoForca.MenuEntities;

public class TopicsMenuSwitch{
  public string Word { get; set; } = string.Empty;
  public bool ExitCondition { get; set; } = false;

  public bool StartSwitch(int switchChoose){

    switch(switchChoose){
      case 1:
        Movies();

        StartGame();
        break;

      case 2:
        SoccerTeams();

        StartGame();
        break;

      case 3:
        Games();

        StartGame();
        break;

      case 4:
        Characters();

        StartGame();
        break;
      
      case 5:
        Sports();

        StartGame();
        break;
      
      case 6:
        Random();
        break;

      case 7:
        Returning();
        break;

      default:
        Default();
        break;
    }

    return ExitCondition;
  }
  public void Movies(){
    List<string> MoviesList = new List<string>{
      "Titanic", "Avatar", "A Ilha do Medo", "Efeito Borboleta",
      "Rede Social", "Star Wars", "Star Trek", "Pulp Fiction"
    };

    WordChoose(MoviesList);
  }

  public void SoccerTeams(){
    List<string> SoccerTeamsList = new List<string>{
      "Vasco", "Flamengo", "Fluminense", "Botafogo", 
      "Internacional", "Gremio", "Barcelona", "Camboriu"
    };

    WordChoose(SoccerTeamsList);
  }

  public void Games(){
    List<string> GamesList = new List<string>{
      "League Of Legends", "Valorant", "CSGO", "World of Warcraft",
      "Hollow Knight", "Elden Ring", "Dark Souls", "God of War"
    };

    WordChoose(GamesList);
  }

  public void Characters(){
    List<string> CharactersList = new List<string>{
      "Batman", "Goku", "Flash", "Miranha",
      "Ribamar", "Peter Parker", "Asa Noturna", "DeadPool"
    };

    WordChoose(CharactersList);
  }

  public void Sports(){
    List<string> SportsList = new List<string>{
      "Futebol", "Volei", "Handball", "Beisebol",
      "Futebol Americano", "Ginastica", "Atletismo", "Triatlo"
    };

    WordChoose(SportsList);
  }

  public void WordChoose(List<string> wordsList){
    var randomNumberGenerate = new Random();

    var randomNumber = randomNumberGenerate.Next(0, wordsList.Count);

    Word = wordsList[randomNumber];
  }

  public void StartGame(){
    GamesStart GamesStart = new GamesStart(Word);

    ExitCondition = GamesStart.StartGame();
  }

  public void Random(){
    var randomNumberGenerate = new Random();

    var randomNumber = randomNumberGenerate.Next(1, 6);

    StartSwitch(randomNumber);
  }

  public static void Returning(){
    Console.Clear();

    Console.WriteLine("Retornando ao Menu...");

    Thread.Sleep(3000);
    Console.Clear();
  }

  public static void Default(){
    Console.Clear();

    Console.WriteLine("Escolha uma das opções válidas por gentileza!");
    Console.WriteLine("\n\nAperte uma tecla para retornar ao menu...");
            
    Console.ReadKey();
  }
}