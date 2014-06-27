using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 6;

	// Update is called once per frame
	void Update () {
		rigidbody.MovePosition (transform.position + transform.forward * Time.deltaTime * speed);

		if( Input.GetButtonDown("Fire1")){
			GetComponent<Animator>().SetTrigger("JUMP");
		}

		if( Input.GetButtonDown("Fire2")){
			GetComponent<Animator>().SetTrigger("SLIDE");
		}
	}

	void OnTriggerEnter (Collider colider)
	{
		var stateInfo = GetComponent<Animator>().GetCurrentAnimatorStateInfo (0);
		bool isJump = stateInfo.IsName("Base Layer.JUMP00");
		bool isSlide = stateInfo.IsName("Base Layer.SLIDE00");
		bool isRun = stateInfo.IsName("Base Layer.RUN00_F");

		bool isHigh = colider.CompareTag("High");
		bool isLow = colider.CompareTag("Low");

		if( (isRun == true) ||
		    (isJump == true && isHigh == true) ||
		    (isSlide == true && isLow == true))
		{
			GetComponent<Animator>().SetBool ("DEAD", true);
			speed = 0;
		}
	}
}
