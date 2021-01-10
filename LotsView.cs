using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeons
{
    class LotsView : IObserver
    {
        private LotsList _lotsList;

        public LotsView(LotsList obs)
        {
            _lotsList = obs;
            _lotsList.RegisterObserver(this);
        }

        public void Update(object ob)
        {
            if (ob is LotsList player)
            {
                foreach (var lot in _lotsList)
                {
                    Console.WriteLine(lot.Name);
                }
            }
        }

        public void Dispose()
        {
            _lotsList.RemoveObserver(this);
            _lotsList = null;
        }
    }
}
