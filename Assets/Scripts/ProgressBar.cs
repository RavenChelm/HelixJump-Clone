using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Transform finishPlatform;
    [SerializeField] private Slider slider;
    private Transform playerTrn;
    private float startY;
    private float currentY;
    private float minimalY;
    private float finishY;


    private void Awake()
    {
        playerTrn = player.transform;
        startY = playerTrn.position.y;
        finishY = finishPlatform.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        currentY = playerTrn.position.y;
        if (currentY <= minimalY)
        {
            minimalY = currentY;
        }
        float progress = Mathf.InverseLerp(startY, finishY, minimalY);
        slider.value = progress;
    }
}
