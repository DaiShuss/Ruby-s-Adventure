using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    Rigidbody2D rigidBody;
    private Vector2 moveDirection;
    public bool isVeritical;
    public float directionChangeTime = 2f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        moveDirection = this.isVeritical ? Vector2.up : Vector2.right;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidBody.position;
        directionChangeTime -= Time.deltaTime;
        if (directionChangeTime < 0)
        {
            moveDirection *= -1;
            directionChangeTime = 2f;
        }
        position.x += moveDirection.x * speed * Time.deltaTime;
        position.y += moveDirection.y * speed * Time.deltaTime;
        rigidBody.MovePosition(position);
        animator.SetFloat("moveX", moveDirection.x);
        animator.SetFloat("moveY", moveDirection.y);
    }
}
