using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public Vector3 NorthDirection;
    public Transform Player;
    public Quaternion GoalDirection;

    public RectTransform NorthLayer;
    public RectTransform GoalLayer;

    public Transform goalLocation;
    
    // Update is called once per frame
    void Update()
    {
        ChangeNorthDirection();
        ChangeGoalDirection();
    }

    public void ChangeNorthDirection()
    {
        NorthDirection.z = Player.eulerAngles.y;
        NorthLayer.localEulerAngles = NorthDirection;
    }

    public void ChangeGoalDirection()
    {
        Vector3 dir = transform.position = goalLocation.position;

        GoalDirection = Quaternion.LookRotation(dir);

        GoalDirection.z = GoalDirection.y;
        GoalDirection.x = 0;
        GoalDirection.y = 0;

        GoalLayer.localRotation = GoalDirection * Quaternion.Euler(NorthDirection);
    }
}
