using System.Collections.Generic;

namespace OoBDev.Oobtainium.Collections;

public static class LinkedListEx
{
    public static IEnumerable<T> AsEnumerableReversed<T>(this LinkedList<T> current)
    {
        var item = current.Last;
        if (item == null)
            yield break;
        do
        {
            yield return item.Value;
            item = item.Previous;
        }
        while (item?.Previous != null);
    }
}
