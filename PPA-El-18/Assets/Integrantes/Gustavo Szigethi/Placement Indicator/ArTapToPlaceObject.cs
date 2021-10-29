using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;

public class ArTapToPlaceObject : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject placementIndicator;
    
    private ARRaycastManager _arRaycast;
    private Pose _placementPose;
    private bool _placementPoseIsValid = false;
    private bool _isPlace;

    private void Start()
    {
        _arRaycast = FindObjectOfType<ARRaycastManager>();
    }

    private void Update()
    {
        if (!_isPlace)
        {
            UpdatePlacementPose();
            UpdatePlacementIndicator();
        }
        
        if (_placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !_isPlace)
        {
            PlaceObject();
            _isPlace = true;
            placementIndicator.SetActive(false);
        }
    }

    private void PlaceObject()
    {
        Instantiate(objectToPlace, _placementPose.position, _placementPose.rotation);
    }

    private void UpdatePlacementIndicator()
    {
        if (_placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(_placementPose.position, _placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = new Vector2 (Screen.width / 2f, Screen.height / 2f);
        var hits = new List<ARRaycastHit>();
        _arRaycast.Raycast(screenCenter, hits, TrackableType.Planes);

        _placementPoseIsValid = hits.Count > 0;
        if (_placementPoseIsValid)
        {
            _placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            _placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}
