using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    public float parametr;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDroppedItem()
    {
        Vector2 playerPos = new Vector2(player.position.x + parametr, player.position.y);
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
