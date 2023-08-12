namespace TrabalhoForca.MenuEntities;

public class MenuInitial{
  public void MenuStart(){
    int menuChoose = 0;

    do{
      try{
        Console.Clear();
        Console.WriteLine("Bem-Vindo ao Jogo da Forca!!!\n");
        Console.WriteLine("Escolha uma das opções abaixo!!!");
        Console.WriteLine("[1]Jogar\n[2]Sobre\n[3]Equipe\n[4]Sair");
        Console.Write("Escolha: ");
        menuChoose = int.Parse(Console.ReadLine());

        var menuSwitch = new MenuInitialSwitch(menuChoose);
        
        menuSwitch.StartSwitch();
      }
      catch{
        Console.Clear();

        Console.WriteLine("Escolha uma das opções válidas por gentileza!");
        Console.WriteLine("\n\nAperte uma tecla para retornar ao menu...");
            
        Console.ReadKey();
      }
    }
    while(menuChoose != 4);
  }
}