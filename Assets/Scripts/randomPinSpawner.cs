using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPinSpawner : MonoBehaviour
{
    [Header("SpawnerSettings")]
    public GameObject prefab;
    public Vector3 center;
    public Vector3 size;
    public int amount = 20;

    [Header("ExplosionModeSettings")]
    public bool explosiveModeOn = false;
    public float explosionRadius;
    public float explosionForce;

    List<GameObject> pines;

    private void Start() {
        pines = new List<GameObject>();
        for (int i = 0; i < amount; i++) {
            Vector3 pos = center + new Vector3(
            Random.Range(-size.x / 2, size.x / 2),
            Random.Range(-size.y / 2, size.y / 2),
            Random.Range(-size.z / 2, size.z / 2));
            pines.Add(Instantiate(prefab, pos, Quaternion.identity));

            foreach (GameObject pin in pines) {
                pin.SetActive(false);
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = new Color(1f, 0f, 0f, 0.3f);
        Gizmos.DrawCube(center, size);
    }

    public void RandomSpawn() {
        foreach (GameObject pin in pines) {
            Vector3 pos = center + new Vector3(
            Random.Range(-size.x / 2, size.x / 2),
            Random.Range(-size.y / 2, size.y / 2),
            Random.Range(-size.z / 2, size.z / 2));
            pin.transform.position = pos;
            pin.transform.rotation = prefab.transform.rotation;
            pin.SetActive(true);
            if (explosiveModeOn) {
                pin.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, pos, explosionRadius);
            }
        }
    }
}
