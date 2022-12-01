using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour
{
    public bool isGood = true;
    public Material GodMaterial;
    public Material BadMaterial;
    [SerializeField] private GameObject mark;
    private GameObject paint = null;
    private void Awake()
    {

        UpdateMaterial();

    }
    private void OnCollisionEnter(Collision other)
    {
        if (!other.collider.TryGetComponent<Player>(out Player player)) return;

        Vector3 normal = -other.contacts[0].normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.up);
        if (dot <= 0.5) return;

        if (isGood)
            player.Bounce();
        else
        {
            if (!player.rage)
                player.Die();
            else
            {
                player.disableRage();
                player.Bounce();
            }
        }
        if (transform.childCount < 1)
        {
            paint = Instantiate(mark,
            new Vector3(other.contacts[other.contactCount - 1].point.x, other.contacts[0].point.y + 0.5f, other.contacts[0].point.z),
            Quaternion.identity, this.transform);
        }
        else
        {
            if (paint != null)
            {
                var position = paint.transform.position;
                Destroy(paint);
                paint = Instantiate(mark,
            position,
            Quaternion.identity, this.transform);
            }
            else
            {
                paint = Instantiate(mark,
            new Vector3(other.contacts[other.contactCount - 1].point.x, other.contacts[0].point.y + 0.5f, other.contacts[0].point.z),
            Quaternion.identity, this.transform);
            }

        }
    }

    private void OnValidate()
    {
        UpdateMaterial();

    }
    private void UpdateMaterial()
    {
        Renderer sectorRenderer = GetComponent<Renderer>();
        sectorRenderer.sharedMaterial = isGood ? GodMaterial : BadMaterial;
    }
}
