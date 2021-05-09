using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Deplacement : MonoBehaviour
{
    static string K , K2 = "";
    static Image C ;
    static Color color = Color.grey;
    public GameObject P ;
    public Text r, w;
    public void Cclick (RectTransform t)
    {
        S.F();
        C = t.transform.Find("C").GetComponent<Image>() ;
        if (color == C.color)
        {
            string name = t.name;
            int i, j;
            i = Convert.ToInt32((name.Split('&'))[0]);
            j = Convert.ToInt32((name.Split('&'))[1]);
            int co = -1;
            if (C.color == Color.red) co = 1;
            try { 
                if (!S.g[i + co, j - 1].transform.Find("C").GetComponent<Image>().enabled)
                {
                    S.g[i + co, j - 1].transform.Find("K").GetComponent<Image>().enabled = true;
                }
                else if (S.g[i + co, j - 1].transform.Find("C").GetComponent<Image>().color != C.color && !S.g[i + (co * 2), j - 2].transform.Find("C").GetComponent<Image>().enabled)
                {
                    S.g[i + (co * 2), j - 2].transform.Find("K").GetComponent<Image>().enabled = true;
                    K2 = (i + co) + "" + (j - 1);
                }
            }
            catch { }
            try { 
                if (!S.g[i+co,j+1].transform.Find("C").GetComponent<Image>().enabled)
                {
                    S.g[i + co, j + 1].transform.Find("K").GetComponent<Image>().enabled = true;
                }
                else if (S.g[i + co, j + 1].transform.Find("C").GetComponent<Image>().color != C.color && !S.g[i + (co * 2), j - 2].transform.Find("C").GetComponent<Image>().enabled)
                {
                    S.g[i + (co * 2), j + 2].transform.Find("K").GetComponent<Image>().enabled = true;
                    K2 = (i + co) + "" + (j + 1);
                }
            }
            catch { }
            K = i + "" + j;
        }
    }
   
    public void A2(char C)
    {
        if (C == 'w') S.Cmp.x++;
        else S.Cmp.y++;
        if (S.Cmp.x >= 12)
        {
            P.gameObject.SetActive(true);
            P.transform.Find("w").GetComponent<Text>().text = "You win white";
        }
        if (S.Cmp.y >= 12)
        {
            P.gameObject.SetActive(true);
            P.transform.Find("w").GetComponent<Text>().text = "You win red";
        }
    }
    public void Kclick(RectTransform t)
    {
        S.F();
        string name = t.name;
        int i, j;
        i = Convert.ToInt32((name.Split('&'))[0]);
        j = Convert.ToInt32((name.Split('&'))[1]);
        S.g[i, j].transform.Find("C").GetComponent<Image>().color = color;
        S.g[i, j].transform.Find("C").GetComponent<Image>().enabled=true;
        i = Convert.ToInt32((K.Split(' '))[0]);
        j = Convert.ToInt32((K.Split(' '))[1]);
        S.g[i, j].transform.Find("C").GetComponent<Image>().enabled = false;
        if(K2!=""&&((Convert.ToInt32((name.Split('&'))[1])-1)==Convert.ToInt32((K2.Split(' '))[1])|| (Convert.ToInt32((name.Split('&'))[1])+1)==Convert.ToInt32((K2.Split(' '))[1])))
        {
            i = Convert.ToInt32((K2.Split(' '))[0]);
            j = Convert.ToInt32((K2.Split(' '))[1]);
            S.g[i, j].transform.Find("C").GetComponent<Image>().enabled = false;
            if (color == Color.white) A2('w');
            else A2('r');
            r.text = S.Cmp.x + "";
            w.text = S.Cmp.y + "";
            K2 = "";
        }
        if (color == Color.grey) color = Color.red;
        else color = Color.grey;

    }

}
