using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement :MonoBehaviour {
    private float _playerSpeed = 3.5f;
    private float _horizontalSpeed = 5f;

    private void Update() {
        transform.Translate(Vector3.forward *_playerSpeed * Time.deltaTime);
        PlayerMovementF();
    }

    private void PlayerMovementF() {
        float inputX = Input.GetAxis("Horizontal");
        float moveZ = inputX * _horizontalSpeed * Time.deltaTime;

        float newZ = transform.position.z + moveZ;

        // Limita el movimiento horizontal (en el eje Z)
        if(newZ > -6f && newZ < 6f) {
            transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
        }
    }
}
