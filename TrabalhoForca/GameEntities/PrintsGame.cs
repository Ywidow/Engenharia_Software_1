namespace TrabalhoForca.GameEntities;

public class PrintsGame{

  public bool InitPrint(char[,] puppetNow, List<char> wrongLetters, string stringShowed, bool alreadyPlayedThatLetter){
    Console.Clear();
    
    if(alreadyPlayedThatLetter){
      Console.WriteLine("Letra já jogada...");
    }
    
    PuppetPrint(puppetNow);

    WrongLettersPrint(wrongLetters);

    Console.WriteLine("\nFrase: " + stringShowed);

    return false;
  }

  public void PuppetPrint(char[,] puppetNow){
    for(int lines = 0; lines < 10; lines++){
      for(int columns = 0; columns < 10; columns++){
        Console.Write(puppetNow[lines, columns]);
      }
      Console.WriteLine();
    }
  }

  public void WrongLettersPrint(List<char> wrongLetters){
    if(wrongLetters.Count() != 0){
      Console.Write("Letras Erradas: ");
      for(int i = 0; i < wrongLetters.Count() + 1; i++){
        if(i == 0){
          Console.Write("[ ");
        }
        else if(i == wrongLetters.Count()){
          Console.Write("]");
        }

        if(i < wrongLetters.Count()){
          Console.Write(wrongLetters[i] + " ");
        }
      }
    }
  }
}