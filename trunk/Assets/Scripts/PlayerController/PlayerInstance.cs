using UnityEngine;
using System.Collections;
using SGC.Characters;

public class PlayerInstance : MonoBehaviour {

	void Start () {
        var playerObjects = GameObject.FindGameObjectsWithTag("Player");
        
        playerObjects[0].GetComponentInChildren<Uni2DSprite>().VertexColor = new Color32(152, 152, 152, 255);
        playerObjects[0].GetComponent<PlayerFreeMovement>().canControl     = false;
        playerObjects[1].GetComponent<PlayerFreeMovement>().canControl     = true;	
	}
}
