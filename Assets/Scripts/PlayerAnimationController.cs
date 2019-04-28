using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
	private static Animator animator;

    void Start()
    {
		animator = GetComponent<Animator>();
    }

	public static void PlayerFallsDown()
	{
		if(FinaleScript.isDying == true)
		{
			animator.SetBool("isDead", true);
			animator.Play("PlayerFallDown");
		}
		else
		{

		}
	}
}
