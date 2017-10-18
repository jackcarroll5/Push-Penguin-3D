
﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemControl : MonoBehaviour
{


    private int _points = 100;
    private int minimumPoints = 50;
    private int maximumPoints = 250;


    private float _timeAlive = 30; //Seconds



    public Transform Cherry, Apple, Banana;
    public Transform Popup;

    GameManagerControl theManager;

    void Start()
    {


        theManager = FindObjectOfType<GameManagerControl>();
    
    }
    void Update()
    {
        CountdownAndDestroyYourself();
    }


    public int points
    {
        get
        {
            return _points;
        }

        set
        {

            if (value <= minimumPoints)
            {
                _points = minimumPoints;
            }
            else if (value >= maximumPoints)
            {
                _points = maximumPoints;
            }
            else

            if(value <= minimumPoints)
            {
                _points = minimumPoints;
            } else if (value >= maximumPoints)
            {
                _points = maximumPoints;
            } 

        }
    }


    private float timeAlive
    {
        set
        {
            _timeAlive = value;
        }
        get
        {
            return _timeAlive;
        }
    }

    private void CountdownAndDestroyYourself()
    {
        timeAlive -= Time.deltaTime;
        if (timeAlive < 0)
        {
            theManager.ItemDestroyed(this);
            Destroy(gameObject);

            //Remove after test
            print(points);
            Transform newPopup = Instantiate(Popup, transform.position, Quaternion.identity);

            PopUpScoreControl ps = newPopup.GetComponentInChildren<PopUpScoreControl>();

            if (ps)
                ps.WithScoreOf(points);
            else print("none");
            
     
            theManager.ItemDestroyed(this);
            Destroy(gameObject);

        }
    }





    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.GetComponent<PenguinControl>())
        {
            Transform newPopup = Instantiate(Popup, transform.position, Quaternion.identity);

            newPopup.GetComponent<PopUpScoreControl>().WithScoreOf(_points);
            theManager.ItemDestroyed(this);
            Destroy(gameObject);
        }*/


    }



    internal void YouAre(GameManagerControl.ItemType typeOfItem, int Score, float time)
    {
        Transform part;
      switch (typeOfItem)

        {
            case GameManagerControl.ItemType.Apple:

                part = Instantiate(Apple, transform.position, Quaternion.identity);


                break;

            case GameManagerControl.ItemType.Cherry:

                part = Instantiate(Cherry, transform.position, Quaternion.identity);


                break;

            default:

                part = Instantiate(Banana, transform.position, Quaternion.identity);
                break;


        }

        part.transform.parent = transform;

        //set Score
        this.points = Score;


        //set Countsown
        this.timeAlive = time;

    }


  


}
