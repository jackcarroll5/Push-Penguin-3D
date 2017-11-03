
using UnityEngine;

public class PopUpScoreControl : MonoBehaviour, IPopUp
{
    ScoreControl theScore;
    public int MyScore
    {
        get { return myScore; }

        private set
        {
            myScore = value;
            Score.text = myScore.ToString();
        }
    }

    private int myScore = 0, test;
    private float time, speedY = 10f, speedX = 3f;
    TextMesh Score;
    private bool tester;


    public void WithScoreOf(int score, Vector3 positionOfItem)
    {
        theScore = FindObjectOfType<ScoreControl>();
        theScore.AddScore(score);
        MyScore = score;
        tester = true;
        Score.transform.position = positionOfItem;
    }

    void Awake()
    {
        Score = GetComponent<TextMesh>();
        tester = false;
        #region Dont edit this!
        Score.fontSize = 255;//Dont edit this
        Score.characterSize = .03f;//Dont edit this
        #endregion

        tester = true;
        time = Time.time;
        Score.text = "" + 5;

    }
    void Update()
    {
       
   
       

      
            #region This controls the direction of the text
            if (Time.time - time >= .0f && Time.time - time <= .75f)
            {
                transform.Translate(new Vector3(speedX * Time.deltaTime, speedY * Time.deltaTime, 0));

            }
            else if (Time.time - time >= .75f && Time.time - time <= 1.5f)
            {
                transform.Translate(new Vector3(-speedX * Time.deltaTime, speedY * Time.deltaTime, 0));
            }
            #endregion

            #region Part 1 controls when to destroy the text and part 2 stops the X and Y position in transform from incrementing every frame
            //Part 1
            if (Time.time - time >= 1.5f)
            {

                Score.text = "";
                test = 0; // this cuts the translate from increasing
                tester = false;
            }


            //Part 2
            if (test == 0)
            {
                //this stops the x and y in translate from increasing
                transform.Translate(new Vector3(0, 0, 0));
            }
            #endregion
        }
    
}
//https://www.youtube.com/watch?v=fbUOG7f3jq8

