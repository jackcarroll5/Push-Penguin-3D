using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemControl : MonoBehaviour, IPoints {

    private int _points = 100;
    private int minimumPoints = 50;
    private int maximumPoints = 250;
    public Transform Popup;

    GameManagerControl theManager;
    public int points
    {
        get
        {
            return _points;
        }

        set
        {
            if(value <= minimumPoints)
            {
                _points = minimumPoints;
            } else if (value >= maximumPoints)
            {
                _points = maximumPoints;
            } else
            {
                _points = value;
            }
        }
    }


    // Use this for initialization
    void Start () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PenguinControl>())
        {
         Transform newPopup =   Instantiate(Popup, transform.position, Quaternion.identity);
            newPopup.GetComponent<PopUpScoreControl>().WithScoreOf(_points);
            theManager.ItemDestroyed(this);
            Destroy(gameObject);
        }


    }
    // Update is called once per frame
    void Update () {
  
	}
}
