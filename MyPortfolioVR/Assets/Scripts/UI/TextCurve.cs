using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextCurve : Text
{
    public float diameter = 200;
    protected override void OnPopulateMesh(VertexHelper vh)
    {
        base.OnPopulateMesh(vh);
        for (int i = 0; i < vh.currentVertCount; i++)
        {
            UIVertex vert = UIVertex.simpleVert;
            vh.PopulateUIVertex(ref vert, i);
            Vector3 position = vert.position;

            //manipulate position
            float ratio = (float)position.x / preferredWidth;
            float mappedRatio = ratio * Mathf.PI * 2 / 4;
            float cos = Mathf.Cos(mappedRatio);
            float sin = Mathf.Sin(mappedRatio);

            position.x = -cos * diameter;
            position.z = sin * diameter;

            vert.position = position;
            vh.SetUIVertex(vert, i);
        }
    }
 }
