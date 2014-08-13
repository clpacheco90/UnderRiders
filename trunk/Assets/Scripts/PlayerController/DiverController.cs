using UnityEngine;
using System.Collections;
using SGC.Characters;
using SGC.Cameras;
using SGC.Math;

public class DiverController : Character {

    public GameObject DiverTileSet;
    
    private bool isOnSubmarine;
    private GameObject submarine;
    
    void Start() {
        this.submarine = GameObject.Find("SubMarinePlayer");
        if (DiverTileSet != null) return;
        Debug.Log("CaptainTileSet is null");
    }

	void Update () {
        DiverTileSetColor();

        if (!this.isOnSubmarine) return;
        if (this.submarine == null) return;

        float distance = Vector3.Distance(new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z + 1), this.submarine.gameObject.transform.position);
        //Debug.DrawLine(new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z + 1),this.submarine.gameObject.transform.position, Color.white);

        if (distance > 0.6) {
            this.isOnSubmarine                                                = !this.isOnSubmarine;
            this.gameObject.GetComponentInChildren<Uni2DSprite>().VertexColor = new Color32(255, 255, 255, 255);
            this.gameObject.transform.position                                = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z + 1);
            this.GetComponent<DiveTimer>().enabled = true;
        } else {
            this.GetComponent<DiveTimer>().enabled = false;

            //remove damage event
        }
	}

    internal void DiverTileSetColor() {
        DiverTileSet.GetComponent<Uni2DSprite>().VertexColor            = (this.GetComponent<PlayerFreeMovement>().canControl) ? new Color32(255, 255, 255, 255) : new Color32(152, 152, 152, 255);
        DiverTileSet.GetComponent<Uni2DSprite>().spriteAnimation.Paused = (this.GetComponent<PlayerFreeMovement>().canControl) ? false : true;
    }

    internal bool IsOnSubmarine() {
        return this.isOnSubmarine;
    }
    
    internal void SetOnSubmarine(bool respawn) {
        this.isOnSubmarine = respawn;
    }

    //Change by events
    public override float Damage() {
        //this.GetComponent<PlayerFreeMovement>()
        this.live--;
        //blink
        //setActive false
        // can control false

        //c.gameObject.GetComponent<PlayerFreeMovement>().canControl = false;
        //c.gameObject.GetComponent<PlayerFreeMovement>().movement.direction = Vector3.zero;
        //c.gameObject.GetComponent<DiverController>().SetOnSubmarine(true);
        //c.gameObject.SetActive(false);

        if (this.live <= 0) {
            //SetGAMEOVER
            Debug.LogWarning("SETGAMEOVER");
        }
        return 0;
    }
}
