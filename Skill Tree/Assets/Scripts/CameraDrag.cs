using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;
    private Vector3 lastPosition = Vector3.zero;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;//block so that the movement is only done when the input is pressed

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin).normalized;//movement direction
        Vector3 move = new(-pos.x * dragSpeed, -pos.y * dragSpeed, 0);

        if (lastPosition != Input.mousePosition)
        {
            transform.Translate(move, Space.World);
            transform.position = new(Mathf.Clamp(transform.position.x, -100, 100), Mathf.Clamp(transform.position.y, -100, 100), transform.position.z);
            lastPosition = Input.mousePosition;
        }
        else
            dragOrigin = lastPosition;
    }
}