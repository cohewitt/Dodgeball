using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class Helper{
    void Start()
    {
       
        
    }
    public static string getPlayer(string name)
    {
        string output;
        output = name.Split(' ')[0];
        return output;
    }
    public static string getTeam(string name)
    {
        Regex teamRegex = new Regex(@"\b[A-Z][a-z]+");
        string output;
        output = getPlayer(name);
        output = teamRegex.Match(output).ToString();
        return output;
    }
}
