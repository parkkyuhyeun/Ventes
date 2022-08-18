using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionItem : MonoBehaviour
{
    private bool onCatch = false;
    private bool isCooking = false;
    private bool isCooked = false;
    public bool IsCooking { get => isCooking; set => isCooking = value; }
    public bool IsCooked { get => isCooked; set => isCooked = value; }
    Player player;
    SpriteRenderer spriteRenderer;
    public void OnCatch(Transform targetTrm)
    {
        onCatch = true;
    }
    public void OnPut(Transform targetTrm)
    {
        onCatch = false;
        transform.position = targetTrm.position;
    }
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (onCatch)
        {
            if(player.LookAt.localPosition == new Vector3(0, -1))
            {
                spriteRenderer.sortingLayerName = "Front Item";
            }
            else
            {
                spriteRenderer.sortingLayerName = "Item";
            }
            transform.position = player.LookAt.position;
        }
    }
}
