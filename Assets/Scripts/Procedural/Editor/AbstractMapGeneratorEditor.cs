using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace JuniperJackal.Procedural
{
	[CustomEditor(typeof(AbstractMapGenerator), true)]
	public class AbstractMapGeneratorEditor : Editor
	{
		AbstractMapGenerator generator;

		private void Awake()
		{
			generator = (AbstractMapGenerator)target;
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			if (GUILayout.Button("Generate"))
			{
				generator.Generate();
			}
		}
	}
}