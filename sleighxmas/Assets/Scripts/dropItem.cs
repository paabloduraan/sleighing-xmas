using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dropItem : MonoBehaviour
{
    public GameObject[] itemList; // Stores the gifts
    private Transform grinchPos;
    private Transform santaPos;

    void update()
    {
        grinchPos = GetComponent<Transform>();
        santaPos  = GetComponent<Transform>();
    }

    public void SantaDropItem()
    {
        Instantiate(itemList[getLevel()], new Vector3(
            (santaPos.position.x + 4),
            (santaPos.position.y), 
            (santaPos.position.z)), Quaternion.identity);
    }
    
    public void GrinchDropItem()
    {
        Instantiate(itemList[getLevel()], new Vector3(
            (grinchPos.position.x + 4),
            (grinchPos.position.y), 
            (grinchPos.position.z)), Quaternion.identity);
    }
    
    private int getLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level1")
        {
            return 0;
        }
        else if (scene.name == "Level2")
        {
            return 1;
        }
        else if (scene.name == "Level3")
        {
            return 2;
        }
        else if (scene.name == "Level4")
        {
            return 3;
        }
        else if (scene.name == "Level5")
        {
            return 4;
        }
        else
        {
            return 5;
        }
    }
}
