using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
	public Cloud CloudPrefab;
	public float trajectoryVariance = 15.0f;
	public float spawnRate = 2.0f;
	public float spawnDistance = 15.0f;
	public int spawnAmount = 1;

	private void Start()
	{
		InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
	}

	private void Spawn()
	{
		for (int i = 0; i < this.spawnAmount; i++)
		{
			Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
			Vector3 spawnPoint = this.transform.position + spawnDirection;

			float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
			Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

			Cloud cloud = Instantiate(this.CloudPrefab, spawnPoint, rotation);
			cloud.size = Random.Range(cloud.minSize, cloud.maxSize);
			cloud.SetTrajectory(rotation * -spawnDirection);
		}
	}
}
