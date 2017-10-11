using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControl : MonoBehaviour, IDestoryable {

    private Vector3 destination;
    private enum Status { waiting, moving, still };
    private Status status;

    private static Transform NPCParent;
    private Transform raycastTarget;

    private int moveSpeed = 3;

    // Use this for initialization
    void Start () {
        status = Status.waiting;
        if (NPCParent == null)
        {
            NPCParent = new GameObject("NPC Parent").transform;
        }
        transform.SetParent(NPCParent);
        raycastTarget = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.DrawRay(transform.position, transform.right * 2, Color.red);
        if (status == Status.waiting)
        {
            //Set destination
            RaycastHit hit;

            Physics.Raycast(transform.position, transform.right, out hit);
            if (hit.rigidbody != null)
            {
                //temp for testing
                destination = hit.rigidbody.position - (hit.rigidbody.position - transform.position).normalized;//(transform.position + raycastTarget.localPosition * 5);
                status = Status.moving;
            }
        }
        else if (status == Status.moving)
        {
            //Move towards destination
            if ((destination - transform.position).magnitude > 0.06f)
            {
                Vector3 velocity = moveSpeed * (destination - transform.position).normalized;
                transform.position += velocity * Time.deltaTime;
            }
            else
            {
                status = Status.still;
                StartCoroutine(waitForNewDestination(1));
                //rotate 90 degrees and try again
                transform.Rotate(0, -90, 0);
            }
        }

    }

    //Kill enemy
    public bool DoDestroy()
    {
        Destroy(gameObject);
        return true;
    }
    
    IEnumerator waitForNewDestination(int time)
    {
        yield return new WaitForSeconds(time);
        status = Status.waiting;
        
    }
}
