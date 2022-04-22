using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace JuniperJackal.Procedural
{
	public class NavMeshBake : MonoBehaviour
	{
		[SerializeField] private NavMeshSurface2d surface;

		public void Bake()
		{
      StartCoroutine(WaitAndBake());
		}

    private IEnumerator WaitAndBake() {
      yield return new WaitForEndOfFrame();
      surface.BuildNavMeshAsync();
    }
	}
}