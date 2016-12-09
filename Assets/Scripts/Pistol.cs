using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
	[SerializeField]
	private GameObject bullet;

	public GameObject Bullet {
		get {
			return bullet;
		}
		set {
			bullet = value;
		}
	}
}
