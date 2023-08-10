// Random Guesser

void BoasVindas()
{
    Console.WriteLine(@"
        
██████████████████████████████████████████████▀██████████████████████████████████████
█▄─▄▄▀██▀▄─██▄─▀█▄─▄█▄─▄▄▀█─▄▄─█▄─▀█▀─▄███─▄▄▄▄█▄─██─▄█▄─▄▄─█─▄▄▄▄█─▄▄▄▄█▄─▄▄─█▄─▄▄▀█
██─▄─▄██─▀─███─█▄▀─███─██─█─██─██─█▄█─████─██▄─██─██─███─▄█▀█▄▄▄▄─█▄▄▄▄─██─▄█▀██─▄─▄█
▀▄▄▀▄▄▀▄▄▀▄▄▀▄▄▄▀▀▄▄▀▄▄▄▄▀▀▄▄▄▄▀▄▄▄▀▄▄▄▀▀▀▄▄▄▄▄▀▀▄▄▄▄▀▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▀▄▄▀
   ");
    Console.WriteLine(@"
Seja bem vindo ao Random Guesser!
Estou pensando em número entre 1 e 100. Consegue descobrir qual é?");
}

BoasVindas();
JogarJogo();

int NumeroSecreto()
{
    Random random = new Random();
    int numeroSecreto = random.Next(1, 101);
    return numeroSecreto;
}

void JogarNovamente()
{
    Console.Write("\nQuer jogar novamente? Digite '1' para sim ou '2' para não: ");
    string jogarNovamente = Console.ReadLine()!;
    switch (jogarNovamente)
    {
        case "1":
            NumeroSecreto();
            JogarJogo();
            break;
        case "2":
            Console.WriteLine(@"
Tudo bem. Obrigado por jogar, e até a próxima!
Fechando aplicação...                           
                    ");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

void GameOver(int numero)
{

    Console.WriteLine($"\nGAME OVER. Sinto muito, você esgotou suas tentativas. O número secreto era {numero}");
    JogarNovamente();
}
void JogarJogo()
{
    int tentativas = 7;
    int numeroSecreto = NumeroSecreto();
    do
    {
        Console.Write("\nDigite um número entre 1 e 100: ");
        string chute = Console.ReadLine()!;
        int chuteNumero = int.Parse(chute);

        if (chuteNumero < 1 || chuteNumero > 100)
        {
            tentativas--;
            if (tentativas == 1)
            {
                Console.WriteLine(@"
Sim, eu percebo quando você tenta chutar um número que não esteja entre 1 e 100.
Perdeu uma tentativa só pela brincadeira. Esta será sua última tentativa.");
            }
            else if (tentativas == 0)
            {
                GameOver(numeroSecreto);
                break;
            }
            else
            Console.WriteLine(@$"
Sim, eu percebo quando você tenta chutar um número que não esteja entre 1 e 100.
Perdeu uma tentativa só pela brincadeira. Te restam {tentativas} tentativas.");
        }

        else if (chuteNumero > numeroSecreto)
        {
            tentativas--;
            if (tentativas == 1)
            {
                Console.WriteLine($"\nVocê errou. O número secreto é menor que {chute}. Esta será sua ÚLTIMA tentativa!");
            
            }
            if (tentativas == 0)
            {
                GameOver(numeroSecreto);
                break;
            }
            else
            {
                Console.WriteLine($"\nVocê errou. O número secreto é menor que {chute}. Você tem mais {tentativas} tentativas.");
            }
        }
        else if (chuteNumero < numeroSecreto)
        {
            tentativas--;
            if (tentativas == 1)
            {
                Console.WriteLine($"\nVocê errou. O número secreto é menor que {chute}. Esta será sua ÚLTIMA tentativa!");
            }
            if (tentativas == 0 /*&& chuteNumero != numeroSecreto*/)
            {
                GameOver(numeroSecreto);
                break;
            }
            else
            {
                Console.WriteLine($"\nVocê errou. O número é maior que {chute}. Você tem mais {tentativas} tentativas.");
            }
            
        }
       
        else
        {
            Console.WriteLine($"\nParabéns, você acertou! O Número secreto era {numeroSecreto}");
            JogarNovamente();

            break;
        }
    } while (true);
}


