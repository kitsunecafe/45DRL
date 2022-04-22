using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace JuniperJackal
{
	public class AnnounceCreation : MonoBehaviour
	{
		[SerializeField] private GameObjectEvent created;
		void Start()
		{
			created?.Raise(gameObject);
		}
	}
}