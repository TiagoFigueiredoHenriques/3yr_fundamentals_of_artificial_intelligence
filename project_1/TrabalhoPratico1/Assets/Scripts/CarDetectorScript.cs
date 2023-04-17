using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class CarDetectorScript : MonoBehaviour {

	public float angle = 360;
	public bool ApplyThresholds, ApplyLimits;
	public float MinX, MaxX, MinY, MaxY;
	private bool useAngle = true;

	public float output;
	public int numObjects;

	void Start()
	{
		output = 0;
		numObjects = 0;

		if (angle > 360)
		{
			useAngle = false;
		}
	}

	void Update()
	{
		GameObject[] cars = null;
		GameObject closestCar = null;

		output = 0.0f;

		if (useAngle)
		{
			cars = GetVisibleCars();
		}
		else
		{
			cars = GetAllCars();
		}

		closestCar = GetClosestCar(cars);

		if (closestCar != null )
		{
			float r = Vector3.Distance(this.transform.position, closestCar.transform.position);
			output = 1.0f / (r + 1);
            //Debug.DrawLine(transform.position, closestCar.transform.position, Color.red);
        }
		else
		{
			output = 0.0f;
		}

		numObjects = cars.Length;
	}

	public virtual float GetOutput() { throw new NotImplementedException(); }

	// Returns all "CarToFollow" tagged objects. The sensor angle is not taken into account.
	GameObject[] GetAllCars()
	{
		return GameObject.FindGameObjectsWithTag("CarToFollow");
	}

    // Returns all "CarToFollow" tagged objects that are within the view angle of the Sensor. 
    // Only considers the angle over the y axis. Does not consider objects blocking the view.
    GameObject[] GetVisibleCars()
	{
		ArrayList visibleCars = new ArrayList();
		float halfAngle = angle / 2.0f;

		GameObject[] cars = GameObject.FindGameObjectsWithTag("CarToFollow");

		foreach (GameObject car in cars)
		{
			Vector3 toVector = (car.transform.position - transform.position);
			Vector3 forward = transform.forward;
			toVector.y = 0;
			forward.y = 0;
			float angleToTarget = Vector3.Angle(forward, toVector);

			if (angleToTarget <= halfAngle)
			{
				visibleCars.Add(car);
			}
		}

		return (GameObject[])visibleCars.ToArray(typeof(GameObject));

	}

	// Returns the closest car in the array
	GameObject GetClosestCar(GameObject[] cars)
	{
		GameObject closestCar = null;
		float distance = 0.0f;

		foreach (GameObject car in cars)
		{
			if (closestCar is null)
			{
				closestCar = car;
				distance = Vector3.Distance(this.transform.position, car.transform.position);
			}
			else if (Vector3.Distance(this.transform.position, car.transform.position) < distance)
			{
				closestCar = car;
				distance = Vector3.Distance(this.transform.position, car.transform.position);
			}
		}

		return closestCar;
	}

}
