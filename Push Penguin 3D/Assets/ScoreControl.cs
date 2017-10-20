
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControl : MonoBehaviour, iScore {

    GameObject Cube1;
    private int Increment = 0, Validator = 1;
    TextMesh tree1;
    private int currentScore;


    public void AddScore(int scoreIncrement)
    {
        currentScore += scoreIncrement;
    }


    // Use this for initialization
    void Start () {

        Cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tree1 = GetComponent<TextMesh>();
        tree1.transform.position = new Vector3(5, 5, 0);
        tree1.text = "Score: " + Increment;
        tree1.fontSize = 255;
        tree1.characterSize = .03f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && Validator == 1)
        {
            Destroy(Cube1);
            Increment += 100;
            Validator = 0;
            Cube1.transform.position = new Vector3(0, 0, 0);
            tree1.text = "Score: " + Increment;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Validator == 0)
        {
            print("No 1");
            print(Increment);
        }

        if(Input.GetKeyDown(KeyCode.S) && Validator == 0)
        {
            Cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Validator = 1;
        }
        else if(Input.GetKeyDown(KeyCode.S) && Validator == 1)
        {
            print("No");
            print(Increment);

        }
        

    }

    // Update is called once per frame

}
