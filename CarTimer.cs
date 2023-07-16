using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CarTimer : MonoBehaviour
{
    public GameObject metaObject;
   public bool underMeta = false;
    public static float startTime;
    public  float endTime;
   public  float elapsedTime;
    public Text @timerText;
    public float czasOkrazenia = 0;
    public float czasOkrazenia2 = float.PositiveInfinity;
    public Text @czasOkrazeniaText;
    bool i = false;



    void Update()
    {
        if (underMeta && !metaObject.GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds) )
        {
            
            endTime = Time.time;
            elapsedTime = endTime - startTime;
            timerText.text = elapsedTime.ToString("F2") + " s";
            

        }
        if (!underMeta && metaObject.GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds) && (startTime==0 || czasOkrazenia != 0))
        {
            startTime = Time.time;
            underMeta = true;
            
            
        }
        if (metaObject.GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds) && (endTime - startTime) > 10)
        {

                czasOkrazenia = elapsedTime;

            if (czasOkrazenia2 > czasOkrazenia)
            {
                czasOkrazenia2 = czasOkrazenia;
            }
            czasOkrazeniaText.text ="Najlepszy wynik: " + czasOkrazenia2.ToString("F2") + " s";
            underMeta = false;
            
            
        }


    }
}
