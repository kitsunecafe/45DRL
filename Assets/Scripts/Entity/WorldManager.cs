using JuniperJackal.Entity;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace JuniperJackal
{
	public class WorldManager : MonoBehaviour
	{
		[SerializeField] private GameObject player;
		[SerializeField] private VoidEvent changeTurnEvent;
		[SerializeField] private StringConstant worldTurn;
		[SerializeField] private GameObjectValueList entities;

		public void HandleTurnChange(string turn)
		{
			if (turn == worldTurn.Value)
			{
				var target = (Vector2Int)Vector3Int.RoundToInt(player.transform.position);
				foreach (var entity in entities)
				{
					entity.GetComponent<EntityAI>().Act(target);
				}

	 			changeTurnEvent?.Raise();
			}
		}

		public void AssignPlayer(GameObject player)
		{
			this.player = player;
		}
	}
}
