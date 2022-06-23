using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    [SerializeField] private MeshRenderer mesh;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = !mesh.enabled;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameManager>().restartCurrentLevel();

        }
    }
}
