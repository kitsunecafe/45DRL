using System.Collections.Generic;
using System.Linq;
using JuniperJackal.Extensions;
using UnityAtoms.BaseAtoms;
using UnityAtoms.Tags;
using UnityEngine;
using UnityEngine.Events;

namespace JuniperJackal.Entity
{
	public class WaitAction : EntityAction, IRecoverySource
	{
		[SerializeField] private float enemyFreeRadius = 7f;
		[SerializeField] private int healthRestored = 10;
		[SerializeField] private List<StringConstant> blockingTags;
		[SerializeField] private UnityEvent waited;
		[SerializeField] private UnityEvent waitCancelled;

		private void Start()
		{
			this.enabled = false;
		}

		public override bool WantsToExecute() => entity.Waiting;
		public override void Execute()
		{
			if (IsEnemyNearby())
			{
				waitCancelled?.Invoke();
				entity.enabled = true;
				return;
			}

			var recoveryHandler = entity.gameObject.GetRecoveryHandler();

			if (recoveryHandler != null)
			{
				recoveryHandler.Apply(this, healthRestored);
			}

			entity.Waiting = false;
			waited?.Invoke();
			entity.FinishTurn();
		}

		private bool IsEnemyNearby()
		{
			return Physics2D.OverlapCircleAll(transform.position, enemyFreeRadius)
				.Any(c2d => c2d.gameObject.HasAnyTag(blockingTags));
		}
	}
}
