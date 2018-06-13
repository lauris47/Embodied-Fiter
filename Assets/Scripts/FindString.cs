using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindString : MonoBehaviour
{
    string text = "Hel now lo";
    string findThis = "now";

     string[] findFromThese;
     string[] finInThese;
    // Use this for initialization
    void Start()
    {
        findFromThese = new string[text.Length];
        finInThese = new string[findThis.Length];

        findFromThese[0] = "H";
        findFromThese[1] = "e";
        findFromThese[2] = "l";
        findFromThese[3] = " ";
        findFromThese[4] = "n";
        findFromThese[5] = "o";
        findFromThese[6] = "w";
        findFromThese[7] = " ";
        findFromThese[8] = "l";
        findFromThese[9] = "o";

        finInThese[0] = "n";
        finInThese[1] = "o";
        finInThese[2] = "w";
        
        int returntedInt = simpleSearch(findThis, text);
        //Debug.Log(returntedInt);
    }

    public  int simpleSearch(string s, string t)
    {
        for (int i = 0; i < t.Length; i++)
        {
            for (int j = 0; j < s.Length; j++)
            {
                //Debug.Log(finInThese[j] + " != " + findFromThese[i + j]);
                if (i + j + 1 < t.Length && finInThese[j] != findFromThese[i + j])
                {
                    break;
                }
                else if (j == s.Length - 1)
                    return i;
            }
        }
        return 0;
    }
}
