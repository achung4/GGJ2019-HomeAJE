using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        float x= PlayerPrefs.GetFloat("p_x");

        if( scene.name == "Level0" )
        {
            transform.position = new Vector3( (float)-6.5, (float)-1.3, 0 );

        } else if(scene.name == "Level1" )
        {
            if ( x < 0 )
            {
                transform.position = new Vector3((float)-7.3, (float)-1.3, 0);
            } else if ( x == 0)
            {
                transform.position = new Vector3((float)-7.3, 0, 0);
            } else if ( x > 0)
            {
                transform.position = new Vector3((float)7.3, (float)-1.3, 0);
            }

        } else if(scene.name == "Level2")
        {
            transform.position = new Vector3((float)6.5, (float)-1.3, 0);
        }

        PlayerPrefs.DeleteAll();
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
