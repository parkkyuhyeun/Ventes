using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cookware : MonoBehaviour
{
    public bool onItem;

    public float cookTime;
    public InteractionItem item; //현재 아이템
    public List<InteractionItem> cookingList = new List<InteractionItem>(); //이 조리기구에서 조리 할 음식을 넣어주는 리스트 (이 리스트안에 현재 아이템이 존재해야 조리 가능)
    public List<GameObject> cookedItemList = new List<GameObject>(); //조리 후 아이템을 넣어주는 리스트
    public abstract void Cook(InteractionItem CookItem);
    public abstract IEnumerator Cooking();
}
