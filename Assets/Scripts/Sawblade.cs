using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawblade : MonoBehaviour
{
    [SerializeField]
    private Transform start;
    [SerializeField]
    private Transform end;
    [SerializeField]
    private Transform sawBladeSprite;

    private float positionPercent;
    private int direction = 1;

    // Update is called once per frame
    void Update()
    {
        positionPercent += Time.deltaTime * direction;

        //Vector2 also works fine why did we use vector3 in a 2d tutorial???
        sawBladeSprite.position = Vector3.Lerp(start.position, end.position, positionPercent);
        if (positionPercent >= 1 && direction == 1)
        {
            direction = -1;
        }
        else if (positionPercent <= 0 && direction == -1)
        {
            direction = 1;
        }
    }
}
