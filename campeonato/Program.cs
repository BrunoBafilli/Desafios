string equipesTXT = "Allegoric Alaskans;Blithering Badgers;win" +
                 "Devastating Donkeys;Courageous Californians;draw" +
                 "Devastating Donkeys;Allegoric Alaskans;win" +
                 "Courageous Californians;Blithering Badgers;loss" +
                 "Blithering Badgers;Devastating Donkeys;loss" +
                 "Allegoric Alaskans;Courageous Californians;win";

string[] keys = new string[3] { "win", "loss", "draw" };

calcLinhasColunas(out int linhas, out int colunas);

string[,] DadosEstruturados2D = estruturamentoDosDados();

string[] equipes = vetorEquipesSemRepetirEquipe();
int[] totaljogos = vetorParquitasDisputadas(); 
int[] vitorias = vetorJogosGanhos();
int[] empates = vetorJogosEmpatados();
int[] derrotas = vetorJogosPerdidos();
int[] pontos = vetorPontuacao();
ordenandoVetores();

Console.WriteLine("------------------------------------------------");
Console.WriteLine("Team               | MP |  W |  D |  L |  P");
for (int i = 0; i < equipes.Length; i++)
{
    Console.WriteLine($"{equipes[i]} - {totaljogos[i]} - {vitorias[i]} - {empates[i]} - {derrotas[i]} - {pontos[i]}");
}

void calcLinhasColunas(out int linhas, out int colunas)
{
    linhas = 0;
    colunas = 1;
    
    string tempFrase = "";
    for (int et = 0; et < equipesTXT.Length; et++)
    {
        bool breakFor = false;
        tempFrase += equipesTXT[et];
        if (equipesTXT[et] == ';'){
            colunas++;
            tempFrase = "";
        }
        for (int k = 0; k < keys.Length; k++)
            if (tempFrase == keys[k])
                breakFor = true;
        if (breakFor)
            break;
    }
    tempFrase = "";
    for (int et = 0; et < equipesTXT.Length; et++)
    {
        tempFrase += equipesTXT[et];
    
        if (equipesTXT[et] == ';')
            tempFrase = "";
    
        for (int k = 0; k < keys.Length; k++)
            if (tempFrase == keys[k]){
                linhas++;
            }
    }
}

string[,] estruturamentoDosDados(){
    
    string[,] equipes2D = new string[linhas, colunas];
    
    int ultimaInsercao = -1;
    for (int l = 0; l < linhas; l++)
    {
        for (int c = 0; c < colunas; c++)
        {
            string tempFrase = "";

            while (ultimaInsercao < equipesTXT.Length -1)
            {
                ultimaInsercao++;
                
                //vErifica se e winlose
                bool ehWinLose = false;
                for (int k = 0; k < keys.Length; k++)
                {
                    if (keys[k] == tempFrase) {
                        ehWinLose = true;
                        ultimaInsercao--;
                    }
                }
                if (ehWinLose) break;
                
                //Verifica se tem ; e quebra para o proximo indice
                if(equipesTXT[ultimaInsercao] != ';'){
                    tempFrase += equipesTXT[ultimaInsercao];
                    continue;
                }
                break;
            }

            equipes2D[l, c] = tempFrase;
        }
    }

    return equipes2D;
}

string[] vetorEquipesSemRepetirEquipe()
{
    string[] tempEquipes = new string[DadosEstruturados2D.Length];
    //adiciona todas as equipes no vetor equipes
    int tempCountEquipe = 0;
    for (int l = 0; l < linhas; l++)
    {
        for (int c = 0; c < colunas -1; c++)
        {
            tempEquipes[tempCountEquipe] = DadosEstruturados2D[l,c];
            tempCountEquipe++;
        }    
    }
    //cria um novo vetor sem espacos
    string[] equipes = new string[tempCountEquipe];
    int countEquipe = 0;
    for (int te = 0; te < equipes.Length; te++)
    {
        if (tempEquipes[te] != null){
            equipes[countEquipe] = tempEquipes[te];
            countEquipe++;
        }
    }

    //cria um novo vetor sem repetir as equipes
    string[] nEquipes = new string[equipes.Length];
    int countAddEquipe = 0;
    for (int e = 0; e < equipes.Length; e++)
    {
        bool adicionar = true;
        for (int ne = 0; ne < nEquipes.Length; ne++)
        {
            if(equipes[e] == nEquipes[ne]){
                adicionar = false;
                break;
            }
        }
        if (adicionar)
        {
            if (nEquipes == null) 
                continue;
            nEquipes[countAddEquipe] = equipes[e];
            countAddEquipe++;
        }
    }
    
    //cria um novo vetor de equipes sem espaco
    int tamanhoNovoVetorEquipe = 0;
    for (int t = 0; t < nEquipes.Length; t++)
        if (nEquipes[t] != null)
            tamanhoNovoVetorEquipe++;
    
    //vetor equipes somente com equipes sem repetir e sem espaco
    equipes = new string[tamanhoNovoVetorEquipe];
    for (int t = 0; t < equipes.Length; t++)
        equipes[t] = nEquipes[t];

    return equipes;
}

