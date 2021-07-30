using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Toplanacak")
        {
            
            other.gameObject.tag = "Untagged";
            KarakterKontrol.instance.Topla(other.gameObject);
            other.gameObject.AddComponent<Control>();
            other.gameObject.AddComponent<Rigidbody>();
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<Rigidbody>().useGravity = false;
            Destroy(this);
        }

        if (other.gameObject.tag == "Coklu")
        {
            Destroy(this);
            other.gameObject.tag = "Untagged";
            List<GameObject> objeler = new List<GameObject>();
            for (int i = 0; i < other.gameObject.transform.childCount; i++)
            {
                objeler.Add(other.gameObject.transform.GetChild(i).gameObject);
                other.gameObject.transform.GetChild(i).gameObject.AddComponent<Control>();
                other.gameObject.transform.GetChild(i).gameObject.AddComponent<Rigidbody>();
                other.gameObject.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.transform.GetChild(i).GetComponent<Rigidbody>().useGravity = false;
               

            }
            

          
            KarakterKontrol.instance.CokluTopla(objeler);

        }


        if (other.gameObject.tag=="Azalt")
        {
            
            other.gameObject.tag = "Untagged";

            List<GameObject> objeler = new List<GameObject>();
            for (int i = 0; i < other.gameObject.transform.childCount; i++)
            {
                objeler.Add(other.transform.GetChild(i).gameObject);
            }


            StartCoroutine(KarakterKontrol.instance.Azalt(objeler));




        }

        if (other.gameObject.tag=="Finish")
        {
            KarakterKontrol.instance.speed = 0;
            KarakterKontrol.instance.finishText.text = "You Won!";
        }


    }


}
