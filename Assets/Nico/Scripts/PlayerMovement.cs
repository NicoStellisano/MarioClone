using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	
	/*
	Script para detectar inputs de movimiento
	y ejecutarlo

	Comentarios:
	Los Inputs como "Horizontal", "Jump", están
	configurados en Edit -> ProjectSettings -> Input
	
	
	 */



	public CharacterController2D controller;
	public Animator animator;
	float horizontalMove = 0f;
	public float runSpeed = 40f;
	bool jump = false;
	//bool crouch = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//-1 Si presiona A , +1 Si presiona D, si no presiona 0.
		// Se multiplica por la velocidad
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		// Mathf.Abs hace el valor positivo siempre
		animator.SetFloat("Speed",Mathf.Abs(horizontalMove));

		if(Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping",true);
		}
			

		//if(Input.GetButtonDown("Crouch"))			
		//	crouch=true;
		//else if(Input.GetButtonUp("Crouch"))
		//	crouch=false;

	}

	void FixedUpdate () {
		//Move Character
		//Parametros:Movimiento por tiempo,Se agacha?,Salta?
		// Time.fixedDeltaTime = El tiempo en que se actualiza fixedUpdate
		controller.Move(horizontalMove * Time.fixedDeltaTime,false,jump);
		jump = false;

	}

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}
}
