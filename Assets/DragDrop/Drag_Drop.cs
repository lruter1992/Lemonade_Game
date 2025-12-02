using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class DragDrop2D : MonoBehaviour
{
    // The plane the object is currently being dragged on
    Plane dragPlane;

    // The difference between where the mouse is on the drag plane and 
    // where the origin of the object is on the drag plane
    Vector3 offset;

    Camera myMainCamera;

    void Start() {
        myMainCamera = Camera.main;
    }

    void OnMouseDown() {

        dragPlane = new Plane(myMainCamera.transform.forward, transform.position);
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist);
        offset = transform.position - camRay.GetPoint(planeDist);
        
        // 🟢 Visualize ray on click
        Debug.DrawRay(camRay.origin, camRay.direction * 100f, Color.green, 3f);
        Debug.DrawLine(camRay.origin, camRay.GetPoint(planeDist), Color.yellow);
    }

    void OnMouseDrag() {

        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist);
        transform.position = camRay.GetPoint(planeDist) + offset;
        
        // 🔵 Visualize ray while dragging (updates each frame)
        Debug.DrawRay(camRay.origin, camRay.direction * 10f, Color.blue);
    }
}
