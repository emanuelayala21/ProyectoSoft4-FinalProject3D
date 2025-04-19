using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator :MonoBehaviour {

    public GameObject[] segmentMap;
    [SerializeField] private float xPos = -150f; // empieza detrás de los 2 primeros segmentos
    private float yPos = 39.00474f;

    public Transform player;
    private List<GameObject> spawnedSegments = new List<GameObject>();
    private float generateDistance = 130f; // si jugador está a menos de 100 del siguiente segmento
    private float destroyOffset = 20f; // apenas esté detrás del jugador, se destruye

    void Update() {
        if(player == null) return;

        if(player.position.x - xPos < generateDistance) {
            SpawnSegment();
        }

        CleanUpSegments();
    }

    void SpawnSegment() {
        int segmentNum = Random.Range(0, segmentMap.Length);
        Vector3 spawnPosition = new Vector3(xPos, yPos, 0);
        GameObject newSegment = Instantiate(segmentMap[segmentNum], spawnPosition, Quaternion.identity);
        spawnedSegments.Add(newSegment);

        xPos -= 50f; // siguiente posición, hacia la izquierda
    }

    void CleanUpSegments() {
        for(int i = spawnedSegments.Count - 1; i >= 0; i--) {
            GameObject segment = spawnedSegments[i];

            if(segment != null && segment.transform.position.x > player.position.x + destroyOffset) {
                Destroy(segment);
                spawnedSegments.RemoveAt(i);
            }
        }
    }
}
