using System;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private Vector3 offset;

    private void Awake()
    {
        offset = player.transform.position - transform.position;
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position - offset;
    }
}
