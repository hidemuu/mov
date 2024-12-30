using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models
{
	public interface IAnalizeContent
	{
		string Category { get; }

		string Label { get; }
	}
}
