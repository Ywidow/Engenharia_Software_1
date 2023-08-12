namespace TrabalhoForca.MenuEntities;

public class TopicsMenu{
  public bool ExitCondition { get; set; } = false;

  public void StartTopicsMenu(){
    var TopicsMenuChoose = 0;

    do{
      try
      {
        Console.Clear();
        Console.WriteLine("Menu dos Tópicos\n");
        Console.WriteLine("[1]Filmes\n[2]Times\n[3]Jogos\n[4]Personagens\n[5]Esportes\n[6]Random\n[7]Voltar");
        Console.Write("Escolha: ");
        TopicsMenuChoose = int.Parse(Console.ReadLine());

        var topicsMenuSwitch = new TopicsMenuSwitch();

        ExitCondition = topicsMenuSwitch.StartSwitch(TopicsMenuChoose);
      }
      catch
      {
        Console.Clear();

        Console.WriteLine("Escolha uma das opções válidas por gentileza!");
        Console.WriteLine("\n\nAperte uma tecla para retornar ao menu...");
            
        Console.ReadKey();
      }
    }
    while(TopicsMenuChoose != 7 && !ExitCondition);
  }
}