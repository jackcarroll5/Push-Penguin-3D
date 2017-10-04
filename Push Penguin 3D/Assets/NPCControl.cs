using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControl : MonoBehaviour, IDestoryable {

    private Vector3 destination;
    private bool hasDestination;
    private static Transform NPCParent;
    private Transform raycastTarget;

    private int moveSpeed = 5;

    // Use this for initialization
    void Start () {
        hasDestination = false;
        if (NPCParent == null)
        {
            NPCParent = new GameObject("NPC Parent").transform;
        }
        transform.SetParent(NPCParent);
        raycastTarget = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasDestination)
        {
            //Set destination
            RaycastHit hit;

            Debug.DrawRay(transform.position, raycastTarget.position * 5, Color.red);
            Physics.Raycast(transform.position, raycastTarget.position * 5, out hit, 2.5f);
            if (hit.rigidbody == null)
            {
                //temp for testing
                destination = (transform.position + raycastTarget.localPosition * 10);
                hasDestination = true;
            }
            else //rotate 90 degrees and try again
                transform.Rotate(0, -90, 0);

        }
        else
        {
            //Move towards destination
            if ((destination - transform.position).magnitude > 0.5f)
            {
                Vector3 velocity = moveSpeed * (destination - transform.position).normalized;
                transform.position += velocity * Time.deltaTime;
            }
            else
                hasDestination = false;
        }

    }

    //Kill enemy
    public bool DoDestroy()
    {
        Destroy(gameObject);
        return true;
    }
    
}
