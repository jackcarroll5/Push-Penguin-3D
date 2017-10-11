
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControl : MonoBehaviour, iScore {
    int Challenge1 = 5;
    int currentScore;


    public void AddScore(int scoreIncrement)
    {
        currentScore += scoreIncrement;
    }


    // Use this for initialization
    void Start () {
        //Spawning cubes to test score
        while (Challenge1 > 0)
        {
            GameObject Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Cube.name = "Enemy " + Challenge1;
            Cube.transform.position += new Vector3(2 * Challenge1, 0, 0);
            Challenge1--;
            Cube.tag = "Test";
        }
        

    }

    // Update is called once per frame
    void Update () {
        //getting the cubes to move for score incrementation test
        if (gameObject.tag == "Test")
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                this.transform.position += new Vector3(5, 0, 0);

            }
        }
    }
}
