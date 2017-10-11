using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    int speed = 10;

    //Joseph Enright (Dave gave moral support)

    public void MoveX(GameObject character, float direction)
    {
        Vector3 velocity = new Vector3(direction* speed, 0, 0);
        character.transform.position += velocity * Time.deltaTime;
    }

    public void MoveZ(GameObject character, float direction)
    {
        Vector3 velocity = new Vector3(0, 0, direction * speed);
        character.transform.position += velocity * Time.deltaTime;
    }

    public void TurnLeft(GameObject pickUpItem, float direction)
    {
        pickUpItem.transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }


}
