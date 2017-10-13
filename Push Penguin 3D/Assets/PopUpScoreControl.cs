using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpScoreControl : MonoBehaviour, IPopUp {
    public Animator myAnimation;
    int myScore;

    Text myText;


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
        myText = GetComponentInChildren<Text>();
        myText.text = "" + RandomNumGen(1, 255);

        myAnimation = GetComponentInChildren<Animator>();
      

       // AnimatorClipInfo[] clipInfo = myAnimation.GetCurrentAnimatorClipInfo(0);
       // Destroy(gameObject, clipInfo[0].clip.length);


    }
	
	// Update is called once per frame
	void Update ()
    {
        //if(myAnimation.)
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