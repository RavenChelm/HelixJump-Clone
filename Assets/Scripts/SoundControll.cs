using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundControll : MonoBehaviour
{
    [SerializeField] public AudioSource BackgroundSound;
    void Awake()
    {
        DontDestroyOnLoad(BackgroundSound);
    }
}
