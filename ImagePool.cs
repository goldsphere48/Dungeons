using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeons
{
	static class ImagePool
	{
		private static Dictionary<string, Image> _data;

		static ImagePool()
		{
			_data = new Dictionary<string, Image>();
			_data.Add("floor", new Image("Path to floor"));
			_data.Add("chest", new Image("Path to chest"));
			_data.Add("trap", new Image("Path to trap"));			
		}

		public static Image GetImage(string image) => _data[image];
	}
}
