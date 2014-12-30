using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public Transform player;
	public float range;
	public float attackRange;
	public bool charged;

	Character character;
	// Use this for initialization
	void Start () {
		charged = false;
		character = GetComponent("Character") as Character;
		character.target = GameObject.FindGameObjectWithTag("Player");
	}

	
	// Update is called once per frame
	void Update () {
	
		if(!charged){
			character.state = CharacterState.CharacterStateIdle;
			if( Vector3.Distance(transform.position, player.position) < range ){
				charged = true;
			}
		}else if(Vector3.Distance(transform.position, player.position) > attackRange) {

			character.state = CharacterState.CharacterStateRun;
			character.moveDestinationPosition = player.position;

			Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
			if(Quaternion.Angle(targetRotation, transform.rotation) > Mathf.PI/8){
				targetRotation.x = 0;
				targetRotation.z = 0;
				character.moveDestinationRotation = targetRotation;
			}


		}else {
			character.state = CharacterState.CharacterStateAttack;
		}
	}



}
