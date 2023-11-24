string alfabeto = "abcdefghijklmnopqrstuvwxyz";
string ALFABETO = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

string msg = "ameixa_A";
int chave = 1;

string textoCifrado = cifrada(true);
string textoPuro = cifrada(false);

Console.WriteLine(textoCifrado);
Console.WriteLine(textoPuro);

string cifrada(bool cifrar){

    if(!cifrar)
        chave -= chave;

    string cifrada = "";
    for (int i = 0; i < msg.Length; i++)
    {
        bool f = false;
        for (int t = 0; t < alfabeto.Length; t++)
        {
            if(alfabeto[t] == msg[i])
            {
                cifrada += alfabeto[t + chave];
                f = true;
                break;
            } 
            else if (ALFABETO[t] == msg[i])
            {
                cifrada += ALFABETO[t + chave];
                f = true;
                break;
            }
        }
        if (!f)
            cifrada += msg[i];
    }
    return cifrada;
}