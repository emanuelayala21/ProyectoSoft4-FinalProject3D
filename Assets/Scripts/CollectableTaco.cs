using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableTaco :MonoBehaviour {

    [SerializeField] private float rotateSpeed = 80f; // m�s r�pido
    [SerializeField] private float floatSpeed = 4f;     // m�s r�pido el sube/baja
    [SerializeField] private float floatAmplitude = 0.5f; // sube/baja m�s alto

    private Vector3 startPos;

    private void Start() {
        startPos = transform.position;
    }

    private void Update() {
        // Rotaci�n constante
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);

        // Movimiento vertical tipo "flotante"
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
