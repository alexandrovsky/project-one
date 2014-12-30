using UnityEngine;
using System.Collections;


public enum CharacterState{
	CharacterStateIdle,
	CharacterStateWalk,
	CharacterStateRun,
	CharacterStateAttack,
	CharacterStateGetHit,
	CharacterStateDie,
	CharacterStateLevelUp,
	CharacterStateLevelOther, // this is for empty animation
}

public class Character : MonoBehaviour {

	public uint level = 1;
	public float health = 100;
	public float mana = 100;
	public float strength = 5;

	public float attackCooldown = 2;
	public float attackTimer = 2;


	public float speedDefault = 10;
	public float speed;

	public Vector3 moveDestinationPosition;
	public Quaternion moveDestinationRotation;

	public CharacterState state = CharacterState.CharacterStateIdle;


	public AnimationClip runAnimation;
	public AnimationClip idleAnimation;
	public AnimationClip attackAnimation;
	public AnimationClip getHitAnimation;

	public GameObject target;

	// Use this for initialization
	void Start () {
		speed = speedDefault;
	}
	
	// Update is called once per frame
	void Update () {

		switch(state){
		case CharacterState.CharacterStateIdle:
			animation.CrossFade(idleAnimation.name);
			break;
		case CharacterState.CharacterStateWalk:
			break;
		case CharacterState.CharacterStateRun:
			run();
			break;
		case CharacterState.CharacterStateAttack:
			attack();
			break;
		case CharacterState.CharacterStateGetHit:
			gethit();
			break;
		case CharacterState.CharacterStateDie:
			break;
		case CharacterState.CharacterStateLevelUp:
			break;
		}
	}



	public void run(){
//		float angle = Quaternion.Angle(transform.rotation, moveDestinationRotation);

		transform.rotation = Quaternion.Slerp(transform.rotation, moveDestinationRotation, Time.deltaTime * 10);
		transform.position = Vector3.MoveTowards(transform.position, moveDestinationPosition, speed * Time.deltaTime);
		animation.CrossFade(runAnimation.name);
	}


	public void attack(){



		if(attackTimer == 0.0f){
			animation.CrossFade(attackAnimation.name);
			Character targetChar = target.GetComponent("Character") as Character;
			targetChar.state = CharacterState.CharacterStateGetHit;
			attackTimer = attackCooldown;
		}else if(attackTimer < 0.0f){
			attackTimer = 0.0f;
		}else{
			attackTimer -= Time.deltaTime;
		}



	}

	public void gethit(){
		Debug.Log(gameObject.name + " get hit" + state);
		animation.Play(getHitAnimation.name);
	}

}
