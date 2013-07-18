using System.Collections.Generic;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel
{
    public class SampleItemCollectionItem : SampleItem
    {
        private readonly ICollection<SampleItemCollectionItem> _collection;

        public SampleItemCollectionItem(ICollection<SampleItemCollectionItem> collection, int id, string name, string something, bool boolean)
            : base(id, name, something, boolean)
        {
            _collection = collection;
        }

        public void Delete()
        {
            _collection.Remove(this);
        }
    }

    public class SampleItem
    {
        private readonly ReadOnlyProperty<int> _id;
        private readonly ReadOnlyProperty<string> _name;
        private readonly ReadOnlyProperty<string> _something;
        private readonly ReadOnlyProperty<bool> _boolean;

        public SampleItem(int id, string name, string something, bool boolean)
        {
            _id = new ReadOnlyProperty<int>(id);
            _name = new ReadOnlyProperty<string>(name);
            _something = new ReadOnlyProperty<string>(something);
            _boolean = new ReadOnlyProperty<bool>(boolean);
        }

        public ReadOnlyProperty<int> Id
        {
            get { return _id; }
        }

        public ReadOnlyProperty<string> Name
        {
            get { return _name; }
        }

        public ReadOnlyProperty<string> Something
        {
            get { return _something; }
        }

        public ReadOnlyProperty<bool> Boolean
        {
            get { return _boolean; }
        }
    }
}