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
        /*LANZAR UN RAYO DESDE EL CENTRO DE LA PANTALLA*/
        List<ARRaycastHit> hits = new List<ARRaycastHit>();//Lista: "Lista<>" para almacenar el listado de los rayos

        //             ....    = new vector2 (El ancho de nuestra pantalla dividida en 2, La altura de nuestra pantalal dividida en 2)
        Vector2 screenPosition = new Vector2 (Screen.width / 2, Screen.height / 2);//El punto central de pantalla en las cordenadas x: "vector2"

        aRRaycastManager.Raycast(screenPosition, hits, TrackableType.Planes);//Lanzar el aRRaycast: (El pto. donde se lanza el rayo, lista, es porque usamos los planos)
        
        /*SI EL RAYO TOCA UN PLANO ACTIVAMOS EL INDICADOR PARA ALERTAR AL USUARIO*/
        if(hits.Count > 0)
        {
            this.transform.position = hits[0].pose.position;
            this.transform.rotation = hits[0].pose.rotation;

            indicator.SetActive(true);//Activar nuestro indicador
        }
        else
        {
            indicator.SetActive(false);//Si no estamos mirando un plano valido, desactivamos el indicador
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
