using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage :MonoBehaviour {

    void OnTriggerEnter(Collider collision) {
        if(collision.gameObject.CompareTag("Player")) {
            PlayerMovement player = collision.gameObject.GetComponentInChildren<PlayerMovement>();
            if(player != null) {
                player.PlayerDamaged();
            }
        }
    }
}