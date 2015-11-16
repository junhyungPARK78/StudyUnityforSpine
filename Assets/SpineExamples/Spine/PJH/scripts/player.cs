using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public Animator anim;
	public Rigidbody rbody;

	private float inputH;
	private float inputV;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		rbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if (Input.GetKeyDown ("1")) 
		{
			anim.Play ("idle_sub",-1,0f);
		}

		 if (Input.GetMouseButtonDown (0))
		{
			int n = Random.Range(0,2);

			if(n == 0)
			{
				anim.Play ("damage",-1,0f);
			}
			else
			{
				anim.Play ("damage_wakeup",-1,0f);
			}
		}

		inputH = Input.GetAxis ("Horizontal");

		anim.SetFloat ("inputH",inputH);
		anim.SetFloat ("inputV",inputV);

		float moveX = inputH * 50f * Time.deltaTime;

		rbody.velocity = new Vector3 (moveX,0f,0f);

	}
}
