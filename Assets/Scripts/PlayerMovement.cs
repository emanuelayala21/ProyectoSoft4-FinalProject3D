using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement :MonoBehaviour {
    private float _playerSpeed = 5f;
    private float _horizontalSpeed = 5f;
    private Animator _animator;
    private bool _isDamaged = false;

    private void Start() {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update() {
        if(!_isDamaged) {
            transform.Translate(Vector3.forward * _playerSpeed * Time.deltaTime);
            PlayerMovementF();
        }
    }

    private void PlayerMovementF() {
        if(_isDamaged) return;
        float inputX = Input.GetAxis("Horizontal");  // Lee las teclas A/D o flechas izquierda/derecha
        float moveX = inputX * _horizontalSpeed * Time.deltaTime;  // Calcula el movimiento en X

        // Limita el movimiento horizontal (en el eje X) entre -6 y 6
        if(transform.position.z + moveX > -62f && transform.position.z + moveX < -50f) {
            transform.Translate(Vector3.right * moveX);  // Mueve al personaje en X
        }
    }

    public void PlayerDamaged() {
        _isDamaged=true;
        _animator.SetTrigger("Dead");
    }
}
