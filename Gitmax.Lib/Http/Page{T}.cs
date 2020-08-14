using System;
using System.Collections.Generic;
using System.Text;

namespace Gitmax.Lib.Http
{
    public sealed class Page<T>
    {
        public Page(T[] items, Uri nextPage) {
            Items = items;
            NextPage = nextPage;
        }

        public T[] Items { get; }
        public Uri NextPage { get; }
    }
}
