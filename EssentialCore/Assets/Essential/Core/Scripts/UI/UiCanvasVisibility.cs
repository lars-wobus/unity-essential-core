using UnityEngine;

namespace Essential.Core.Scripts.UI
{
	public class UiCanvasVisibility : MonoBehaviour
	{
		[SerializeField] private Canvas _targetCanvas;
		[SerializeField] private bool _isVisible = true;

		public bool IsVisible
		{
			get{
				return _isVisible;
			}
			set
			{
				if (_isVisible == value)
				{
					return;
				}

				_isVisible = value;

				OnValueChanged();
			}
		}

		private void Start ()
		{
			OnValueChanged();
		}

		private void OnValueChanged()
		{
			_targetCanvas.enabled = IsVisible;
		}
	}
}
