using UnityEngine;
using System.Collections;
using SGC.Characters;
using SGC.Cameras;

public class DiverIsOnTheSubmarine : MonoBehaviour {

	private GameObject diver;
	// Use this for initialization
	void Start () {
		diver = GameObject.Find("DiverPlayer");
	}
	
	// Update is called once per frame
	void Update () {
		if (diver == null) return;
		if (!diver.GetComponent<DiverController>().IsOnSubmarine()) return;

		if ((!diver.GetComponent<PlayerFreeMovement>().canControl) && (!this.gameObject.GetComponent<PlayerFreeMovement>().canControl)) {
			diver.gameObject.SetActive(true);
			diver.GetComponent<PlayerFreeMovement>().canControl               = true;
			Camera.main.gameObject.GetComponent<CameraMoveAt>().gameTransform = diver.transform;
			diver.transform.position                                          = new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z - 1);
			diver.GetComponentInChildren<Uni2DSprite>().VertexColor           = new Color32(0, 0, 0, 255);
		}
	}
}
