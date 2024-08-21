using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public string[] itemTags;

    void Start()
    {
        itemTags = new string[slots.Length];
    }
}