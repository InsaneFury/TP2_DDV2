using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPinSpawner : MonoBehaviour
{
    public GameObject prefab;

    public Vector3 center;
    public Vector3 size;
    public int amount = 20;

    public void randomSpawn() {
        
        for (int i = 0; i < amount; i++) {
            Vector3 pos = center + new Vector3(
            Random.Range(-size.x / 2, size.x / 2),
            Random.Range(-size.y / 2, size.y / 2),
            Random.Range(-size.z / 2, size.z / 2));
            Instantiate(prefab, pos, Quaternion.identity);
        }
        
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = new Color(1f, 0f, 0f, 0.3f);
        Gizmos.DrawCube(center, size);
    }

    
}
