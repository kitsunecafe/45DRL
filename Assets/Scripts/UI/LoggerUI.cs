using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UIElements;

namespace JuniperJackal.UI
{
	public class LoggerUI : MonoBehaviour
	{
		[SerializeField] private UIDocument document;
		[SerializeField] private VisualTreeAsset messageTemplate;
		[SerializeField] private StringValueList messages;

		private ListView listView;

#if UNITY_EDITOR
		private void Reset()
		{
			TryGetComponent(out document);
		}
#endif

		private void Start()
		{

			var root = document.rootVisualElement;
			listView = root.Q<ListView>("message-list");

			listView.itemsSource = messages.List;
			listView.makeItem = () => messageTemplate.CloneTree();
			listView.bindItem = (e, i) => (e as VisualElement).Q<Label>("message-text").text = messages[i];
			listView.selectionType = SelectionType.None;
		}

		public void HandleNewMessage(string message)
		{
			listView.RefreshItems();
			listView.ScrollToItem(-1);
		}
	}
}
