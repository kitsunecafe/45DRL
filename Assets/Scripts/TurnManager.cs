using System;
using System.Collections;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace JuniperJackal
{
	public class TurnManager : MonoBehaviour
	{
		public static TurnManager Instance { get; private set; }

		[SerializeField] private float turnDelay = 0.1f;
		[SerializeField] private float timeUntilSustain = 1f;
		[SerializeField] private float sustainedTurnDelay = 0.025f;
		private float currentTurnDelay => isSustained ? sustainedTurnDelay : turnDelay;
		[SerializeField] private StringConstant[] turnOrder;
		[SerializeField] private int turnIndex = 0;
		public StringConstant CurrentTurn => turnOrder[turnIndex % turnOrder.Length];
		[SerializeField] private StringVariable CurrentTurnVar;

		[SerializeField] private bool changeTurns = false;

		private bool isSustained = false;
		private IEnumerator sustainDelay;

		private void LateUpdate()
		{
			if (changeTurns)
			{
				changeTurns = false;
				StartCoroutine(SetTurnAfterDelay(currentTurnDelay));
			}
		}

		private IEnumerator SetTurnAfterDelay(float duration)
		{
			yield return new WaitForSeconds(duration);
			yield return new WaitForEndOfFrame();
			SetTurn(NextIndex());
		}

		public void NextTurn()
		{
			changeTurns = true;
		}

		private int NextIndex()
		{
			return (turnIndex + 1) % turnOrder.Length;
		}

		private void SetTurn(int index)
		{
			turnIndex = index;
			// TurnChanged?.Raise(CurrentTurn.Value);
			CurrentTurnVar.Value = CurrentTurn.Value;
		}

		private void ResetSustain()
		{
			if (sustainDelay != null)
			{
				StopCoroutine(sustainDelay);
				sustainDelay = null;
			}

			isSustained = false;
		}

		public void StartedMoving(Vector2 direction)
		{
			ResetSustain();
			StartCoroutine(SustainedAfterDelay(timeUntilSustain));
		}

		public void StoppedMoving(Vector2 direction)
		{
			ResetSustain();
		}

		private IEnumerator SustainedAfterDelay(float delay)
		{
			yield return new WaitForSeconds(delay);
			isSustained = true;
		}
	}
}
