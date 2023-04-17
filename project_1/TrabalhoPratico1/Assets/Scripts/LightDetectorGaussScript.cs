using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class LightDetectorGaussScript : LightDetectorScript {

	public float stdDev = 1.0f; 
	public float mean = 0.0f; 
	public float min_y;
	public bool inverse = false;

	public override float GetOutput()
	{
        if (ApplyLimits && (output < MinX || output > MaxX))
        {
            output = 0.0f;
        }

        double a = (1.0f / (stdDev * Math.Sqrt(2f * Math.PI)));
        double e = (-1.0f / 2.0f) * Math.Pow((output - mean) / stdDev, 2.0f);
        output = (float) (a * Math.Pow(Math.E, e));

        if (ApplyThresholds && output < MinY)
        {
            output = MinY;
        }

        if (ApplyThresholds && output > MaxY)
        {
            output = MaxY;
        }

        return output;
	}

}
