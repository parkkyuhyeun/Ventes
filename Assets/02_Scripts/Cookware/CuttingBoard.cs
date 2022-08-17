using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : Cookware
{
    public override void Cook(InteractionItem CookItem)
    {
        item = CookItem;
        StartCoroutine(Cooking());
    }

    public override IEnumerator Cooking()
    {
        if (cookingList.Contains(item)) //List.Contains 는 리스트안에 괄호안에 값이 존재하면 True 아니면 false 반환
        {
            item.IsCooking = true; //조리 중 상태로 만들기
            Debug.Log("컨트롤 키를 누루세요"); //나중에 UI로 만들거임
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.LeftControl)); //WaitUntill 은 괄호 안에 값이 true가 될때까지 기다리기
            for(int i = 0; i < cookedItemList.Count; i++)
            {
                if(cookedItemList[i].name == $"Cooked{item.name}") //구운아이템 이름이 현재 아이템 이름과 같다면 똑같은 이름의 구운 아이템을 꺼내기 위해서
                {
                    yield return new WaitForSeconds(cookTime);
                    item.GetComponent<SpriteRenderer>().sprite = cookedItemList[i].GetComponent<SpriteRenderer>().sprite; //다 구워진 아이템 스프라이트로 바꾸기
                    item.IsCooking = false; //조리 중 상태 해제
                }
            }
        }
    }
}
