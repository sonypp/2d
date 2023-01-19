using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
	public Animator anim;
	public Rigidbody2D rb;
	public float speedrun;
	public float jumpforce;
	private Vector2 keyInput;
	public Transform checkground;
	private bool isground;
	private bool isjump;
	public LayerMask layer;
	bool isright = true;
	//public GameObject camera;

	// Use this for initialization
	void Start() {
		isjump = false;
	}

	// Update is called once per frame
	void Update() {
		keyInput = new Vector2(Input.GetAxis("Horizontal"), 0f);
		isground = Physics2D.OverlapCircle(checkground.position, 0.09940436f , layer);
		anim.SetBool("jumpcheck", !isground);
		if (isground) Debug.Log("Vinh");
        if (isground && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("dax cham");
            rb.velocity = Vector2.up * jumpforce;
            isground = false;
        }
		checkdirection();
		anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
		//camera.transform.position = this.gameObject.transform.position;

    }
	void FixedUpdate()
	{
		Movement();
	}
    void Movement()
    {
        rb.velocity = new Vector2(keyInput.x * speedrun,rb.velocity.y) ;
    }
    void checkdirection()
    {
		if ((Input.GetAxis("Horizontal")<0 && isright) || (Input.GetAxis("Horizontal") > 0 && !isright))
        {
			isright = !isright;
			Vector2 direc = this.gameObject.transform.localScale;
			this.gameObject.transform.localScale = new Vector2(-direc.x, direc.y);
        }
    }
	//void OnCollisionEnter2D(Collision2D collision)
 //   {

 //   }






}


