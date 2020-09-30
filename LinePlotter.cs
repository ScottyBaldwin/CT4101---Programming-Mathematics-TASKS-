using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LinePlotter : MonoBehaviour {

    private List<Vector3> Points;

    public float x1 = 0f;

    public float y1 = 0f;

    public float m = 1f;

    public float c = 0f;

    private float calcualteY(float y1, float x, float x1, float m, float c) {
        return m * (x - x1) + c + y1;
    }

    void Start() {
        Points = new List<Vector3>();

        float x = -10f;

        // Create a number of points to go on our line
        for (float xPos = x; xPos < 10f; xPos += 0.2f) {
            Points.Add(new Vector3(xPos, calcualteY(y1, xPos, x1, m, c), 0f));
        }
    }

    private void OnDrawGizmos() {

        // If we have some points on our list
        if (Points != null) {

            //Set gizmo Colour
            Gizmos.color = Color.blue;
            //For each point in the list draw a line from it to the next point in the list
            for (int i = 0; i < Points.Count - 1; ++i) {
                Gizmos.DrawLine(Points[i], Points[i + 1]);
            }
        }
    }

    void OnValidate() {
        Points.Clear();
        float x = -10f;

        // Create a number of points to go on our line
        for (float xPos = x; xPos < 10f; xPos += 0.2f) {
            Points.Add(new Vector3(xPos, calcualteY(y1, xPos, x1, m, c), 0f));
        }
        Debug.Log("Re-populating gizmo positions");
    }
  
}

