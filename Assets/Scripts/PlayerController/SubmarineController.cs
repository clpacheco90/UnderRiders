using UnityEngine;
using System.Collections;
using SGC.Characters;
using SGC.Cameras;

public class SubmarineController : MonoBehaviour {

    public GameObject CaptainTileSet;
	// Use this for initialization
	void Start () {
        if (CaptainTileSet != null) return;        
        Debug.Log("CaptainTileSet is null");
	}
	
	// Update is called once per frame
	void Update () {        
        CaptainTileSet.GetComponent<Uni2DSprite>().VertexColor            = (this.GetComponent<PlayerFreeMovement>().canControl) ? new Color32(255, 255, 255, 255) : new Color32(152, 152, 152, 255);
        CaptainTileSet.GetComponent<Uni2DSprite>().spriteAnimation.Paused = (this.GetComponent<PlayerFreeMovement>().canControl) ? false : true;        
	}

    public void OnTriggerEnter(Collider c) {
        if (!c.gameObject.CompareTag("Player")) return;
        if (c.gameObject.name.Equals(this.name)) return;
        Debug.Log("ENTER");
        if (c.gameObject.GetComponent<DiverController>().IsOnSubmarine()) {
            Debug.Log("SUB");
            return;
        }
                
        Camera.main.gameObject.GetComponent<CameraMoveAt>().gameTransform  = this.transform;
        this.GetComponent<PlayerFreeMovement>().canControl                 = true;                
        this.GetComponentInChildren<Uni2DSprite>().VertexColor             = new Color32(255, 255, 255, 255);
        
        c.gameObject.GetComponent<PlayerFreeMovement>().canControl         = false;
        c.gameObject.GetComponent<PlayerFreeMovement>().movement.direction = Vector3.zero;
        c.gameObject.GetComponent<DiveTimer>().timer                       = c.gameObject.GetComponent<DiveTimer>().auxtimer;
        c.gameObject.GetComponent<DiveTimer>().gui.text                    = string.Empty;
        c.gameObject.GetComponent<DiverController>().DiverTileSetColor();
        c.gameObject.GetComponent<DiverController>().SetOnSubmarine(true);

        c.gameObject.SetActive(false);
    }
}

