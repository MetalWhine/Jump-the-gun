using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private MeshRenderer mesh;
    public Animator timerAnimator;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = !mesh.enabled;
        timerAnimator = FindObjectOfType<timerScript>().GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            timerAnimator.SetTrigger("EndGoal");
        }
    }
}
