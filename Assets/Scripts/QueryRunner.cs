using System.Linq;
using JuniperJackal.Entity;
using UnityEngine;

namespace JuniperJackal
{
	public class QueryRunner : MonoBehaviour
	{
    [SerializeField]
    [RequireInterface(typeof(IItemQuery))]
		private Object query;
    public IItemQuery Query => query as IItemQuery;

		[ContextMenu("Debug Query")]
		public void DebugQuery()
		{
			var results = Query.Execute();
			foreach (var item in results)
			{
				Debug.Log(item);
			}
		}
	}
}