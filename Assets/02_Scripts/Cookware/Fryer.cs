using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fryer : Cookware
{
    public override void Cook(InteractionItem CookItem)
    {
        item = CookItem;
        StartCoroutine("Cooking");
    }

    public override IEnumerator Cooking()
    {
        if (cookingList.Contains(item))
        {
            item.IsCooking = true;
            uiManager.ShowClickImage();
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.LeftControl));
            uiManager.FillSlider(this.gameObject, cookTime);
            for (int i = 0; i < cookedItemList.Count; i++)
            {
                if(cookedItemList[i].name == $"Cooked{item.name}")
                {
                    yield return new WaitForSeconds(cookTime);
                    item.GetComponent<SpriteRenderer>().sprite = cookedItemList[i].GetComponent<SpriteRenderer>().sprite;
                    item.IsCooking = false;
                }
            }
        }
    }
}
