using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace CooperativeSystem.UI.Views.Utilities
{
    public class SearchableSortableBindingList<T> : BindingList<T>
    {
        public SearchableSortableBindingList() { }

        public SearchableSortableBindingList(IList<T> list) : base(list) { }

        public Type ItemType
        {
            get { return typeof(T); }
        }

        #region Sorting

        private bool _isSorted;
        private PropertyDescriptor _sortProperty;
        private ListSortDirection _sortDirection;

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return _sortDirection; }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get { return _sortProperty; }
        }

        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            // Get list to sort
            // Note: Items is a non-sortable ICollection<T>
            List<T> items = Items as List<T>;

            // Apply and set the sort, if items to sort
            if (items != null)
            {
                PropertyComparer<T> pc = new PropertyComparer<T>(property, direction);
                items.Sort(pc);
                _isSorted = true;
            }
            else
            {
                _isSorted = false;
            }

            _sortProperty = property;
            _sortDirection = direction;

            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override bool IsSortedCore
        {
            get { return _isSorted; }
        }

        protected override void RemoveSortCore()
        {
            _isSorted = false;
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        #endregion

        #region Persistence

        // NOTE: BindingList<T> is not serializable but List<T> is

        public void Save(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(filename, FileMode.Create))
            {
                // Serialize data list items
                formatter.Serialize(stream, (List<T>)Items);
            }
        }

        public void Load(string filename)
        {

            ClearItems();

            if (File.Exists(filename))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(filename, FileMode.Open))
                {
                    // Deserialize data list items
                    ((List<T>)Items).AddRange((IEnumerable<T>)formatter.Deserialize(stream));
                }
            }

            // Let bound controls know they should refresh their views
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        #endregion

        #region Searching

        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }

        protected override int FindCore(PropertyDescriptor property, object key)
        {
            // Specify search columns
            if (property == null) return -1;

            // Get list to search
            List<T> items = Items as List<T>;

            // Traverse list for value
            foreach (T item in items)
            {
                // Test column search value
                string value = property.GetValue(item).ToString();

                // If value is the search value, return the 
                // index of the data item
                //if ((string)key == value) 
                //    return IndexOf(item);
                if (value.StartsWith(key.ToString(), StringComparison.OrdinalIgnoreCase))
                    return IndexOf(item);
            }
            return -1;
        }

        #endregion
    }
}
