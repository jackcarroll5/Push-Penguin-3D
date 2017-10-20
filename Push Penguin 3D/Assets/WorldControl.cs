using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldControl : MonoBehaviour
{

    private float heightOfWorldFloor = 0.0f;

    public Transform IceBlockPreFab, WallPrefab;

    private int widthOfWorld = 20;

    private int depthOfWorld = 20;

   // Vector3 playerPosition, IceBlockPosition;

    PenguinControl control;
    IceBlockController iceBlock;



    void Start()
    {
        //control = GameObject.Find("Player").GetComponent<PenguinControl>();
        //iceBlock = GameObject.Find("Ice Block").GetComponent<IceBlockController>();

        //

        for (int i = 0; i < 5; i++)

        CreateIceBlockAt(new Vector3(i, 0, 2 * i)); 


        border(); 



    }

    // Update is called once per frame
    void Update()
    {


    }


    private void createWallAt(Vector3 v)
    {

        Transform newBie = Instantiate(WallPrefab, SnapTo(v), Quaternion.identity);
        newBie.parent = transform;
    }


    private bool isOntheEdge(int x, int z)
    {

        return (x == 0) || (z == 0) || (x == (widthOfWorld - 1)) || (z == (depthOfWorld - 1));
    }


    internal Vector3 getDestinationForIceblock(IceBlockController iceBlockController, Vector3 pusherPosition)
    {

        Vector3 positionOfIceBlock = iceBlockController.transform.position;

        Vector3 direction = positionOfIceBlock - SnapTo(pusherPosition);

        if (!((direction.magnitude < 0.9f) || (direction.magnitude > 1.1f)))

            return SnapTo(positionOfIceBlock + 5.0f * direction);


        return positionOfIceBlock;
    }


    internal Vector3 randomEmptyPosition()
    { return new Vector3(0, 0, 0); }


    internal Vector3 positionForItem()

    {

        throw new NotImplementedException();
    }


    private Vector3 SnapTo(Vector3 v)
    {

        return new Vector3(Mathf.RoundToInt(v.x), heightOfWorldFloor, Mathf.RoundToInt(v.z));
    }


    private Vector3 SnapTo(Vector3 v, float height)
    {
        Vector3 snap1 = SnapTo(v);
        return new Vector3(snap1.x, height, snap1.z);
    }




    void CreateIceBlockAt(Vector3 v)
    {
        Transform newBie = Instantiate(IceBlockPreFab,SnapTo(v,v.y),Quaternion.identity);
        newBie.parent = transform;


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
        for (int x = 0; x < widthOfWorld; x++)

        {

            for (int z = 0; z < depthOfWorld; z++)

            {

                CreateIceBlockAt(new Vector3(x, -1, z));

                if (isOntheEdge(x, z)) createWallAt(new Vector3(x, 0, z));


            }

        }


        //for (int i = 0; i < widthOfWorld; i++)

        //{

        //    CreateIceBlockAt(new Vector3(i, 0, 0));

        //    CreateIceBlockAt(new Vector3(i, 0, depthOfWorld - 1));

        //}


        //for (int i = 1; i < depthOfWorld - 1; i++)

        //{

        //    CreateIceBlockAt(new Vector3(0, 0, i));

        //    CreateIceBlockAt(new Vector3(widthOfWorld - 1, 0, i));

        //}
    }
}
