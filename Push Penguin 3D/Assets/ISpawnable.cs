using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnable {
    //This interface spawns the necessary items/players in the game
    //and adds them to the list of that item

    //Spawns the player
    int playerSpawn();

    //Spawns an enemy
    int enemySpawn();

    //Spawns an item
    int itemSpawn();

    //Spawns an iceblock
    int iceBlockSpawn();

    //Spawns an egg
    int eggSpawn();
}
