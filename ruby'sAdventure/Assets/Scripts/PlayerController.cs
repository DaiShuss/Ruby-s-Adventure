using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public const float speed = 5f;
    private const float immutableTime = 2f;
    private int maxHealth = 5;

    private float immutableTimer;
    private int curHealth;
    private bool isImmutable = false;

    Rigidbody2D rigidBody;
    Animator animator;
    Vector2 playerDirction = new Vector2(1, 0);

    void Start() {
        this.immutableTimer = 0;
        this.curHealth = 5;
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Player Animation Control
        Vector2 moveVector = new Vector2(moveX, moveY);
        if (moveVector.x != 0 || moveVector.y != 0)
        {
            playerDirction = moveVector;
        }

        animator.SetFloat("Look X", playerDirction.x);
        animator.SetFloat("Look Y", playerDirction.y);
        animator.SetFloat("Speed", moveVector.magnitude);

        // Player Move Control
        Vector2 pos = rigidBody.position;
        pos.x += moveX * speed * Time.deltaTime;
        pos.y += moveY * speed * Time.deltaTime;
        rigidBody.MovePosition(pos);

        // Player Immutable Control
        if (this.isImmutable)
        {
            immutableTimer -= Time.deltaTime;
            if (immutableTimer < 0)
            {
                this.isImmutable = false;
            }
        }
    }

    public void ChangeHealth(int changeNumber)
    {
        if (changeNumber < 0)
        {
            if (this.isImmutable)
            {
                return;
            }
            else
            {
                this.isImmutable = true;
                this.immutableTimer = 2f;
            }
            
        }
        this.curHealth = Mathf.Clamp(curHealth + changeNumber, 0, this.maxHealth);
        if (this.curHealth == 0)
        {
            Debug.Log("玩家死亡");
            Destroy(this.gameObject);
        } else
        {
            Debug.Log(curHealth + "/" + maxHealth);
        }
    }
}

