using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace JuniperJackal.Entity
{
	public class Name : MonoBehaviour
	{
		[SerializeField] private StringReference value;
		public string Value => value.Value;
	}
}
