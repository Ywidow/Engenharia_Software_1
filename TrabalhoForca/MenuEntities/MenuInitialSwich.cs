namespace TrabalhoForca.MenuEntities;

public class MenuInitialSwitch{
  public int MenuChoose { get; set; } = 0;
  public TopicsMenu TopicsMenu { get; set; } = new();

  public void StartSwitch(){
    switch(MenuChoose){
      case 1:
        TopicsMenu.StartTopicsMenu();
        break;

      case 2:
        About();

        break;

      case 3:
        Team();

        break;

      case 4:
        Exit();

        break;

      default:
        Default();

        break;
    }
  }
  public void About(){
    Console.Clear();
    Console.WriteLine("Sobre:");
    Console.WriteLine("Uma palavra será sorteada em relação ao tópico escolhido por você.");
    Console.WriteLine("Após a palavra ser gerada, irá aparecer a quantidade de letrar atráves do número de '_' no console.");
    Console.WriteLine("Você terá que escolher uma letra por escolha...");
    Console.WriteLine("Caso você tenha acertado a letra, irá aperecer no console a posição da letra...");
    Console.WriteLine("Mas caso você tenha errado, irá aparecer uma parte do boneco da forca...");
    Console.WriteLine("Caso você junte as 6 partes do boneco, o jogo será encerrado...");
    Console.WriteLine("\nPressione uma tecla para continuar...");

    Console.ReadKey();
    Console.Clear();
  }

  public void Team(){
    Console.Clear();

    Console.WriteLine("Equipe de Desenvolvimento:");
    Console.WriteLine("Guilherme Thomy\nVinicius Peireira\nTaryck Santos\nCândido Neto");

    Console.WriteLine("\nProfessor:");
    Console.WriteLine("Thiago Felski Pereira");

    Console.WriteLine("\nMatéria:");
    Console.WriteLine("Engenharia de Software I");

    Console.WriteLine("\n\nAperte uma tecla para retornar ao menu...");
    Console.ReadKey();
  }

  public void Exit(){
    Console.Clear();

    Console.WriteLine("Obrigado por utilzar nosso software!!!");
    Console.WriteLine("\nVolte Sempre!!!");

    Thread.Sleep(3000);
    Console.Clear();
  }

  public void Default(){
    Console.Clear();

    Console.WriteLine("Escolha uma das opções válidas por gentileza!");
    Console.WriteLine("\n\nAperte uma tecla para retornar ao menu...");
            
    Console.ReadKey();
  }

  public MenuInitialSwitch(int menuChoose){
    MenuChoose = menuChoose;
  }
}