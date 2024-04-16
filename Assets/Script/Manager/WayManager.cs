using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class WayManager : MonoBehaviour
{
    private static WayManager instance;
    public static WayManager Instance { get { return instance; } }
    
    public Transform J1Base, J2Base, J1LeftTour, J2LeftTour, J1RightTour, J2RightTour, leftPont, rightPont;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    public Transform SetTargetMove(Vector3 position, bool J1)
    {
        if(J1)
        {
            if (position.y < -2.25f)
            {
                if (position.x < 0f)
                    return J1LeftTour;
                else
                    return J1RightTour;
            }
            else if (position.y < 0f)
            {
                if (position.x < 0f)
                    return leftPont;
                else
                    return rightPont;
            }
            else if (position.y < 2.25f)
            {
                if (position.x > 0f)
                    return J2LeftTour;
                else
                    return J2RightTour;
            }
            else
                return J2Base;
        }
        else
        {
            if (position.y > 2.25f)
            {
                if (position.x > 0f)
                    return J2LeftTour;
                else
                    return J2RightTour;
            }
            else if (position.y > 0.1f)
            {
                if (position.x < 0f)
                    return leftPont;
                else
                    return rightPont;
            }
            else if (position.y > - 2.25f)
            {
                if (position.x < 0f)
                    return J1LeftTour;
                else
                    return J1RightTour;
            }
            else
                return J1Base;
        }
    }

}
