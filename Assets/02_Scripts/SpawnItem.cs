using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] InteractionItem itemPrefab;
    public bool exist = true;

    private void Start()  //처음 시작할때 아이템 생성해주고 알맞은 리스트에 넣어주기
    {
        InteractionItem item = Instantiate(itemPrefab);
        item.gameObject.name = item.gameObject.name.Replace("(Clone)", "");
        item.transform.position = transform.position;
        switch (itemPrefab.gameObject.name)
        {
            case "Meat":
            case "Shrimp": //Meat와 Shrimp 는 굽기위해서 버너의 cooking 리스트에 넣어줌 *cookware 스크립트 11번 째 줄 참고
                GameObject.Find("L_Burner").GetComponent<Cookware>().cookingList.Add(item);
                GameObject.Find("R_Burner").GetComponent<Cookware>().cookingList.Add(item);
                break;
            case "Chicken": //Chicken 은 튀기기위해서 튀김기의 cooking 리스트에 넣어줌 *cookware 스크립트 11번 째 줄 참고
                GameObject.Find("Fryer_01").GetComponent<Cookware>().cookingList.Add(item);
                GameObject.Find("Fryer_02").GetComponent<Cookware>().cookingList.Add(item);
                break;
            case "Cabbage":
            case "Cucumber":
            case "Onion":
            case "Tomato":
            case "Cheese": //나머지는 써는 것들임으로 커팅 보드에 Cooking리스트에 넣어줌 (Cookware 스크립트 11번째 줄 참고)
                GameObject.Find("Cutting Board").GetComponent<Cookware>().cookingList.Add(item);
                break;
        }

    }

    void Update()
    {
        ItemSpawn();
    }

    private void ItemSpawn()
    {
        if (!exist) //exist가 false가 되면 즉 아이템을 가져가면 다시 생성해주기
        {
            InteractionItem item = Instantiate(itemPrefab);
            item.gameObject.name = item.gameObject.name.Replace("(Clone)", "");
            item.transform.position = transform.position;
            exist = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //아이템이 콜라이더에서 떨어지면 실행 즉 아이템을 가져가면 실행
    {
        if (collision.CompareTag("Item")) exist = false;
    }
}
