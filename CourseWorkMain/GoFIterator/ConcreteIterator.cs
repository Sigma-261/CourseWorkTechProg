﻿using static CourseWorkMain.GoFIterator.BusinessTripAggregate;

namespace CourseWorkMain.GoFIterator
{
    public class BusinessTripIterator:Iterator
    {
        private BusinessTripAggregate _aggregate;
        private int _current = 0;

        // Constructor
        public BusinessTripIterator(BusinessTripAggregate aggregate)
        {
            _aggregate = aggregate;
        }



            // Gets first iteration item
            public override object First()
        {
            return _aggregate[0];
        }

        // Gets next iteration item
        public override object Next()
        {
            object ret = null;
            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }

            return ret;
        }

        // Gets current iteration item
        public override object CurrentItem()
        {
            return _aggregate[_current];
        }

        // Gets whether iterations are complete
        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }
    }

    public class BudgetsIterator : Iterator
    {
        private BudgetsAggregate _aggregate;
        private int _current = 0;

        // Constructor
        public BudgetsIterator(BudgetsAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        // Gets first iteration item
        public override object First()
        {
            return _aggregate[0];
        }

        // Gets next iteration item
        public override object Next()
        {
            object ret = null;
            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }

            return ret;
        }

        // Gets current iteration item
        public override object CurrentItem()
        {
            return _aggregate[_current];
        }

        // Gets whether iterations are complete
        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }
    }
}
