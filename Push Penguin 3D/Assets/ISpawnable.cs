using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnable {
    //This interface spawns the necessary items/players in the game
    //and adds them to the list of that item

    //Spawns the player
    int PlayerSpawn();

    //Spawns an enemy
    int EnemySpawn();

    //Spawns an item
    int ItemSpawn();

    //Spawns an egg
    int EggSpawn();
}
