using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance = null;
    [SerializeField] int coin = 100;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    [SerializeField] private Transform parent;

    [SerializeField] private GameObject[] orders;

    private List<GameObject> currentOrders = new List<GameObject>();
    public List<GameObject> CurrentOrders { get => currentOrders; }

    private void Start()
    {
        StartCoroutine(OrderCoroutine());
    }

    IEnumerator OrderCoroutine()
    {
        while (true)
        {
            GameObject prefab = orders[Random.Range(0, orders.Length)];
            GameObject order = Instantiate(prefab, parent);
            currentOrders.Add(order);
            yield return new WaitForSeconds(35f);
        }
    }

    public void Submission(GameObject item)
    {
        if (currentOrders[0].name == item.name)
        {
            Debug.Log("성공");
            FindObjectOfType<ScoreManager>().AddScore(coin);
        }
        else
        {
            Debug.Log("실패");
        }
        GameObject temp = currentOrders[0];
        currentOrders.RemoveAt(0);
        Destroy(temp);
        Destroy(item);
    }
}
