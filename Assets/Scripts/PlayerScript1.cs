using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript1 : MonoBehaviour
{

    private Rigidbody2D rigid;
    private SpriteRenderer playerSprite;

    [SerializeField]
	[Range(3f,10f)]
    private float velocity = 1.0f;

    [SerializeField]
    private LayerMask groundLayer;
	
	void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>(); 
    }
	
    void Update()
    {
        Examine();
    }

	private void FixedUpdate() {
		Movement();
	}

	void Movement()
    {
		float inputX = Input.GetAxisRaw("Horizontal");
		float inputY = Input.GetAxisRaw("Vertical");

		Vector2 velocity2 = new Vector2(inputX, inputY);
		velocity2 = velocity2.normalized;


		Vector2 destLocation = new Vector2(transform.position.x, transform.position.y) + 
			velocity2 * velocity * Time.deltaTime;
		rigid.MovePosition(destLocation);

		/*
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
		*/
	}

    void Examine()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            foreach( Transform child in HidingSpotsManager.hidingSpotsList)
            {
                Debug.Log( "furniture name : " + child.name);
				//if ( distance(transform.position, child.position) < 1.6) 
				// squareroot is slow, use square distance instead //2.56f
				if ((transform.position - child.position).sqrMagnitude < 2f)
				{
                    Debug.Log("?name? : " + child.name);
                    child.GetComponent<Prop>().onExamine();
                }
            }
        }
    }

    private float distance( Vector3 v1, Vector3 v2 )
    {
        return Mathf.Sqrt(Mathf.Pow((v1.x - v2.x), 2) + Mathf.Pow((v1.y - v2.y), 2));
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        float x = PlayerPrefs.GetFloat("p_x");

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
