using System;
using System.Collections;
using System.Linq;

namespace OpenDominion.Engine
{
    public class EnumArray<TKey, TValue> : IEnumerable where TKey : Enum
    {
        private readonly TValue[] _array;
        private readonly int _lower;

        public EnumArray()
        {
            _lower = Convert.ToInt32(Enum.GetValues(typeof(TKey)).Cast<TKey>().Min());
            var upper = Convert.ToInt32(Enum.GetValues(typeof(TKey)).Cast<TKey>().Max());

            _array = new TValue[1 + upper - _lower];
        }

        public TValue this[TKey key]
        {
            get => _array[Convert.ToInt32(key) - _lower];
            set => _array[Convert.ToInt32(key) - _lower] = value;
        }

        public IEnumerator GetEnumerator()
        {
            return Enum.GetValues(typeof(TKey))
                .Cast<TKey>()
                .Select(i => this[i])
                .GetEnumerator();
        }
    }
}
