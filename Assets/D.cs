using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D : MonoBehaviour
{
    static string K, K2 = "";
    static Image C;
    static Color color = Color.white;
    public GameObject P;

    public void Cclick(RectTransform t)
    {
        C = t.transform.Find("C").GetComponent<Image>();
        if (color == C.color)
        {
            string name = t.name;
            int i, j;
          /*  i = convert.ToInt32((name.Split('&'))[0]);
            j = Convert.ToInt32((name.Split('&'))[1]);
            int co = -1;
          */
        }
    }
}