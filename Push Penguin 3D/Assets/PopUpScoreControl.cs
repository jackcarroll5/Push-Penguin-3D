using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpScoreControl : MonoBehaviour, IPopUp {


    int myScore;
    GameObject g;
    int number; 


    public void WithScoreOf(int score)
    {
        myScore = score;
      
    }

    //public void example()
    //{

    //}

    // Use this for initialization
    void Start ()
    {
        
        g = transform.GetChild(0).GetChild(0).gameObject;
        g.GetComponent<Text>().text =  "" + RandomNumGen(1,255);
	}
	
	// Update is called once per frame
	void Update ()
    {
        //todo Add alpha detection
        if()
        {

        }
    }
    List<int> usedValues = new List<int>();
    private int RandomNumGen(int min, int max)
    {
        int val = Random.Range(min, max);
        while(usedValues.Contains(val))
        {
            val = Random.Range(min, max);
        }
        return val;
    }
}
//https://www.youtube.com/watch?v=fbUOG7f3jq8