using System;
using System.Linq;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace JuniperJackal.Entity
{
	public class EntityController : MonoBehaviour
	{
		[SerializeField] private StringConstant myTurn;
		[SerializeField] private bool endTurnAfterAction = false;
		[SerializeField] private VoidEvent changeTurnEvent;
		[SerializeField] private EntityAction[] actions;
		[SerializeField] private EntityAction defaultAction;
		private Vector2Int direction = default;
		[HideInInspector]
		public Vector2Int Direction
		{
			get => direction;
			set
			{
				if (value != direction)
				{
					direction = Clamp(value, Vector2Int.one * -1, Vector2Int.one);
					actionPerformed = direction != default;
				}
			}
		}
		private bool waiting = false;
		public bool Waiting
		{
			get => waiting;
			set
			{
				if (waiting != value)
				{
					waiting = value;
					actionPerformed = value;
				}
			}
		}

		private bool actionPerformed = false;

		[HideInInspector] public Vector2Int NextTile = default;
		[HideInInspector] public RaycastHit2D NextHit;

#if UNITY_EDITOR
		private void Reset()
		{
			TryGetComponents();
		}
#endif

		private void TryGetComponents()
		{
			actions = GetComponents<EntityAction>();
		}

		private void Awake()
		{
			TryGetComponents();
		}

		private void Update()
		{
			var isMoving = Direction != default;
			if (actionPerformed || isMoving)
			{
				actionPerformed = false;

				if (isMoving)
				{
					Waiting = false;
					NextTile = Vector2Int.RoundToInt(transform.position) + Direction;
					NextHit = Physics2D.Raycast(transform.position, Direction, 1f);
				}
				else
				{
					NextTile = Vector2Int.zero;
					NextHit = new RaycastHit2D();
				}

				ResolveAction();
			}
		}

		private void ResolveAction()
		{
			var firstValidAction = actions.FirstOrDefault(action => action.WantsToExecute());

			if (firstValidAction != null)
			{
				this.enabled = false;
				firstValidAction.Execute();
			}
		}

		public void FinishTurn()
		{
			if (endTurnAfterAction)
			{
				changeTurnEvent?.Raise();
			}
		}

		public void HandleTurnChange(string turn)
		{
			this.enabled = turn == myTurn.Value;
		}

		public void OnMove(Vector2 value)
		{
			Direction = Vector2Int.RoundToInt(value);
		}

		public void OnMove(CallbackContext context)
		{
			OnMove(context.ReadValue<Vector2>());
		}

		public void OnWait()
		{
			Waiting = true;
		}

		private static Vector2Int Clamp(Vector2Int value, Vector2Int min, Vector2Int max)
		{
			return new Vector2Int(
				Math.Clamp(value.x, min.x, max.x),
				Math.Clamp(value.y, min.y, max.y)
			);
		}
	}
}
