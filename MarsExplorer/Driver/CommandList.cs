using MarsExplorer.Enums;
using System.Collections;
using System.Collections.Generic;

namespace MarsExplorer.Driver
{
    public interface ICommandList : IInputObject, IList<CommandType>
    {
        void AddRange(IEnumerable<CommandType> items);
    }

    public class CommandList : ICommandList
    {
        readonly IList<CommandType> _list;
        public CommandList()
        {
            _list = new List<CommandType>();
        }

        public CommandList(IEnumerable<CommandType> commands) : this()
        {
            AddRange(commands);
        }

        public void AddRange(IEnumerable<CommandType> items)
        {
            foreach (CommandType item in items)
                _list.Add(item);
        }

        #region IList Implements        
        public CommandType this[int index] { get => _list[index]; set => _list[index] = value; }
        public int Count => _list.Count;
        public bool IsReadOnly => _list.IsReadOnly;
        public void Add(CommandType item) => _list.Add(item);
        public void Clear() => _list.Clear();
        public bool Contains(CommandType item) => _list.Contains(item);
        public void CopyTo(CommandType[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);
        public IEnumerator<CommandType> GetEnumerator() => _list.GetEnumerator();
        public int IndexOf(CommandType item) => _list.IndexOf(item);
        public void Insert(int index, CommandType item) => _list.Insert(index, item);

        public bool Remove(CommandType item) => _list.Remove(item);

        public void RemoveAt(int index) => _list.RemoveAt(index);

        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();
        #endregion
    }
}


