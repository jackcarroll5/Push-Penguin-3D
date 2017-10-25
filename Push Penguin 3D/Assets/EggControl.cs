using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggControl : MonoBehaviour
{

    public bool NotInIce, IceDestroyed;
    public float Timer = 3;
    public GameObject Enemy;
    Vector3 CurrentPosition;
    GameManagerControl theManager;
     
    // Variables Declared
    void Start()
    {
        NotInIce = true;
        IceDestroyed = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime; 
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if (Timer <= 0 && NotInIce == true)
        {

            CurrentPosition = transform.position;
            GameObject EnemyClone =  Instantiate(Enemy, CurrentPosition, Quaternion.identity);
            Destroy(this.gameObject);
            NPCControl enemyController = EnemyClone.GetComponent<NPCControl>();
            theManager.EnemySpawn(enemyController);
            theManager.EggDestroyed(this);
            
        }

        if (IceDestroyed == true && NotInIce == true)
        {

            CurrentPosition = transform.position;
            Instantiate(Enemy, CurrentPosition, Quaternion.identity);
            Destroy(this.gameObject);
        }
        //Raycast to player
    }
    private void OnTriggerEnter(Collider other)
    {
        print("NOT");
        if (other.tag == "IceBlock")
            NotInIce = false;
    }

    void OnTriggerExit(Collider other)
    {

        print("NOT");
        if (other.tag == "IceBlock")
            NotInIce = true;
        Timer = 3;

    }


    internal void IAm(GameManagerControl gameManagerControl)
    {
        theManager = gameManagerControl;
    }
}