using UnityEngine;
using System.Collections;

public class FishColliders : MonoBehaviour {

    public bool isMoving;    


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

    void OnTriggerEnter(Collider p) {
        Debug.Log("Collides");
        if (!p.CompareTag("Player")) return;
        if (p.name.Equals("DiverController")) {
            //p.GetComponent<PlayerController>()._live = 0;
        } else {
            isMoving = false;
        } //if
    }

    void OnTriggerExit(Collider p) {
        if (!p.CompareTag("Player")) return;
        if (!p.name.Equals("DiverController")) {            
            isMoving = true;
        }//if
    }
}
