using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 2f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyController ec = collision.gameObject.GetComponent<EnemyController>();
        if (ec != null)
        {
            ec.fix();
        }
        Destroy(this.gameObject);
    }

    public void move(Vector2 moveDirction, float moveForce) {
        rigid.AddForce(moveDirction * moveForce);

    }

}
