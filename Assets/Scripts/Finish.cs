using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (!other.collider.TryGetComponent<Player>(out Player player)) return;
        player.getFinish();
    }
}
