using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour {

    //стартовый для уровня чекпоинт
    //public Transform prevCheckpoint;


    public delegate void OnCheckPointHandler();
    public static event OnCheckPointHandler playerRichCheckPoint;


    public void OnTriggerEnter2D(Collider2D collision) {
        //Debug.Log("chek");
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("chek");
            if (playerRichCheckPoint != null) {
                playerRichCheckPoint();
            }

            //MainGameController go = GameObject.Find("GameControler").GetComponent<MainGameController>();
            //go.
            //go.NextLevel();
            
            //go.GetComponent<MainGameController>().NextLevel();
        }
    }
    public void OnTriggerExit2D(Collider2D collision) {
        //if (collision.gameObject.CompareTag("Player")) {
           // DestroyObject(gameObject);
        //}/
    }
    
}