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
    public Cookware CurrentCookware { get => currentCookware; }
    
    public Transform LookAt { get => lookAt; }
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isCatch) Catch();
            else Put();
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
            if (!isCatch)
            {
                isCatch = true;
                Debug.Log("catch");
                Debug.Log("hit");
                InteractionItem interactionItem = hit.transform.GetComponent<InteractionItem>();
                interactionItem.OnCatch(lookAt);
                currentItem = interactionItem;
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
            if (isCatch)
            {
                if (hit.transform.gameObject.layer == 8)
                {
                    Debug.Log("Put");
                    currentItem.OnPut(hit.transform);
                    isCatch = false;
                    currentCookware = hit.transform.GetComponent<Cookware>();
                    currentCookware.onItem = true;
                }
            }
        }
    }
}
