﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMABasic.Core
{
	class ProgramEndException : RuntimeException
	{
		public ProgramEndException()
			: base("You have reached the END.")
		{
		}
	}
}
