using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggControl : MonoBehaviour
{

    public bool NotInIce, IceDestroyed;
    public float TimeCount, Timer = 3;
    public GameObject Enemy;
    Vector3 CurrentPosition;
    // Variables Declared
    void Start()
    {
        NotInIce = true;
        IceDestroyed = false;
        TimeCount = Time.time + Timer;
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if (Time.time > TimeCount && NotInIce == true)
        {

            CurrentPosition = transform.position;
            Instantiate(Enemy, CurrentPosition, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (IceDestroyed == true && NotInIce == true)
        {

            CurrentPosition = transform.position;
            Instantiate(Enemy, CurrentPosition, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "IceBlock")
            NotInIce = false;
    }

    void OnTriggerExit(Collider other)
    {

        if (other.tag == "IceBlock")
            NotInIce = true;
        TimeCount = 0;

    }
}