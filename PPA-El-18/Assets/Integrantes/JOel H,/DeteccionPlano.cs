using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Importar Librerias ARFundation
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class DeteccionPlano : MonoBehaviour
{
    public ARRaycastManager aRRaycastManager;
    public GameObject indicator;
    
    public GameObject objectPrefab; //++

    private void Update() 
    {
        PlaneDetection(); 
        SpawnnPrefab();   
    }

    //_____________________:::::________________________

    //Detección de Planos
    public void PlaneDetection()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        Vector2 screenPosition = new Vector2 (Screen.width / 2, Screen.height / 2);

        aRRaycastManager.Raycast(screenPosition, hits, TrackableType.Planes);
        
        if(hits.Count > 0)
        {
            this.transform.position = hits[0].pose.position;
            this.transform.rotation = hits[0].pose.rotation;

            indicator.SetActive(true);
        }
        else
        {
            indicator.SetActive(false);
        }
    }
    //_____________________:::::________________________


    //Cuando hacemos un click en la panatalla instanciamos un objeto _-_
   public void SpawnnPrefab()  //++
   {
       if(Input.touchCount > 0)
       {
           //Ocupamos una sola presion en el touch 
           Touch touch = Input.GetTouch(0);
           if(touch.phase == TouchPhase.Began)
           {
               Instantiate(objectPrefab, this.transform.position, this.transform.rotation);
           }

       }
   }
}
