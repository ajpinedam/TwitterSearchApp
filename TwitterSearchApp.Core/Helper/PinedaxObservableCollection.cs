using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace TwitterSearchApp.Core
{
    public class PinedaxObservableCollection<T> : ObservableCollection<T>
    {

        /// <summary>
        /// Adds a range of items to the collection.
        /// The CollectionChanged event will be fired only once.
        /// </summary>
        /// <param name="items">Items.</param>
        public void AddRange (IEnumerable<T> items)
        {
            if (items == null)
                return;

            foreach (var item in items)
            {
                Items.Add (item);
            }

            OnPropertyChanged (new System.ComponentModel.PropertyChangedEventArgs ("Count"));
            OnPropertyChanged (new System.ComponentModel.PropertyChangedEventArgs ("Item[]"));
            OnCollectionChanged (new NotifyCollectionChangedEventArgs (NotifyCollectionChangedAction.Reset));
        }

        /// <summary>
        /// Reset the collection with the specified items.
        /// The CollectionChanged event will be fired only once.
        /// </summary>
        /// <param name="items">Items.</param>
        public void Reset (IEnumerable<T> items)
        {
            Items.Clear ();

            AddRange (items);
        }
    }
}
