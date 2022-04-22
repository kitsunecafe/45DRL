using UnityEngine;

namespace JuniperJackal.Entity
{
	public class MoveAction : EntityAction
	{
		[SerializeField] private float moveSpeed = 5f;
		[SerializeField] private new Collider2D collider;
		protected Vector3Int nextPosition = default;
		private float minSqrDistance = 0.05f;
		private Vector3 offset = Vector3.zero;

#if UNITY_EDITOR
		private void Reset()
		{
			TryGetComponent(out collider);
		}
#endif

		private void Start()
		{
			nextPosition = Vector3Int.RoundToInt(transform.position);
			this.enabled = false;
		}

		public override bool WantsToExecute() => entity.Waiting == false && (entity.NextHit.collider == null || entity.NextHit.collider.isTrigger);
		public override void Execute()
		{
			this.enabled = true;
			var currentPosition = Vector3Int.RoundToInt(transform.position);
			nextPosition = currentPosition + (Vector3Int)entity.Direction;
			offset = collider.offset;
			collider.offset = entity.Direction;
		}

		private void FixedUpdate()
		{
			var dtSpeed = moveSpeed * Time.fixedDeltaTime;
			transform.position = Vector3.MoveTowards(transform.position, nextPosition, dtSpeed);
			collider.offset = Vector3.MoveTowards(collider.offset, offset, dtSpeed);

			if (SqrDistance(transform.position, nextPosition) <= minSqrDistance)
			{
				transform.position = (Vector3Int)nextPosition;
				collider.offset = offset;
				this.enabled = false;
				entity.FinishTurn();
			}
		}

		private static float SqrDistance(Vector3 a, Vector3 b) => (a - b).sqrMagnitude;
	}
}
