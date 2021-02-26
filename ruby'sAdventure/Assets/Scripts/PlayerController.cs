using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;
    Rigidbody2D rigidBody;
    private int curHealth;
    private int maxHealth = 5;
    private bool isImmutable = false;
    private const float immutableTime = 2f;
    private float immutableTimer = 2f;

    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        this.immutableTimer = 0;
        this.curHealth = 5;
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void FixedUpdate() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 pos = rigidBody.position;
        pos.x += moveX * speed * Time.deltaTime;
        pos.y += moveY * speed * Time.deltaTime;
        rigidBody.position = pos;

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

