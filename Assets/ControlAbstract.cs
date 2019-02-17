using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARSessionOrigin))]
public class ControlAbstract : MonoBehaviour
{
    [SerializeField] GameObject placedPrefab;
    protected GameObject spawnedObject;

    ARSessionOrigin sessionOrigin;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        sessionOrigin = GetComponent<ARSessionOrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount < 2)
        {
            return;
        }

        var touch = Input.GetTouch(0);

        if (sessionOrigin.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
        {
            // Raycast hits are sorted by distance, so the first one
            // will be the closest hit.
            var hitPose = hits[0].pose;

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
            }
            else
            {
                spawnedObject.transform.position = hitPose.position;
//                spawnedObject.GetComponent<CatBehavior>().LookAtMe();
            }
        }
    }

    public void MoveTo(Vector3 pos, float offset = 0.0f)
    {
        spawnedObject.GetComponent<CatBehavior>().MoveTo(pos, offset);
    }
}
