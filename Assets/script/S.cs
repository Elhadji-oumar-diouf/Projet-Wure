using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S : MonoBehaviour
{
    public static int n = 5 ;
    public GameObject D;
    public static GameObject[ , ] g = new GameObject[n, n];
    public List<Sprite> PionSprite=new List<Sprite>();
    public static UnityEngine.Vector2 Cmp;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 cs=transform.gameObject.GetComponent<RectTransform>().sizeDelta, size = D.GetComponent<RectTransform>().sizeDelta;
        cs.x /= 2;
        cs.y /= 2;
        float left = (cs.x - size.x) * -1, top =(cs.y - size.y);


        Color[] colors = new Color[] {Color.HSVToRGB(0.3f,0.5f,1), Color.red };
        Image drt = D.GetComponent<Image>(),Ci = D.transform.Find("C").GetComponent<Image>();
        for ( int i=0 ; i<n; i++){  
           if(i % 2==0){
                colors[0] = Color.grey;
                colors[1]=Color.HSVToRGB(0.17f, 0.11f, 0.77f);
            }
            else{
                colors[0] = Color.HSVToRGB(0.17f, 0.11f, 0.77f);
                colors[1] = Color.grey;
            }

            for (int j = 0; j < n; j++) {
                drt.color = colors[(((j % 2) == 0) ? 0 : 1)];
                /*
                 if (i==(n%2)-1 || i ==(n % 2) || drt.color==Color.gray) Ci.enabled = false;
                 else Ci.enabled = true;
                 if (i < (n % 2)) Ci.color = Color.red;
                 else Ci.color = Color.gray;*/
                if (drt.color == Color.black) D.transform.Find("K2").GetComponent<Image>().enabled = false;
                else D.transform.Find("K2").GetComponent<Image>().enabled = true;
                if(i==2 && j == 2){
                    Ci.enabled = false;
                }
                else
                {
                    Ci.enabled = true;
                }
                if(i==2 && j == 3)
                {
                    Ci.sprite =PionSprite[1] ;

                }
                 g[i,j]=Instantiate(D);
                 g[i,j].transform.SetParent(transform.Find("Panel1"));
                 g[i,j].transform.localPosition=new Vector3(left , top);
                 g[i,j].transform.name = i + "&" + j;
                 left += size.x;
               
            }
            left = (cs.x - size.x)* -1;
            top -=size.y;
        }
    }

    public static void F()
    {
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                g[i, j].transform.Find("K").gameObject.GetComponent<Image>().enabled = false;
            }
        }
    }
}
