using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Senses : MonoBehaviour
{
    public float hearingDistance = 3.0f;
    public float fieldOfVeiw = 45.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            foreach (GameObject player in GameManager.Instance.Players)
            {
                if (CanSee(player))
            {
                Debug.Log("I can see the player");
                return;
            }
            }
            foreach (GameObject player in GameManager.Instance.Players)
        {
            if (CanHear(player))
            {
                Debug.Log("I heard the player");
                return;
            }
        }
    }

    public bool CanSee(GameObject target)
    {
        //Check Field Of View
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angleToTarget = Vector3.Angle(vectorToTarget, transform.forward);
        if (angleToTarget <= fieldOfVeiw)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, vectorToTarget, out hit));
            {
                if (hit.collider.gameObject.tag == "PLayer")
                {
                    Debug.Log("I See the Player");
                    return true;
                }
            }
        }
        return false;
    }

    public bool CanHear(GameObject target)
    {
        if (target = null)
        {
            return false;
        }
        return (Vector3.SqrMagnitude(transform.position - target.transform.position) <= hearingDistance * hearingDistance);
    }
}
