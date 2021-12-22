﻿using ECMABasic.Core;
using ECMABasic.Core.Statements;
using System;

namespace ECMABasic55
{
	class ConsoleEnvironment : EnvironmentBase
	{
		public override int TerminalRow
		{
			get
			{
				return Console.CursorTop;
			}
			set
			{
				Console.CursorTop = value;
			}
		}

		public override int TerminalColumn
		{
			get
			{
				return Console.CursorLeft;
			}
			set
			{
				Console.CursorLeft = value;
			}
		}

		public override void PrintLine(string text)
		{
			Print(text);
			Console.WriteLine();
		}

		public override void Print(string text)
		{
			Console.Write(text);
		}

		public override void ReportError(string message)
		{
			PrintLine(string.Empty);
			PrintLine(message);
		}

		public override void CheckForStopRequest()
		{
			if (Console.KeyAvailable)
			{
				var key = Console.ReadKey(true);
				if (key.Key == ConsoleKey.Escape)
				{
					new StopStatement().Execute(this);
				}
			}
		}
	}
}
