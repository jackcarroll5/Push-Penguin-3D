using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldControl : MonoBehaviour {
    private float heightOfWorldFloor = 0.0f;
    public Transform IceBlockPreFab;
    private int widthOfWorld = 20;
    private int depthOfWorld = 20;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 5; i++)
            CreateIceBlockAt(new Vector3(i, 0, 2 * i));

        border();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal Vector3 getDestinationForIceblock(IceBlockController iceBlockController, Vector3 pusherPosition)
    {
        Vector3 positionOfIceBlock = iceBlockController.transform.position;
        Vector3 direction = positionOfIceBlock - SnapTo(pusherPosition);
        if (!((direction.magnitude < 0.1f) || (direction.magnitude > 1.1f)))
            return SnapTo( positionOfIceBlock + 5.0f * direction);

        return positionOfIceBlock;
    }

    private Vector3 SnapTo(Vector3 v)
    {
        return new Vector3(Mathf.RoundToInt(v.x), heightOfWorldFloor , Mathf.RoundToInt(v.z));
    }

    void CreateIceBlockAt(Vector3 v)
    {
        Transform newBie = Instantiate(IceBlockPreFab,SnapTo(v),Quaternion.identity);

        IceBlockController HiNewbie = newBie.gameObject.GetComponent<IceBlockController>();

        HiNewbie.ThisIsMe(this);

    }
    /// <summary>
    /// Returns true if position supplied is empty in the world
    /// </summary>
    /// <param name="Position">Position in world</param>
    /// <returns></returns>
    private bool IsEmptyAt(Vector3 Position)
    {
        //todo: Try RayCast from above point straight down
        throw new System.NotImplementedException();
    }


    private void border()
    {
        for (int i = 0; i < widthOfWorld; i++)
        {
            CreateIceBlockAt(new Vector3(i, 0, 0));
            CreateIceBlockAt(new Vector3(i, 0, depthOfWorld-1));
        }

        for (int i = 1; i < depthOfWorld-1; i++)
        {
            CreateIceBlockAt(new Vector3(0, 0, i));
            CreateIceBlockAt(new Vector3(widthOfWorld-1, 0, i));
        }
    }
}
