using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeons
{
	class Auction
	{
		private LotsList _lostList;
		private LotsView _lotsView;

		public Auction() 
		{
			_lostList = new LotsList();
			_lotsView = new LotsView(_lostList);
		}

		public void AddLot(Lot lot)
		{
			_lostList.AddLot(lot);
		}
	}
}
