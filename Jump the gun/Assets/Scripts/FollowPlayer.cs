using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform PlayerHead;
    void Update()
    {
        this.transform.position = PlayerHead.transform.position;
    }
}
