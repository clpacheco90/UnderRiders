using UnityEngine;
using System.Collections;

public class CameraBlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider p) {
        if (!p.CompareTag("Player")) return;
        //Camera.main.gameObject.GetComponent<CameraMoveAt>()._constrainsts.freezeX = true;
    }

    void OnTriggerExit(Collider p) {
        if (!p.CompareTag("Player")) return;
        //Camera.main.gameObject.GetComponent<CameraMoveAt>()._constrainsts.freezeX = false;
    }
}
