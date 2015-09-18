﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S04_ListDemo.GroupingHelpers
{
    public class KeyedList<TKey, TItem> : List<TItem>
    {
        public TKey Key { protected set; get; }

        public IEnumerable<TItem> InternalList { protected set; get; }

        public KeyedList(TKey key, IEnumerable<TItem> items)
            : base(items)
        {
            Key = key;
            InternalList = items;
        }

        public KeyedList(IGrouping<TKey, TItem> grouping)
            : base(grouping)
        {
            Key = grouping.Key;
            InternalList = grouping;
        }
    }
}
