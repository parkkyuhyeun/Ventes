using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionItem : MonoBehaviour
{
    private bool isCatch = false;
    Player player;
    SpriteRenderer spriteRenderer;
    public void OnCatch(Transform targetTrm)
    {
        isCatch = true;
    }
    public void OnPut(Transform targetTrm)
    {
        if (player.CurrentCookware != null &&player.CurrentCookware.onItem) return;
        isCatch = false;
        transform.position = targetTrm.position;
    }
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isCatch)
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
