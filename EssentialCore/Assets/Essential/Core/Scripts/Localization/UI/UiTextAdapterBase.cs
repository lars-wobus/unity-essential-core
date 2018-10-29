﻿using UnityEngine;

namespace Essential.Core.Localization.UI
{
	public abstract class UiTextAdapterBase : MonoBehaviour, ITextComponent
	{
		[SerializeField] private string _id;

		public string Id => _id;

		public abstract void SetText(string value);
	}
}
