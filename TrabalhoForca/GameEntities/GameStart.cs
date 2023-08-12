namespace TrabalhoForca.GameEntities;

public class GamesStart{
  private string _word { get; set; } = string.Empty;
  private char[,] _puppetNow { get; set; }= new char[10,10];

  public bool StartGame(){
    var wordInVector = _word.ToLower().ToCharArray(); //Transforma a palavra em um vetor de caracteres, e coloca a frase toda em lowercase.
    var stringShowed = string.Empty; //String que irá ser apresentada no console.

    for(int i = 0; i < wordInVector.Length; i++){ //Transformando a stringShowed.
      if(wordInVector[i] == ' '){
        stringShowed += "  ";
      }
      else{
        stringShowed += "_ ";
      }
    }

    var errorsCounter = 0;
    var win = false;
    var alreadyPlayedThatLetter = false;
    List<char> wrongLetters = new();
    List<char> lettersPlayed = new();
    PrintsGame prints = new PrintsGame();

    while(win == false && errorsCounter != 7){
      PuppetManipulation(errorsCounter);

      alreadyPlayedThatLetter = prints.InitPrint(_puppetNow, wrongLetters, stringShowed, alreadyPlayedThatLetter);
      
      if(errorsCounter < 6){
        Console.Write("Digite a letra: ");
        string phrase = Console.ReadLine().ToLower().Replace(" ", "");
        
        var phraseInChar = phrase.ToCharArray();

        if(phraseInChar.Length == 1){
          if(lettersPlayed.Contains(phraseInChar[0])){
            alreadyPlayedThatLetter = true;
          }
          else{
            lettersPlayed.Add(phraseInChar[0]);

            var containsThisLetter = _word.ToLower().Contains(phraseInChar[0]);

            if(containsThisLetter){
              var counter = 0;

              foreach(var letter in wordInVector){
                if(letter == phraseInChar[0]){
                  var stringShowedToVector = stringShowed.ToCharArray();

                  stringShowedToVector[counter + counter] = letter;

                  var stringToChange = new string(stringShowedToVector);

                  stringShowed = stringToChange;
                }

                counter++;
              }

              if(stringShowed.Replace(" ", "") == _word.Replace(" ", "").ToLower()){
                win = true;
              }
            }
            else{
              wrongLetters.Add(phraseInChar[0]);
              errorsCounter++;
            }
          }
        }
        else{
          Console.Clear();

          Console.WriteLine("Digite apenas uma letra!!!");
          Console.WriteLine("\n Retornando ao jogo...");
          
          Thread.Sleep(3000);
        } 
      }
      else{
        Thread.Sleep(3000);

        errorsCounter++;
      }
    }

    if(win){
      Console.Clear();

      Console.WriteLine("PARABÉNS VOCÊ ACERTOU A PALAVRA!!!");
      Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");

      Console.ReadKey();

      return true;
    }
    else{
      Console.Clear();

      Console.WriteLine("Infelizmente você perdeu...\nNão desista!");
      Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");

      Console.ReadKey();

      return false;
    }
  }

  public void PuppetManipulation(int errorsCounter){
    PuppetGameMatrice puppetStages = new();

    switch(errorsCounter){
        case 0:
          _puppetNow = puppetStages.Matriz1;
          break;

        case 1:
          _puppetNow = puppetStages.Matriz2;
          break;

        case 2:
          _puppetNow = puppetStages.Matriz3;
          break;
        
        case 3:
          _puppetNow = puppetStages.Matriz4;
          break;

        case 4:
          _puppetNow = puppetStages.Matriz5;
          break;

        case 5:
          _puppetNow = puppetStages.Matriz6;
          break;

        case 6:
          _puppetNow = puppetStages.Matriz7;
          break;
      }
  }
  
  public GamesStart(string word){
    _word = word;
  }
}