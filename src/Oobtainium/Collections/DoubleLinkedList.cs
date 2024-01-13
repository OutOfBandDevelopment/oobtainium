using System;

namespace OoBDev.Oobtainium.Collections;

internal class DoubleLinkedList<T>(T item) : IDoubleLinkedList<T>
{
    private readonly object _lock = new();
    private int _position;

    public IDoubleLinkedList<T>? Previous { get; private set; }
    public T Current { get; } = item;
    public IDoubleLinkedList<T>? Next { get; private set; }

    public int Position => _position;

    private static void SyncPosition(DoubleLinkedList<T> from)
    {
        var seed = from._position;
        while (from?.Next is DoubleLinkedList<T> next)
        {
            next._position = ++seed;
            from = next;
        }
    }

    public IDoubleLinkedList<T> InsertBefore(T item)
    {
        lock (_lock)
        {
            var newItem = new DoubleLinkedList<T>(item) { Previous = Previous, Next = this };
            if (Previous is DoubleLinkedList<T> previous)
            {
                previous.Next = newItem;
                newItem._position = previous._position + 1;
            }
            else if (Previous != null)
            {
                throw new NotSupportedException();
            }
            Previous = newItem;
            SyncPosition(newItem);
            return newItem;
        }
    }
    public IDoubleLinkedList<T> InsertAfter(T item)
    {
        lock (_lock)
        {
            var newItem = new DoubleLinkedList<T>(item) { Previous = this, Next = Next, _position = _position + 1, };
            if (Next is DoubleLinkedList<T> next)
            {
                next.Previous = newItem;
            }
            else if (Next != null)
            {
                throw new NotSupportedException();
            }
            Next = newItem;
            SyncPosition(newItem);
            return newItem;
        }
    }
}