int[] vetorParquitasDisputadas()
{
    int[] totalJogos = new int[equipes.Length];
    for (int e = 0; e < equipes.Length; e++)
    {
        int countJogos = 0;
        for (int l = 0; l < linhas; l++)
        {
            for (int c = 0; c < colunas; c++)
            {
                if (equipes[e] == DadosEstruturados2D[l, c])
                {
                    countJogos++;
                }           
            }
        }
        totalJogos[e] = countJogos;
    }

    return totalJogos;
}

int[] vetorJogosGanhos()
{

    int[] vitorias = new int[equipes.Length];

    int countVencedores = 0;
    
        

        for (int e = 0; e < equipes.Length; e++)
        {
            int countVitorias = 0;
            for (int l = 0; l < linhas; l++)
            {
                if (DadosEstruturados2D[l, 0] == equipes[e] && DadosEstruturados2D[l,2] == "win")
                {
                    countVitorias++;
                }
            }
            vitorias[countVencedores] = countVitorias;
            countVencedores++;
        }

    return vitorias;
}

int[] vetorJogosEmpatados()
{

    int[] empates = new int[equipes.Length];

    int countVencedores = 0;
    
    for (int e = 0; e < equipes.Length; e++)
    {
        int countVitorias = 0;
        for (int l = 0; l < linhas; l++)
        {
            for(int c = 0; c < colunas; c++)
            {
                if (DadosEstruturados2D[l, c] != equipes[e] || DadosEstruturados2D[l, 2] != "draw") continue;
                countVitorias++;
            }
        }
        empates[countVencedores] = countVitorias;
        countVencedores++;
    }

    return empates;
}

int[] vetorJogosPerdidos()
{

    int[] derrotas = new int[equipes.Length];

    int countDerrotados = 0;
    
    for (int e = 0; e < equipes.Length; e++)
    {
        int countDerrotas = 0;
        for (int l = 0; l < linhas; l++)
        {
            if (DadosEstruturados2D[l, 0] == equipes[e] && DadosEstruturados2D[l,2] == "loss")
            {
                countDerrotas++;
            }
        }
        derrotas[countDerrotados] = countDerrotas;
        countDerrotados++;
    }

    return derrotas;
}

int[] vetorPontuacao()
{

    int[] pontuacao = new int[equipes.Length];

    int countVencedores = 0;

    for (int e = 0; e < equipes.Length; e++)
    {
        int countPontos = 0;
        for (int l = 0; l < linhas; l++)
        {
            if (DadosEstruturados2D[l, 0] == equipes[e] && DadosEstruturados2D[l,2] == "win")
            {
                countPontos += 3;
            } else if (DadosEstruturados2D[l, 0] == equipes[e] && DadosEstruturados2D[l,2] == "draw")
            {
                countPontos += 1;
            }
        }
        pontuacao[countVencedores] = countPontos;
        countVencedores++;
    }

    return pontuacao;
}

void ordenandoVetores()
{
    for (int i = 0; i < pontos.Length; i++) {
        for (int t = i + 1; t < pontos.Length; t++) {
            if (pontos[i] < pontos[t]) {
                int tempNum = pontos[i];
                pontos[i] = pontos[t];
                pontos[t] = tempNum;

                string tempEquipes = equipes[i];
                equipes[i] = equipes[t];
                equipes[t] = tempEquipes;
                
                int tempTotalJogos = totaljogos[i];
                totaljogos[i] = totaljogos[t];
                totaljogos[t] = tempTotalJogos;
                
                int tempVitorias = vitorias[i];
                vitorias[i] = vitorias[t];
                vitorias[t] = tempVitorias;
                
                int tempEmpates = empates[i];
                empates[i] = empates[t];
                empates[t] = tempEmpates;
                
                int tempDerrotas = derrotas[i];
                derrotas[i] = derrotas[t];
                derrotas[t] = tempDerrotas;
            }
        }
    }
}