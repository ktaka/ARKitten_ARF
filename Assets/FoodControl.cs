using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FoodControl : ControlAbstract
{
    public ControlAbstract catControl;
    public ARSessionOrigin arSession;

    public void Show()
    {
        spawnedObject.GetComponent<FoodBehavior>().Show();
    }

    //protected override void OnHit(Pose hitPose)
    //{
    //    Show();
    //    catControl.MoveTo(hitPose.position, -0.15f);
    //}

        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
