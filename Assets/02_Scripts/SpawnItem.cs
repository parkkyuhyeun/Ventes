using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    bool exist = false;
    public bool Exist
    {
        set => exist = value;
        get => exist;
    }
    void Start()
    {
        
    }

    void Update()
    {
        ItemSpawn();
    }

    private void ItemSpawn()
    {
        if (!exist)
        {
            GameObject item = Instantiate(itemPrefab);
            item.transform.position = transform.position;
            exist = true;
        }
    }
}
