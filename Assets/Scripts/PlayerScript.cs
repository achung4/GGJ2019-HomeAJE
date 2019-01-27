using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rigid;
    private SpriteRenderer playerSprite;

    [SerializeField]
	[Range(3f,10f)]
    private float velocity = 1.0f;

    [SerializeField]
    private LayerMask groundLayer;

	private Animator anim;

	// odd (+1): idel, even: animation, 0: up, 2: left, 4: right, 6: bottom.
	int animatorState;
	bool isWalking;
	int lastAnimatorState = -6;
	string[] animationNames = { "dad_up", "dad_idel_up",
		"dad_left", "dad_idel_left",
		"dad_right", "dad_idel_right",
		"dad_bottom", "dad_idel_bottom" };
	bool isPlayingAnim = false;
	Vector2 lastVel;

	void Start()
    {
		// transform.position = LevelManager.characterInitPosition;


		rigid = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();

		anim = GetComponent<Animator>();

	}

	private void OnMouseDown() {

		anim.Play(animationNames[1]);
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

		if (velocity2 != Vector2.zero) {
			isWalking = true;
			lastVel = velocity2;
		}
		else {
			isWalking = false;
		}
		anim.SetBool("isWalking", isWalking);
		anim.SetFloat("last_velX", lastVel.x);
		anim.SetFloat("last_velY", lastVel.y);
		anim.SetFloat("velX", velocity2.x);
		anim.SetFloat("velY", velocity2.y);



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
	
	



}
