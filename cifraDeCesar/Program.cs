string frase = "AABCCCDEEEE";


string novafrase = "";
int count = 1;
for(int i = 0; i < frase.Length; i++){

    if(i < frase.Length -1 && frase[i] == frase[i+1]){
        count++;
    } else {
        if(count == 1){
            novafrase += frase[i];
        } 
        else {
            novafrase += count+""+frase[i];
            count = 1;
        }
    }

}

System.Console.WriteLine(novafrase);