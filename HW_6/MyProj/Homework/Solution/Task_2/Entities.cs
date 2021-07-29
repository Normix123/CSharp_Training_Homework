using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task_2
{
    public class Entities : IEnumerable<Entity>
    {
        private readonly List<Entity> _list;

        public Entities(IEnumerable<Entity> entities)
        {
            _list = entities.ToList();
        }

        public IEnumerator<Entity> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}