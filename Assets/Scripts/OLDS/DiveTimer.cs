using UnityEngine;
using System.Collections;
using SGC.Characters;

public class DiveTimer : MonoBehaviour {

	public float timer = 5;
	public float auxtimer;
	public GUIText gui;
	
	void Start () {
		auxtimer = timer;
	}

	void LateUpdate() {
		if (!this.gameObject.activeInHierarchy) {
			gui.text = " ";
			return;
		}
	}	

	void Update () {
		if (!this.gameObject.activeInHierarchy) return;
		if (!this.gameObject.GetComponent<PlayerFreeMovement>().canControl) return;

        gui.color = (timer <= auxtimer * .5f) ? new Color32(184, 100, 102, 255) : new Color32(134, 169, 92, 255);
        

		if ((auxtimer > 0) && (timer > 0)) {
			timer -= Time.deltaTime;
		}
		if (timer <= 0) {
            this.gameObject.GetComponent<DiverController>().Damage();
            //this.gameObject.GetComponent<PlayerFreeMovement>().live = 0;
		}
		gui.text = "Scuba oxygen " + string.Format("{0:0}",Mathf.Ceil(timer));
	}
}
