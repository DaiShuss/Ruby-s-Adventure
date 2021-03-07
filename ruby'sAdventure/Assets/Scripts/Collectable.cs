using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public ParticleSystem collectEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.GetComponent<PlayerController>();
        if (pc != null)
        {
            Debug.Log("碰到了");
            Instantiate(collectEffect, transform.position, Quaternion.identity);
            pc.ChangeHealth(2);
            Destroy(this.gameObject);
        
        }
    }
}
