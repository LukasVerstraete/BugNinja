using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RawMouseDriver;
using RawInputSharp;

public class MouseHandler : MonoBehaviour {

    private RawMouse[] mice;
    private Vector2[] positions;
    private RawMouseDriver.RawMouseDriver mouseDriver;
    private const int NUM_MICE = 2;
    private int miceAlreadyAssigned = 0;

    void Start()
    {
        mouseDriver = new RawMouseDriver.RawMouseDriver();
        mice = new RawMouse[NUM_MICE];
        positions = new Vector2[NUM_MICE];
    }

    void Update()
    {
        // Loop through all the connected mice
        for (int i = 0; i < mice.Length; i++)
        {
            try
            {
                mouseDriver.GetMouse(i, ref mice[i]);
                // Cumulative movement
                positions[i] += new Vector2(mice[i].XDelta, -mice[i].YDelta);
            }
            catch { }
        }
    }

    public int GetMouse()
    {
        if (miceAlreadyAssigned != NUM_MICE)
        {

        }
        return -1;
    }

    public Vector2 GetMousePosition(int mouse)
    {
        if(mouse > 0 && mouse <= NUM_MICE)
            return positions[mouse];
        return new Vector2(0,0);
    }
}
