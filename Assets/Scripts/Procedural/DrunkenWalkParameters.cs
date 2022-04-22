using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuniperJackal.Procedural
{
 [CreateAssetMenu(fileName = "DrunkenWalkParameters", menuName = "Roguelike/DrunkenWalkParameters", order = 0)]
	public class DrunkenWalkParameters : ScriptableObject
	{
		public int Iterations = 10;
		public int WalkLength = 10;
		public bool StartRandomlyEachIteration = true;
	}
}
