char[] alfabeto = new char[26];
char[] ALFABETO = new char[26];

for(int i = 0; i < alfabeto.Length; i++)
{
    alfabeto[i] = Convert.ToChar('A'+i);
    ALFABETO[i] = Convert.ToChar('a' + i);
}

string msg = "ola_mundo";
int chave = 10;

string criptado = cesar(true);
string decriptado = cesar(false);

Console.WriteLine(criptado);
Console.WriteLine(decriptado);

string cesar(bool criptar) {

    string cript = "";

    if (!criptar)
        chave = 0;

    for (int i = 0; i < msg.Length; i++)
    {
        bool ehLetra = false;
        for (int t = 0; t < 26; t++)
        {
            int c = t;
            if (t + chave > 26)
                c = chave; // ou pode trocar a linha 39 e 45 para cript += alfabeto[(c + chave) % 26];

            if (alfabeto[t] == msg[i])
            {
                ehLetra = true;
                cript += alfabeto[c + chave];
                break;
            }
            else if (ALFABETO[t] == msg[i])
            {
                ehLetra = true;
                cript += ALFABETO[c + chave];
                break;
            }
        }
        if (!ehLetra)
            cript += msg[i];
    }
    return cript;
}

  