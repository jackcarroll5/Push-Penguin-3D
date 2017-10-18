using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManagerControl : MonoBehaviour
{

    public enum ItemType { Apple, Banana, Cherry }


    private List<EggControl> eggs;
    private List<PickUpItemControl> items;
    private List<NPCControl> enemies;
    private List<PenguinControl> player;
    private int whatDestroyed;

    public Transform itemClone;


    WorldControl theWorld;

 
    //public int EggSpawn()

    //{
    //    //Spawn Egg

    //    eggs.Add(egg);
    //}

    public void EnemySpawn(NPCControl enemy)
    {
        //Spawn Enemy

        enemies.Add(enemy);
    }


    private void SpawnRandomItem()
    {
        ItemType newItemType = (ItemType)UnityEngine.Random.Range(0, 3);

        Vector3 positionToSpawn = theWorld.randomEmptyPosition();
        positionToSpawn = new Vector3(1, 1, 1);
        float timeSpawned = Time.time;

        ItemSpawnAt(newItemType, positionToSpawn, timeSpawned);

    }

    private void ItemSpawnAt(ItemType newItemType, Vector3 positionToSpawn, float timeSpawned)
    {

        Transform newItem = Instantiate(itemClone, positionToSpawn, Quaternion.identity);
        PickUpItemControl newItemControl = newItem.GetComponent<PickUpItemControl>();
        newItemControl.YouAre(newItemType, 100 * (1 + (int)newItemType), 5.0f);
        items.Add(newItemControl);
    }


    public void PlayerSpawn(PenguinControl player)

    {
        //spawn Player

        this.player.Add(player);


    }





    public void SetScore(char item)
    {



        /*switch (item)
        {
            case 'A':
                {
                    //apple.points(minScore);
                  
                      break;
                }
            case 'B':
                {
                    //banana.points(minScore*1.25f);
                    break;
                }
            case 'S':
                {
                    //starberry.points(maxScore);
                    break;
                }
            default:
                {
                    break;
                }
        }*/
    }

    public void ItemDestroyed(PickUpItemControl item)
    {

        items.Remove(item);

    }

    public void EnemyDestroyed(PickUpItemControl enemy)
    {

        //enemies.Remove(enemy);

        //AddScore(ScoreControl.currentScore);
        whatDestroyed = 2;
    }

    public void EggDestroyed(EggControl egg)
    {

        eggs.Remove(egg);

        //AddScore(ScoreControl.currentScore);
        whatDestroyed = 1;

    }

    public void PlayerDestroyed(PenguinControl penguin)
    {

        player.Remove(penguin);

    }



    // Use this for initialization
    void Start()
    {
        theWorld = FindObjectOfType<WorldControl>();

        if (theWorld) print("found the world");
        else print("No world");
        eggs = new List<EggControl>();
        items = new List<PickUpItemControl>();
        enemies = new List<NPCControl>();
        player = new List<PenguinControl>();


    }


    public void startOfWorld()
    {

    }
    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.C)) SpawnRandomItem();
    }


}
