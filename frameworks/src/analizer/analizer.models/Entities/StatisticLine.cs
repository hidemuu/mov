﻿using Mov.Core.Valuables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Entities
{
	public class StatisticLine : AnalizeContent
	{
		public IEnumerable<NumericalValue> Values { get; }
		
		public NumericalValue Max { get; }

		public NumericalValue Min { get; }

		public NumericalValue Ave { get; }

	}
}