using System;
					
public class Program
{
	public static void Main()
	{
		string frase = "AmEIXa_abd";

char[] criptada = CifraDeCesar(frase, 1, true);
char[] decriptada = CifraDeCesar(frase, 1, false);

Console.WriteLine(criptada);
Console.WriteLine(decriptada);

char[] CifraDeCesar(string msg, int chave, bool cript){

    if(!cript)
        chave -= chave;

    char[] alfabeto = new char[26] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
    char[] ALFABETO = new char[26] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
    
    char[] fraseCifrada = new char[msg.Length];

    for(int i = 0; i < msg.Length; i++){

        bool ehLetra = false;
        bool EhCaixaAlta = false;
        int posLetra = 0;

        for(int t = 0; t < alfabeto.Length; t++){
            if(msg[i] == ALFABETO[t]){
                posLetra = t;
                ehLetra = true;
                EhCaixaAlta = true;
                break;
            }
        }

        if(!EhCaixaAlta){
            for(int t = 0; t < alfabeto.Length; t++){
                if(msg[i] == alfabeto[t]){
                    posLetra = t;
                    ehLetra = true;
                    break;
                }
            }
        }
        if(ehLetra){
            char letraCifrada;
            if(EhCaixaAlta)
                letraCifrada = Convert.ToChar(ALFABETO[(posLetra + chave) % alfabeto
                .Length]);
            else
                letraCifrada = Convert.ToChar(alfabeto[(posLetra + chave) % alfabeto.Length]);

            fraseCifrada[i] = letraCifrada;
        } else {
            fraseCifrada[i] += msg[i];
        }
    }
    return fraseCifrada;
}
	}
}