using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerate : MonoBehaviour
{
    [SerializeField] private GameObject[] PlatformPrefabs;
    [SerializeField] private GameObject FirstPlatformPrefab;
    [SerializeField] private int minPlatform;
    [SerializeField] private int maxPlatform;
    [SerializeField] private float distanceBetweenPlatrorm;
    [SerializeField] private Transform CylindreRoot;
    [SerializeField] private Transform finishPlatform;
    [SerializeField] private float extraCilynderScale;
    void Awake()
    {
        //?Спорный момент?
        int platrformCount = Random.Range(minPlatform, maxPlatform);
        for (int i = 0; i < platrformCount; i++)
        {
            int prefabIndex = Random.Range(0, PlatformPrefabs.Length);
            GameObject original = i == 0 ? FirstPlatformPrefab : PlatformPrefabs[prefabIndex];
            GameObject platform = Instantiate(original, transform);
            platform.transform.localPosition = CalculetePlatformPosition(i);
            if (i > 0)
                platform.transform.localRotation = Quaternion.Euler(0, Random.Range(0, 360f), 0);
        }
        finishPlatform.transform.localPosition = CalculetePlatformPosition(platrformCount);
        CylindreRoot.localScale = new Vector3(1, platrformCount * distanceBetweenPlatrorm + extraCilynderScale, 1);
    }

    private Vector3 CalculetePlatformPosition(int i)
    {
        return new Vector3(0, -distanceBetweenPlatrorm * i, 0);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
