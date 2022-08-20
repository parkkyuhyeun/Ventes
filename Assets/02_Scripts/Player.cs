using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform lookAt;
    Animator anim;
    Rigidbody2D rigid;
    float maxDistance = 5f;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] LayerMask targetLayer2;
    bool isCatch = false;
    InteractionItem currentItem;
    Cookware currentCookware;

    CreateBurger createBurger;

    [SerializeField] private List<RecipeEnum> currentRecipe = new List<RecipeEnum>();

    public Transform LookAt { get => lookAt; }
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        createBurger = GameObject.Find("Plate").GetComponent<CreateBurger>();
    }
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(currentRecipe.Count > 0) createBurger.Create(currentRecipe);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isCatch)
            {
                Catch();
            }
            else
            {
                Put();
            }
        }
    }

    private void Move()
    {
        anim.SetBool("isWalk_Back", Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow));
        anim.SetBool("isWalk_Front", Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow));
        anim.SetBool("isWalk_Right", Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow));
        anim.SetBool("isWalk_Left", Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow));
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            lookAt.transform.localPosition = new Vector2(0, -0.5f);
            lookAt.transform.right = Vector2.up;
            transform.position = transform.position + transform.up * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow))
        {
            lookAt.transform.localPosition = new Vector2(0, -1);
            lookAt.transform.right = Vector2.down;
            transform.position = transform.position - transform.up * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {
            lookAt.transform.localPosition = new Vector2(0.6f, -1);
            lookAt.transform.right = Vector2.right;
            transform.position = transform.position + transform.right * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
        {
            lookAt.transform.localPosition = new Vector2(-0.8f, -1);
            lookAt.transform.right = Vector2.left;
            transform.position = transform.position - transform.right * Time.deltaTime * speed;
        }
    }

    void Catch()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.5f), lookAt.transform.right, maxDistance, targetLayer);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 0.5f), lookAt.transform.right, Color.yellow, maxDistance);
        if (hit)
        {
            currentItem = hit.transform.GetComponent<InteractionItem>();

            if (!isCatch && !currentItem.IsCooking) //조리 중에는 못가져가게 하기 위해서
            {
                if (currentItem.transform.parent != null)
                {
                    Mix(currentItem, 1);
                    currentItem.transform.SetParent(null);
                }
                isCatch = true;
                currentItem.OnCatch(lookAt);
            }
        }
    }
    void Put()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.5f), lookAt.transform.right, maxDistance, targetLayer2);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 0.5f), lookAt.transform.right, Color.yellow, maxDistance);
        if (hit)
        {
            if(hit.transform.gameObject.layer == 8)
            {
                currentCookware = hit.transform.GetComponent<Cookware>();
                if (isCatch && !currentItem.IsCooking && !currentCookware.onItem)
                {
                    if (!currentItem.IsCooked)
                    {
                        currentItem.OnPut(hit.transform);
                        isCatch = false;
                        currentCookware.Cook(currentItem);
                    }
                }
            }
            if(hit.transform.gameObject.layer == 9)
            {
                if(isCatch && (currentItem.IsCooked || currentItem.name == "Bun"))
                {
                    Mix(currentItem, 0);
                    currentItem.OnPut(hit.transform);
                    currentItem.transform.SetParent(GameObject.Find("CurrentRecipe").transform);
                    isCatch = false;
                }
            }
        }
    }

    private void Mix(InteractionItem item, int type)
    {
        if(type == 0)
        {
            switch (item.name)
            {
                case "Tomato":
                    currentRecipe.Add(RecipeEnum.Tomato);
                    break;
                case "Cabbage":
                    currentRecipe.Add(RecipeEnum.Cabbage);
                    break;
                case "Cheese":
                    currentRecipe.Add(RecipeEnum.Cheese);
                    break;
                case "Meat":
                    currentRecipe.Add(RecipeEnum.Meat);
                    break;
                case "Cucumber":
                    currentRecipe.Add(RecipeEnum.Cucumber);
                    break;
                case "Onion":
                    currentRecipe.Add(RecipeEnum.Onion);
                    break;
                case "Shrimp":
                    currentRecipe.Add(RecipeEnum.Shrimp);
                    break;
                case "Chicken":
                    currentRecipe.Add(RecipeEnum.Chicken);
                    break;
                case "Bun":
                    currentRecipe.Add(RecipeEnum.Bun);
                    break;
            }
        }
        if(type == 1)
        {
            switch (item.name)
            {
                case "Tomato":
                    currentRecipe.Remove(RecipeEnum.Tomato);
                    break;
                case "Cabbage":
                    currentRecipe.Remove(RecipeEnum.Cabbage);
                    break;
                case "Cheese":
                    currentRecipe.Remove(RecipeEnum.Cheese);
                    break;
                case "Meat":
                    currentRecipe.Remove(RecipeEnum.Meat);
                    break;
                case "Cucumber":
                    currentRecipe.Remove(RecipeEnum.Cucumber);
                    break;
                case "Onion":
                    currentRecipe.Remove(RecipeEnum.Onion);
                    break;
                case "Shrimp":
                    currentRecipe.Remove(RecipeEnum.Shrimp);
                    break;
                case "Chicken":
                    currentRecipe.Remove(RecipeEnum.Chicken);
                    break;
                case "Bun":
                    currentRecipe.Remove(RecipeEnum.Bun);
                    break;
            }
        }
    }
}
