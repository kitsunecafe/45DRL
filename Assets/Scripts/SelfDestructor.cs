using UnityEngine;

namespace JuniperJackal
{
	public class SelfDestructor : MonoBehaviour
	{
		public void DestroySelf()
		{
			Destroy(gameObject);
		}
	}
}
