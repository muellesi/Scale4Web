using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scale4Web.Util
{
    public class RangeObservableCollection<T> : ObservableCollection<T>
    {
        private bool _suppressEvents = false;

        public void DetachEvents()
        {
            _suppressEvents = true;
        }

        public void ReattachEvents()
        {
            _suppressEvents = false;
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!_suppressEvents)
                base.OnCollectionChanged(e);
        }


        public void AddRange(IEnumerable<T> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            _suppressEvents = true;

            foreach (var item in items)
            {
                Add(item);
            }

            _suppressEvents = false;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
