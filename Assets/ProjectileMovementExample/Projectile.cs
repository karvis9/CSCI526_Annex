using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _InitialVelocity;
    [SerializeField] float _Angle;
    //[SerializeField] LineRenderer _Line;
    //[SerializeField] float _Step;

    private void Update()
    {
        float angle = _Angle * Mathf.Deg2Rad;
        //DrawPath(_InitialVelocity, angle, _Step);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            StartCoroutine(Coroutine_Movement(_InitialVelocity, angle));
        }
    }
    //private void DrawPath(float v0, float angle, float step)
    //{
    //    step = Mathf.Max(0.01f, step);
    //    float totalTime = 10;
    //    _Line.positionCount = (int)(totalTime / step) + 2;
    //    int count = 0;
    //    for (float i = 0; i < totalTime; i += step)
    //    {
    //        float x = v0 * i * Mathf.Cos(angle);

    //        float y = v0 * i * Mathf.Sin(angle) - (1f / 2f) * -Physics.gravity.y * Mathf.Pow(i, 2);
    //        _Line.SetPosition(count, new Vector3(x, y, 0));
    //        count++;
    //    }
    //    float xFinal = v0 * totalTime * Mathf.Cos(angle);

    //    float yFinal = v0 * totalTime * Mathf.Sin(angle) - (1f / 2f) * -Physics.gravity.y * Mathf.Pow(totalTime, 2);
    //    _Line.SetPosition(count, new Vector3(xFinal, yFinal, 0));

    //}
    IEnumerator Coroutine_Movement(float v0, float angle)
    {
        float t = 0;
        while( t< 100 )
        {
            float x = v0 * t * Mathf.Cos(angle);

            float y = v0 * t * Mathf.Sin(angle) - (1f/2f) * -Physics.gravity.y * Mathf.Pow(t,2);
            transform.position = new Vector3(x, y, 0);
            
            t += Time.deltaTime;
            yield return null;
        }
    }
}
