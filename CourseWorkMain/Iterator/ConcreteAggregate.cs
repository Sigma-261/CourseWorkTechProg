using MathNet.Numerics.LinearAlgebra.Solvers;
using System.Collections;
using CourseWorkMain.Models;

namespace CourseWorkMain.Iterator
{
    public class BusinessTripAggregate:Aggregate
    {
        private List<BusinessTrip> _items = new List<BusinessTrip>();

        public override Iterator CreateIterator()
        {
            return new BusinessTripIterator(this);
        }

        // Gets item count
        public int Count
        {
            get { return _items.Count; }
        }

        // Indexer
        public object this[int index]
        {
            get { return _items[index]; }
            set { _items[index] = value as BusinessTrip; }
        }

        public void FillItems(List<BusinessTrip> list)
        {
            _items = new List<BusinessTrip>(list);
        }
    }
}
