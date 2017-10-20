using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Quick'n'dirty copy&past for testing purpose only, will be replaced later on
/// </summary>
public class WorldControllerMockUp : MonoBehaviour {
    public Transform IceBlockPreFab;
    private float heightOfWorldFloor = 0.0f;

    // Use this for initialization
    void Start ()
    {
        CreateIceBlockAt(new Vector3(0, 0, 0));
    }

    private Vector3 SnapTo(Vector3 v)
    {
        return new Vector3(Mathf.RoundToInt(v.x), heightOfWorldFloor, Mathf.RoundToInt(v.z));
    }


    public void CreateIceBlockAt(Vector3 v)
    {
        Transform newBie = Instantiate(IceBlockPreFab, SnapTo(v), Quaternion.identity);
        IceBlockController HiNewbie = newBie.gameObject.GetComponent<IceBlockController>();
        HiNewbie.ThisIsMe(this);
    }

    internal Vector3 getDestinationForIceblock(IceBlockController iceBlockController, Vector3 pusherPosition)
    {
        Vector3 positionOfIceBlock = iceBlockController.transform.position;
        Vector3 direction = positionOfIceBlock - SnapTo(pusherPosition);
        if (!((direction.magnitude < 0.1f) || (direction.magnitude > 1.1f)))
            return SnapTo(positionOfIceBlock + 5.0f * direction);

        return positionOfIceBlock;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
