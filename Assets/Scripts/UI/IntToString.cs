using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JuniperJackal.UI
{
	public class IntToString : MonoBehaviour
	{
    [SerializeField] private UnityEvent<string> Converted;

    public void Convert(int value) => Converted?.Invoke(value.ToString());
	}
}