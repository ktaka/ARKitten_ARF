using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CatBehavior : MonoBehaviour, IDragHandler
{
    private float arrivalTime;
    private float speed;
    private Rigidbody rb;
    private Animation anim;
    private int strokingNum;
    public int strokingThreshold = 50;

    public void OnDrag(PointerEventData eventData)
    {
        strokingNum++;
        Debug.Log("stroking num=" + strokingNum);
        if (strokingNum > strokingThreshold)
        {
            anim.Play("IdleSit");
            anim.PlayQueued("Idle");
            strokingNum = 0;
        }
    }

    Vector3 GetLookVector(Vector3 position)
    {
        Vector3 lookVector = Camera.main.transform.position - position;
        lookVector.y = 0.0f;
        lookVector.Normalize();
        return lookVector;
    }

    public void LookAtMe()
    {
        Quaternion rotation = Quaternion.LookRotation(GetLookVector(rb.position));
        rb.rotation = rotation;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
        LookAtMe();
    }

    void FixedUpdate()
    {
        if (arrivalTime > 0.0f)
        {
            arrivalTime -= Time.deltaTime;
            if (arrivalTime < Mathf.Epsilon)
            {
                anim.Play("Idle");
            }
            rb.MovePosition(rb.position + transform.forward * speed * Time.deltaTime);
        }
    }

    public void MoveTo(Vector3 pos, float offset)
    {
        Vector3 planePos = pos;
        planePos.y = rb.transform.position.y;
        rb.transform.LookAt(planePos);
        Vector3 distanceVec = pos - transform.position;
        float distance = distanceVec.magnitude + offset;
        if (distance > 1.0f)
        {
            speed = 0.6f;
            anim.Play("Run");
        }
        else
        {
            speed = 0.2f;
            anim.Play("Walk");
        }
        arrivalTime = distance / speed;
    }

    // Update is called once per frame
    void Update()
    {
    }

}
