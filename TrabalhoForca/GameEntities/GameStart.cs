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
    var exitWinCondition = false;
    var alreadyPlayedThatLetter = false;
    List<char> wrongLetters = new();
    List<char> lettersPlayed = new();
    PrintsGame prints = new PrintsGame();

    while(exitWinCondition == false && errorsCounter != 7){ //Enquanto o user não vencer ou não perder, irá rodar o código.
      PuppetManipulation(errorsCounter); //Manipulação da matriz mostrada ao jogador em relação ao número de erros.

      //Prints do jogo.
      alreadyPlayedThatLetter = prints.InitPrint(_puppetNow, wrongLetters, stringShowed, alreadyPlayedThatLetter); 
      
      if(errorsCounter < 6 && win != true){ //O Menu de aplicação só será mostrado caso não tenha vencido ou perdido
        Console.Write("Digite a letra: ");
        string phrase = Console.ReadLine().ToLower().Replace(" ", ""); //Manipulando a string inserida pelo user
        
        var phraseInChar = phrase.ToCharArray(); //Transformando a string inserida pelo user em um vetor char

        if(phraseInChar.Length == 1){ //Caso o tamanho do vetor seja 1, ou seja, ele tenha inserido apenas uma letra
          if(lettersPlayed.Contains(phraseInChar[0])){ //Condição para ver se a letra ja foi jogada ou não
            alreadyPlayedThatLetter = true;
          }
          else{
            lettersPlayed.Add(phraseInChar[0]); //Adiciona a letra jogada na lista de letras ja jogadas.

            var containsThisLetter = _word.ToLower().Contains(phraseInChar[0]); //Verificando se contem a letra digitada pelo user na palavra

            if(containsThisLetter){ //Caso contenha
              var counter = 0;

              foreach(var letter in wordInVector){ //Verificando todas as letras da palavra definida
                if(letter == phraseInChar[0]){ //Caso a letra da palavra definida seja igual a letra inserida pelo user
                  var stringShowedToVector = stringShowed.ToCharArray(); //Atribuindo na variável a string mostrada em um vetor char

                  /*
                    Nesta parte foi feito um cálculo para poder substitiuir as letras da string mostrada
                    para a palavra inserida, devido aos espaços entre cada "_".
                  */
                  stringShowedToVector[counter + counter] = letter; 

                  var stringToChange = new string(stringShowedToVector); //Transformando a stringshowed vetorizada em uma string

                  stringShowed = stringToChange; //Atribuindo o valor alterado para a string mostrada
                }

                counter++;
              }

              if(stringShowed.Replace(" ", "") == _word.Replace(" ", "").ToLower()){ //Verificação de vitórioa
                win = true;
              }
            }
            else{ //Caso não contenha a letra inserida pelo user na palavra
              wrongLetters.Add(phraseInChar[0]); //Adicionar a letra na lista de letrar erradas.
              errorsCounter++; //Aumenta o contador da derrota.
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
      else if(win == true){ //Pause para o user ver que ele venceu
        Thread.Sleep(3000);

        exitWinCondition = true;
      }
      else{ //Pause para o user ver que ele perdeu
        Thread.Sleep(3000);

        errorsCounter++;
      }
    }

    if(win){ //Caso ele tenha ganho aparecerá essas mensagens na tela
      Console.Clear();

      Console.WriteLine("PARABÉNS VOCÊ ACERTOU A PALAVRA!!!");
      Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");

      Console.ReadKey();

      return true;
    }
    else{ //Caso ele tenha perdido aparecerá essas mensagens na tela
      Console.Clear();

      Console.WriteLine("Infelizmente você perdeu...\nNão desista!");
      Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");

      Console.ReadKey();

      return false;
    }
  }

  public void PuppetManipulation(int errorsCounter){ //Manipulações da matriz mostrada em relação ao contador de erro
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
  
  public GamesStart(string word){ //Construtor
    _word = word;
  }
}
