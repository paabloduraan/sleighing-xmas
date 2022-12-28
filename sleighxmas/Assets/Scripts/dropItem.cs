using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dropItem : MonoBehaviour
{
    public GameObject[] itemList; // Stores the gifts
    public Transform grinchPos;
    public Transform santaPos;

    void update()
    {
        grinchPos = GetComponent<Transform>();
        santaPos  = GetComponent<Transform>();
    }

    public void SantaDropItem()
    {
        Instantiate(itemList[0], new Vector3(
            (santaPos.position.x + 4),
            (santaPos.position.y),
            (santaPos.position.z)), Quaternion.identity);
    }

    public void GrinchDropItem()
    {
        Instantiate(itemList[0], new Vector3(
            (grinchPos.position.x + 4),
            (grinchPos.position.y),
            (grinchPos.position.z)), Quaternion.identity);
    }
}
