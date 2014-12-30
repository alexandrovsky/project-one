using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {


	public Color highlightColor = Color.red;

	private Color startcolor;

	public Renderer selectionRenderer;
	Character playerCharacter;
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		playerCharacter = player.GetComponent("Character") as Character;
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnMouseEnter()
		
	{
		startcolor = selectionRenderer.material.color;
		selectionRenderer.material.color = highlightColor;
	}
	void OnMouseExit()
	{
		selectionRenderer.material.color = startcolor;
	}


	void OnMouseOver(){
		playerCharacter.target = gameObject;
	}

}
