using UnityEngine;
using UnityEngine.EventSystems;
public class Controll : MonoBehaviour
{
    private Vector3 prevRotate;
    public Transform Level;
    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - prevRotate;
            Level.Rotate(0, delta.x, 0);
        }
        prevRotate = Input.mousePosition;
    }
}
