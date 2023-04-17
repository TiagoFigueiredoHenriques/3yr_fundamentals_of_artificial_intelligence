using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class BlockDetectorLinearScript : BlockDetectorScript
{
     public override float GetOutput()
     {
        if (ApplyLimits)
        {
            if (output < MinX || output > MaxX)
            {
                output = 0;
            }
        }

        if (ApplyThresholds)
        {
            if (output < MinX)
            {
                output = MinX;
            }

            if (output > MaxX)
            {
                output = MaxX;
            }
        }

        return output;
    }
}