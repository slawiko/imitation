﻿using ImitationLib.Utils;

namespace ImitationLib.Elements.Core
{
	public abstract class Generator : Element, IExitable
	{
		public virtual Transact Exit(int time)
		{
			var transact = this.Transact;
			transact.LifeTime = $"{transact} left {this} at {time}";
			this.Transact = null;
			this.ReadyIn = 0;
			return transact;
		}

		public override void Process(int time)
		{
			this.Transact = new Transact();
			this.Transact.LifeTime = $"{this.Transact} is processed in {this} at {time}";
			// TODO: think about it
			var temp = this.Exit(time);
			try
			{
				this.Out(temp, time);
			}
			catch (System.Exception e)
			{
				Logger.Log.Error(e.Message);
			}
		}
	}
}
