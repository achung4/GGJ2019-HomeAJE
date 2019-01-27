using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rigid;
    private SpriteRenderer playerSprite;

    [SerializeField]
    private float velocity = 1.0f;

    [SerializeField]
    private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if ( Input.GetKey( KeyCode.A ) ) {
            rigid.MovePosition(new Vector2 ( transform.position.x - velocity * Time.deltaTime, transform.position.y ));
        } 
         if ( Input.GetKey( KeyCode.D ) ) {
            rigid.MovePosition(new Vector2(transform.position.x + velocity * Time.deltaTime, transform.position.y));
        } 
         if ( Input.GetKey( KeyCode.W ) ) {
            rigid.MovePosition(new Vector2(transform.position.x, transform.position.y + velocity * Time.deltaTime));
        } 
        if ( Input.GetKey( KeyCode.S ) ) {
            rigid.MovePosition(new Vector2(transform.position.x, transform.position.y - velocity * Time.deltaTime));
        }
    }


}
