using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    [SerializeField] private Player pl;
    [SerializeField] private Vector3 platformCameraOffset;
    [SerializeField] public float speed;
    // Update is called once per frame
    void Update()
    {
        if (pl.currentPlatform == null) return;

        Vector3 position = pl.currentPlatform.transform.position + platformCameraOffset;
        transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);
    }
}
