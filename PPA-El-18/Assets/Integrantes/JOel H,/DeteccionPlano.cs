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
    
    private void Update() 
    {
        PlaneDetection();    
    }

    //_____________________:::::________________________

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
   
}
