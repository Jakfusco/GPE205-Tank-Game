using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Senses : MonoBehaviour
{
    public float hearingDistance = 3.0f;
    public float fieldOfVeiw = 45.0f;
    public Color gizmoColor;


    public bool CanSee(GameObject target)
    {
        //Check Field Of View
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angleToTarget = Vector3.Angle(vectorToTarget, transform.forward);
        if (angleToTarget < fieldOfVeiw)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, vectorToTarget, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject == target)
                {
                    Debug.DrawRay(transform.position, vectorToTarget, Color.green);
                    return true;
                }
                else
                {
                    Debug.DrawRay(transform.position, vectorToTarget, Color.red);
                    return false;

                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool CanHear(GameObject target)
    {
        Noisemaker targetNoisemaker = target.GetComponent<Noisemaker>();
        if (targetNoisemaker != null)
        {
            Vector3 vectorToTarget = target.transform.position - this.transform.position;
            if (hearingDistance + targetNoisemaker.noiseRadius > vectorToTarget.magnitude)
            {
                gizmoColor = Color.green;
                return true;
            }
        }
        gizmoColor = Color.red;
        return false;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, hearingDistance);
    }
}
