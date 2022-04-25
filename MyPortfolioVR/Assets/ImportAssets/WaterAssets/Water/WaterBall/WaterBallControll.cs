using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBallControll : MonoBehaviour
{
    [SerializeField] Transform _CreationPoint;
    [SerializeField] WaterBall WaterBallPrefab;
    WaterBall waterBall;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                CreateWaterBall();
                ThrowWaterBall(hit.point);
            }
        }
    }
    public bool WaterBallCreated()
    {
        return waterBall != null;
    }
    public void CreateWaterBall()
    {
        waterBall = Instantiate(WaterBallPrefab, _CreationPoint.position, Quaternion.identity);
    }
    public void ThrowWaterBall(Vector3 pos)
    {
        waterBall.Throw(pos);
    }
}
