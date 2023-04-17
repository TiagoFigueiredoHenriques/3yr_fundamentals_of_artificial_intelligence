using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class LightDetectorLinearScript : LightDetectorScript {

	public override float GetOutput()
	{
		if (ApplyLimits && (output < MinX || output > MaxX))
		{
			output = 0.0f;
		}

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
