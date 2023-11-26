using System;
namespace Composite
{
    /// <summary>
    /// Compoment
    /// </summary>
	public abstract class FileSystemItem
	{
        public string Name { get; set; }
        public abstract long GetSize();

        public FileSystemItem(string name)
        {
            Name = name;
        }
	}

    /// <summary>
    /// Composite
    /// </summary>
    public class Directory : FileSystemItem
    {
        private long _size;
        private List<FileSystemItem> _items { get; set; } = new();

        public Directory(string name, long size) : base(name)
        {
            _size = size;
        }

        public void Add(FileSystemItem item)
        {
            _items.Add(item);
        }

        public void Remove(FileSystemItem item)
        {
            _items.Remove(item);
        }

        public override long GetSize()
        {
            var treeSize = _size;

            foreach(var item in _items)
                treeSize += item.GetSize();

            return treeSize;
        }
    }

    /// <summary>
    /// Leaf
    /// </summary>
    public class File : FileSystemItem
    {
        private long _size;

        public File(string name, long size) : base(name)
        {
            _size = size;
        }

        public override long GetSize()
        {
            return _size;
        }
    }
}

