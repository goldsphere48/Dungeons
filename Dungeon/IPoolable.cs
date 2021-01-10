using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeons
{
	public interface IPoolable
	{
		bool IsActive { get; set; }
	}
}
