using Cinemachine;
using UnityEngine;

namespace JuniperJackal
{
	public class AssignCameraFollow : MonoBehaviour
	{
		[SerializeField] private CinemachineVirtualCamera vcam;

		public void Assign(GameObject target)
		{
			if (target != null)
			{
				vcam.Follow = target.transform;
			}
		}
	}
}