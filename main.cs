using System;

class Nombre {
  private string nombreStr;
  private string nombreRomain;

  public Nombre (string str, string rstr) {
    this.nombreStr = str;
    this.nombreRomain = rstr;
  }

  public static string Reverse( string s ) {
    char[] charArray = s.ToCharArray();
    Array.Reverse(charArray);
    return new string(charArray);
  }

  public string CalculerNombreEntier () {
    string NombreEntier = "";
    int somme = 0;
    bool next = false;

    if (!this.validateRoman()) {
      Console.WriteLine("Invalid characters for digits :/");
      return "";
    }

    for (int i = 0; i < nombreRomain.Length; i++) {
      switch (nombreRomain[i]) {
        case 'I' :
          if (nombreRomain.Length > i+1 && (nombreRomain[i+1] == 'V' || nombreRomain[i+1] == 'X')) next = true;
          else somme += 1;
        break;
        case 'V' :
          if (next == true){
            somme += 4;
            next = false;
          }
          else somme += 5;
        break;
        case 'X' :
          if (next == true) {
            somme += 9;
            next = false;
          }
          else somme += 10;
        break;
        case 'L' :
          somme += 50;
        break;
        case 'C' :
          somme += 100;
        break;
        case 'D' :
          somme += 500;
        break;
        case 'M' :
          somme += 1000;
        break;
        default : break;
      }
    }

    return "Chiffre entier : " + somme.ToString();
  }

  public bool validateRoman () {
    string rStr = this.nombreRomain;
    string dico = "IVXLCDM";
    bool found = false;
    for (int i = 0; i < rStr.Length; i++) {
      found = false;
      for (int y = 0; y < dico.Length; y++) {
        if (dico[y] == rStr[i]) found = true;
      }

      if (found == false) return false;
    }
    return true;
  }

  public bool validateEntier () {
    string eStr = this.nombreStr;
    string dico = "0123456789";
    bool found = false;
    for (int i = 0; i < eStr.Length; i++) {
      found = false;
      for (int y = 0; y < dico.Length; y++) {
        if (dico[y] == eStr[i]) found = true;
      }

      if (found == false) return false;
    }
    return true;
  }

  public string CalculerNombreRomain() {
    string NombreRomain =  "";
    int zero = 0;
    int x = 0;
    int localNb = 0;
    string localStr = "";
    int tmp;

    if (!validateEntier()) {
      Console.WriteLine("Invalide characters for romans :/");
      return "";
    }

    for (int i = 0; i < nombreStr.Length; i++) {
      int intval = (int) char.GetNumericValue(nombreStr[nombreStr.Length-i-1]);
      localNb = (int) System.Math.Pow(10, i) * intval;
      localStr = localNb.ToString();
      int n = Convert.ToInt32(char.GetNumericValue(nombreStr[nombreStr.Length-i-1]));

      if (nombreStr[nombreStr.Length-i-1] != '0') tmp = Convert.ToInt32(localNb/n);

      else tmp = 0;
      switch (tmp) {
        case 1000 :
          for (int u = 0; u < n; u++) NombreRomain += "M";
        break;
        case 200 :
          for (int u = 0; u < n; u++) NombreRomain += "D";
        break;
        case 100 :
          for (int u = 0; u < n; u++) NombreRomain += "C";
        break;
        case 50 :
          for (int u = 0; u < n; u++) NombreRomain += "L";
        break;
        case 10 :
          for (int u = 0; u < n; u++) NombreRomain += "X";
        break;
        case 5 :
          for (int u = 0; u < n; u++) NombreRomain += "V";
        break;
        case 1 :
          for (int u = 0; u < n; u++) NombreRomain += "I";
        break;
        default :
          if (tmp > 1000) {
            for (int u = 0; u < n; u++) NombreRomain += "M";
          }
        break;
      }
    }

    return "Chiffre romain : " + Nombre.Reverse(NombreRomain.ToString());
  }
}

class Program {
  public static void Main (string[] args) {
    Console.WriteLine("Welcome ! Just uppercase letters are valid here.");
    Console.WriteLine ("Enter a number : ");
    string c = Console.ReadLine();
    Console.WriteLine ("Enter a roman number : ");
    string r = Console.ReadLine();
    Nombre nb = new Nombre(c, r);
    Console.WriteLine(nb.CalculerNombreRomain());
    Console.WriteLine(nb.CalculerNombreEntier());
  }
}