using System;

namespace DefaultNamespace
{
    public class WeakRef<T> where T : class
    {
        private WeakReference weakReference = null;
        public WeakRef(T obj)
        {
            this.weakReference = new WeakReference(obj);
        }

        public WeakRef()
        {
            this.weakReference = new WeakReference(null);
        }

        public T Ref
        {
            get
            {
                if (this.weakReference != null)
                {
                    return (T)this.weakReference.Target;
                }

                return null;
            }
            set { this.weakReference.Target = value; }
        }
    }
}