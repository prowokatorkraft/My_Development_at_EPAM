using System.Collections.Generic;

namespace DynamicArray
{
    public class CycledDynamicArray<T> : DynamicArray<T>
    {
        public CycledDynamicArray(int capasity) : base(capasity)
        {

        }
        public CycledDynamicArray(IEnumerable<T> array) : base(array)
        {

        }

        public override bool MoveNext()
        {
            if (Count - 1 > _index)
            {
                _index++;
            }
            else
            {
                _index = 0;
            }

            return true;
        }
    }
}
