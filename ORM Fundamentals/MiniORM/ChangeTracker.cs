using System.Reflection;
using System.Linq;
using System;

namespace MiniORM
{
    internal class ChangeTracker<T>
        where T : class, new()
    {
        private readonly IList<T> allEntities;
        private readonly IList<T> added;
        private readonly IList<T> removed;
        
        private ChangeTracker ()
	    {
            this.added = new List<T>();
            this.removed = new List<T>();
	    }

        public ChangeTracker(IEnumerable<T> entities)
            : this()
	    {
            allEntities = CloneEntities(entities);
	    }

        private IList<T> CloneEntities(IEnumerable<T> originalEntities)
        {
            IList<T> clonedEntities = new List<T>();
            PropertyInfo[] propertiesToClone = typeof(T).GetProperties().Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType)).ToArray();

            foreach (T originalEntity in originalEntities)
            {
                T entityClone = Activator.CreateInstance<T>();
                foreach (PropertyInfo property in propertiesToClone)
	            {
                    object originalValue = property.GetValue(originalEntity);
                    property.SetValue(entityClone, originalValue);
	            }
            }

            return clonedEntities;
        }
    }
}