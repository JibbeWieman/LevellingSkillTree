//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class UIGridRenderer : Graphic
//{
//    public float thickness = 10f;
//    protected override void OnPopulateMesh(VertexHelper vh)
//    {
//        vh.Clear();

//        float width = rectTransform.rect.width;
//        float height = rectTransform.rect.height;

//        UIVertex vertex = UIVertex.simpleVert;
//        vertex.color = color;

//        vertex.position = new Vector3(0,0);
//        vh.AddVert(vertex);

//        vertex.position = new Vector3(0, height);
//        vh.AddVert(vertex);

//        vertex.position = new Vector3(width, height);
//        vh.AddVert(vertex);

//        vertex.position = new Vector3(width, 0);
//        vh.AddVert(vertex);

//        //vh.AddTriangle(0, 1, 2);
//        //vh.AddTriangle(2, 3, 0);

//        float widthSqr = thickness * thickness;
//        float distanceSqr = widthSqr / 2f;
//        float distance = Mathf.Sqrt(distanceSqr);

//        vertex.position = new Vector3(distance, height - distance);
//        vh.AddVert(vertex);

//        vertex.position = new Vector3(width - distance, height - distance);
//        vh.AddVert(vertex);

//        vertex.position = new Vector3(width - distance, distance);
//        vh.AddVert(vertex);

//        //Left Edge
//        vh.AddTriangle(0, 1, 5);
//        vh.AddTriangle(5, 4, 0);

//        //Top Edge
//        vh.AddTriangle(1, 2, 6);
//        vh.AddTriangle(6, 5, 1);

//        //Right Edge
//        vh.AddTriangle(2, 3, 7);
//        vh.AddTriangle(7, 6, 2);

//        //Bottom Edge
//        vh.AddTriangle(3, 0, 4);
//        vh.AddTriangle(4, 7, 3);

//    }


//}
