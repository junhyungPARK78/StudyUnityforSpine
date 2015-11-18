using UnityEngine;
using System.Collections;

public class MonkControlerScript : MonoBehaviour
{
	public float maxspeed = 10f;
	bool facingRight = true;

	Rigidbody rgdbody;
	Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.9f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;

	bool doubleJump = false;

	// Use this for initialization
	void Start ()
	{
		rgdbody = GetComponent<Rigidbody> ();

		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ((grounded || !doubleJump) && Input.GetKeyDown (KeyCode.UpArrow))
		{
			anim.SetBool ("Ground", false);
			rgdbody.velocity = new Vector3(0, 0, 0);
			rgdbody.AddForce(new Vector3(0, jumpForce, 0));

			if(!doubleJump && !grounded)
				doubleJump = true;
		}

		if (Input.GetKeyDown ("1")) 
		{
			anim.Play ("idle_sub",-1,0f);
		}
	}	
		
		
		
		void FixedUpdate ()
	{
		//grounded = Physics.Raycast(groundCheck.position, Vector3.down, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed", rgdbody.velocity.y);

		float move = Input.GetAxis ("Horizontal");

		//if(!grounded)
			//anim.SetFloat("Speed", Mathf.Abs (move * 0.5f));
		//else
			anim.SetFloat("Speed", Mathf.Abs (move));


		rgdbody.velocity = new Vector3 (move * maxspeed, rgdbody.velocity.y, 0);

		if (move > 0 && ! facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

		CheckGround ();

		if (grounded)
			doubleJump = false;




	}

	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void CheckGround()
	{

		RaycastHit hit;
		Debug.DrawRay (groundCheck.position, Vector3.down * groundRadius, Color.red);
		
		if (Physics.Raycast (groundCheck.position, Vector3.down, out hit, groundRadius))
		{
			//if(hit.transform.tag == "whatIsGround")
			//{
			//Debug.Log ("OK");
			//anim.SetBool(grounded = true);
			grounded = true;
			return;
			//}
		}
		

		//Debug.Log("NO");
		grounded = false;
		//anim.SetBool ("Ground", grounded);


	}
}
