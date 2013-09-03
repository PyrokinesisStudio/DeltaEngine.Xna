﻿using System;
using DeltaEngine.Commands;
using DeltaEngine.Extensions;

namespace DeltaEngine.Input
{
	/// <summary>
	/// Tracks mouse movement with a mouse button in a prescribed state.
	/// </summary>
	public class MousePositionTrigger : PositionTrigger
	{
		public MousePositionTrigger(MouseButton button = MouseButton.Left, State state = State.Pressing)
		{
			Button = button;
			State = state;
			Start<Mouse>();
		}

		public MouseButton Button { get; private set; }
		public State State { get; private set; }

		public MousePositionTrigger(string buttonAndState)
		{
			var parameters = buttonAndState.SplitAndTrim(new[] { ' ' });
			if (parameters.Length == 0)
				throw new CannotCreateMousePositionTriggerWithoutKey();
			Button = parameters[0].Convert<MouseButton>();
			State = parameters.Length > 1 ? parameters[1].Convert<State>() : State.Pressing;
			Start<Mouse>();
		}

		public class CannotCreateMousePositionTriggerWithoutKey : Exception {}
	}
}