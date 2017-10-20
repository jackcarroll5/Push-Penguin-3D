using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpScoreControl : MonoBehaviour, IPopUp {
    public Animator myAnimation;
    int myScore = 5;

    private Text myText;
    float time;

    public void WithScoreOf(int score)
    {
        myScore = score;

        time = Time.time;
        myText = GetComponentInChildren<Text>();
        myText.text = myScore.ToString();

        myAnimation = GetComponentInChildren<Animator>();

        print(myScore);


    }

    // Use this for initialization
    void Start ()
    {
        /*time = Time.time;
        myText = GetComponentInChildren<Text>();
        myText.text = myScore.ToString();

        myAnimation = GetComponentInChildren<Animator>();
      

       // AnimatorClipInfo[] clipInfo = myAnimation.GetCurrentAnimatorClipInfo(0);
       // Destroy(gameObject, clipInfo[0].clip.length);
       */

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time - time >= 1.01f)
        {
            Destroy(myText);
            Destroy(myAnimation);

        }
    }
}
//https://www.youtube.com/watch?v=fbUOG7f3jq8