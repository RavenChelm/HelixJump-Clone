using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void MenuOn(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void MenuOff(GameObject obj)
    {
        obj.SetActive(false);
    }
}
