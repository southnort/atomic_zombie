using System;

namespace Atomic
{
    public sealed class AtomicValue<T> : IAtomicValue<T>
    {
        public T Value
        {
            get { return func.Invoke(); }
        }

        private readonly Func<T> func;

        public AtomicValue(Func<T> func)
        {
            this.func = func;
        }
    }
}