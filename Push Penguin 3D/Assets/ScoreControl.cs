
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControl : MonoBehaviour, iScore {

    int currentScore;


    public void AddScore(int scoreIncrement)
    {
        currentScore += scoreIncrement;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
