using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class XUILineRenderer : Graphic
{
    public List<Vector2> points; // List of points to connect
    public float thickness = 5f; // Thickness of the line

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        if (points == null || points.Count < 2)
        {
            return; // Need at least two points to draw a line
        }

        // Loop through each pair of points and draw a line between them
        for (int i = 0; i < points.Count - 1; i++)
        {
            Vector2 start = points[i];
            Vector2 end = points[i + 1];
            AddLineSegment(vh, start, end, thickness);
        }
    }

    private void AddLineSegment(VertexHelper vh, Vector2 start, Vector2 end, float thickness)
    {
        // Calculate the perpendicular direction for thickness
        Vector2 direction = (end - start).normalized;
        Vector2 perpendicular = new Vector2(-direction.y, direction.x) * (thickness / 2);

        // Define the four vertices for the line segment
        UIVertex v0 = UIVertex.simpleVert;
        UIVertex v1 = UIVertex.simpleVert;
        UIVertex v2 = UIVertex.simpleVert;
        UIVertex v3 = UIVertex.simpleVert;

        v0.color = color;
        v1.color = color;
        v2.color = color;
        v3.color = color;

        // Offset the start and end points by the perpendicular direction to create a rectangle
        v0.position = start - perpendicular;
        v1.position = start + perpendicular;
        v2.position = end + perpendicular;
        v3.position = end - perpendicular;

        // Add the vertices to the VertexHelper
        int index = vh.currentVertCount;
        vh.AddVert(v0);
        vh.AddVert(v1);
        vh.AddVert(v2);
        vh.AddVert(v3);

        // Add two triangles to form the rectangle
        vh.AddTriangle(index, index + 1, index + 2);
        vh.AddTriangle(index + 2, index + 3, index);
    }
}
