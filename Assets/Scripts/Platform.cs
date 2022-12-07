using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private AudioSource platformBreak;
    private List<GameObject> Sectors = new List<GameObject>();
    private ParticleSystem ExploseParticle;

    private void Awake()
    {
        ExploseParticle = transform.Find("Explose_particle").GetComponent<ParticleSystem>();
        ExploseParticle.Stop();
        if (this.tag != "Finish")
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Sectors.Add(transform.GetChild(i).gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            player.currentPlatform = this;
            if (player.rage)
            {
                player.AddPoints(Random.Range(20, 40));
                OnTriggerExit(other);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            foreach (var sector in Sectors)
            {
                if (sector.tag == "Sector")
                {
                    var rb = sector.GetComponent<Rigidbody>();
                    rb.isKinematic = false;
                    rb.AddRelativeForce(new Vector3(4, 2, 10), ForceMode.Impulse);
                    StartCoroutine(DeleteSector(sector));
                }
            }
            if (player.rage)
                player.AddPoints(Random.Range(20, 30));
            else
                player.AddPoints(Random.Range(2, 10));
            platformBreak.Play();
            ExploseParticle.Play();
        }
    }
    IEnumerator DeleteSector(GameObject sector)
    {
        yield return new WaitForSeconds(1);
        DestroyImmediate(sector);
    }
}
