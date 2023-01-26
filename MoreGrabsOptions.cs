using BepInEx.Logging;
using Menu.Remix.MixedUI;
using Menu.Remix.MixedUI.ValueTypes;
using UnityEngine;

namespace MoreGrabs
{
	public sealed class MoreGrabsOptions : OptionInterface
	{
		public MoreGrabsOptions(MoreGrabsMod mod, ManualLogSource log)
		{
			this._mod = mod;
			this._log = log;
			MoreGrabsOptions.allOneHand = this.config.Bind<bool>("windowSizeOverride", false);
		}

		public override void Initialize()
		{
			base.Initialize();
			OpTab opTab = new OpTab(this, "Options");
			this.Tabs = new OpTab[]
			{
				opTab
			};
			this._checkBoxAllOneHand = new OpCheckBox(allOneHand, new Vector2(16f, 450f));
			opTab.AddItems(new UIelement[]
			{
				this._checkBoxAllOneHand
			});
			opTab.AddItems(new UIelement[]
			{
				new OpLabel(new Vector2(48f, 450f), new Vector2(200f, 24f), "All grabs with one hand", FLabelAlignment.Left, false, null)
			});
			this.Update();
		}

		public override void Update()
		{
			base.Update();
			if (this._checkBoxAllOneHand == null)
			{
				return;
			}
			bool valueBool = this._checkBoxAllOneHand.GetValueBool();
		}

		private readonly MoreGrabsMod _mod;

		private readonly ManualLogSource _log;

		public static Configurable<bool> allOneHand;

		private OpCheckBox _checkBoxAllOneHand;
	}
}
