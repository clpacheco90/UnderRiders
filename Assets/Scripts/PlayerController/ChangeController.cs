using UnityEngine;
using System.Collections;
using SGC.Characters;
using SGC.Cameras;

public class ChangeController : MonoBehaviour {	
    
    void Update () {
        if (this.gameObject.activeInHierarchy) {
            
            if (Input.GetButtonDown("Fire1")) {
                this.GetComponent<PlayerFreeMovement>().canControl = !this.GetComponent<PlayerFreeMovement>().canControl;
                
                if (!this.GetComponent<PlayerFreeMovement>().canControl) {
                    this.GetComponentInChildren<Uni2DSprite>().VertexColor = new Color32(152, 152, 152, 255);                    
                    return;
                }

                this.GetComponent<AudioSource>().Play();
                this.GetComponentInChildren<Uni2DSprite>().VertexColor            = new Color32(255, 255, 255, 255);
                Camera.main.gameObject.GetComponent<CameraMoveAt>().gameTransform = this.transform;
            } //if

        }
	}
}
