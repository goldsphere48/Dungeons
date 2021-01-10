using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Dungeons
{
    interface IObserver
    {
        void Update(Object ob);
    }

    interface IObservable
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    class LotsList : IObservable, IEnumerable<Lot>
    {
        public List<Lot> Lots { get; private set; }
        private List<IObserver> _observers;

        public LotsList()
        {
            _observers = new List<IObserver>();
            Lots = new List<Lot>();
        }

        public void RegisterObserver(IObserver o)
        {
            _observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            _observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in _observers)
            {
                o.Update(this);
            }
        }

        public void AddLot(Lot lot)
        {
            Lots.Add(lot);
            NotifyObservers();
        }

        public IEnumerator<Lot> GetEnumerator()
        {
            return Lots.GetEnumerator();
        }

		IEnumerator IEnumerable.GetEnumerator()
		{
            return GetEnumerator();
		}
	}
}
