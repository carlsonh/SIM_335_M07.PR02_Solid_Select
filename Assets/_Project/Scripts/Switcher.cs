using System;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
	public List<GameObject> ChangeableObjects;

	private List<IChangeable> _changeableObjects = new List<IChangeable>();

	private void Start()
	{
		foreach (GameObject obj in ChangeableObjects)
		{
			var changeable = obj.GetComponent<IChangeable>();
			_changeableObjects.Add(changeable);
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.N))
		{
			foreach (var changeableObject in _changeableObjects)
			{
				changeableObject.Next();
			}
		}
	}
}

public interface IChangeable
{
	void Next();
}