using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Level section controller
public class LSController : MonoBehaviour {

    public delegate void OnCheckPointHandler();
    public static event OnCheckPointHandler playerEnterSection;
    private bool playerEnterThis = false;

    public void InitializeObstacles() {
		foreach(PolyObstacle obstacle in transform.GetComponentsInChildren<PolyObstacle>()) {
			obstacle.InitializeObstacle();
		}
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("chek");
        if (playerEnterThis == false && collision.gameObject.CompareTag("Player")) {
            Debug.Log("enter");
            if (playerEnterSection != null) {
                playerEnterSection();
                playerEnterThis = true;
            }
        }
    }
}
