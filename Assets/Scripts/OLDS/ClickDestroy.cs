using UnityEngine;
using System.Collections;

public class ClickDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.touchCount > 0) || (Input.anyKey)) {
            StartCoroutine(WaitToDestroy());
        }	
	}

    IEnumerator WaitToDestroy() {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);

    }
}

