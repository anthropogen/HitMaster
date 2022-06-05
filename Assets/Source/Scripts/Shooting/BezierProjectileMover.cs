using System;
using UnityEngine;

public class BezierProjectileMover : ProjectileMover
{
    [SerializeField, Range(0, 1)] private float height;
    [SerializeField, Range(0, 1)] private float depth;
    private const int stepsCount = 10;
    private Vector3 startPos;
    private Vector3 middlePos;
    private Vector3 endPos;
    private Vector3 targetPos;
    private int currentStep = 1;
    protected override void FixedUpdateMovement()
    {
        if (transform.position == targetPos)
        {
            if (transform.position == endPos)
            {
                PathEndedInvoke();
            }
            currentStep = Mathf.Min(currentStep + 1, stepsCount);
            targetPos = SetTargetPos();
        }
        var newPos = Vector3.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }

    protected override void ResetMover()
    {
        currentStep = 1;
    }

    public override void Init(Vector3 point)
    {
        endPos = point;
        startPos = transform.position;
        middlePos = GetMiddlePoint(startPos, endPos, depth, height);
        targetPos = SetTargetPos();
    }

    private Vector3 SetTargetPos()
    {
        return GetPosition(startPos, middlePos, endPos, (float)currentStep / (float)stepsCount);
    }

    private Vector3 GetMiddlePoint(Vector3 p0, Vector3 p2, float depth, float height)
    {
        var res = Vector3.Lerp(p0, p2, depth);
        var dist = (p0 - p2).magnitude;
        res.y = Mathf.Lerp(0, dist, height);
        return res;
    }

    private Vector3 GetPosition(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        return Vector3.Lerp(Vector3.Lerp(p0, p1, t), Vector3.Lerp(p1, p2, t), t);
    }

    private void OnDrawGizmos()
    {
        var p0 = Application.isPlaying ? startPos : transform.position;
        var p2 = Application.isPlaying ? endPos : transform.position + (Vector3.forward * 3);
        var p1 = GetMiddlePoint(p0, p2, depth, height);
        Gizmos.color = Color.yellow;
        Vector3 start = GetPosition(p0, p1, p2, 0);
        for (int i = 0; i <= stepsCount; i++)
        {
            Vector3 end = GetPosition(p0, p1, p2, i / (float)stepsCount);
            Gizmos.DrawLine(start, end);
            start = end;
        }
    }
}
