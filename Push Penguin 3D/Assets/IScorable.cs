using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScorable {
    //This interface assigns score values to an item and adds the
    //correct score when the player collides with an item

    //Defines the score values of each item
    void SetScore(char item);

    //Adds the correct score to the current score
    int AddScore(int scoreToAdd);
}
