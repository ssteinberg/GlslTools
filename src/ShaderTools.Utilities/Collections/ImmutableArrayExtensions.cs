﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using ShaderTools.Utilities.PooledObjects;

namespace ShaderTools.Utilities.Collections
{
    internal static class ImmutableArrayExtensions
    {
        internal static ImmutableArray<T> ToImmutableArrayOrEmpty<T>(this IEnumerable<T> items)
        {
            if (items == null)
            {
                return ImmutableArray.Create<T>();
            }

            return ImmutableArray.CreateRange<T>(items);
        }

        internal static ImmutableArray<T> ToImmutableArrayOrEmpty<T>(this ImmutableArray<T> items)
        {
            if (items.IsDefault)
            {
                return ImmutableArray.Create<T>();
            }

            return items;
        }

        // same as Array.BinarySearch but the ability to pass arbitrary value to the comparer without allocation
        internal static int BinarySearch<TElement, TValue>(this ImmutableArray<TElement> array, TValue value, Func<TElement, TValue, int> comparer)
        {
            int low = 0;
            int high = array.Length - 1;

            while (low <= high)
            {
                int middle = low + ((high - low) >> 1);
                int comparison = comparer(array[middle], value);

                if (comparison == 0)
                {
                    return middle;
                }

                if (comparison > 0)
                {
                    high = middle - 1;
                }
                else
                {
                    low = middle + 1;
                }
            }

            return ~low;
        }

        /// <summary>
        /// Returns an empty array if the input array is null (default)
        /// </summary>
        public static ImmutableArray<T> NullToEmpty<T>(this ImmutableArray<T> array)
        {
            return array.IsDefault ? ImmutableArray<T>.Empty : array;
        }

        /// <summary>
        /// Returns an array of distinct elements, preserving the order in the original array.
        /// If the array has no duplicates, the original array is returned. The original array must not be null.
        /// </summary>
        public static ImmutableArray<T> Distinct<T>(this ImmutableArray<T> array, IEqualityComparer<T> comparer = null)
        {
            Debug.Assert(!array.IsDefault);

            if (array.Length < 2)
            {
                return array;
            }

            var set = new HashSet<T>(comparer);
            var builder = ArrayBuilder<T>.GetInstance();
            foreach (var a in array)
            {
                if (set.Add(a))
                {
                    builder.Add(a);
                }
            }

            var result = (builder.Count == array.Length) ? array : builder.ToImmutable();
            builder.Free();
            return result;
        }

        /// <summary>
        /// Creates a new immutable array based on filtered elements by the predicate. The array must not be null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array to process</param>
        /// <param name="predicate">The delegate that defines the conditions of the element to search for.</param>
        /// <returns></returns>
        public static ImmutableArray<T> WhereAsArray<T>(this ImmutableArray<T> array, Func<T, bool> predicate)
        {
            Debug.Assert(!array.IsDefault);

            ArrayBuilder<T> builder = null;
            bool none = true;
            bool all = true;

            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                var a = array[i];
                if (predicate(a))
                {
                    none = false;
                    if (all)
                    {
                        continue;
                    }

                    Debug.Assert(i > 0);
                    if (builder == null)
                    {
                        builder = ArrayBuilder<T>.GetInstance();
                    }

                    builder.Add(a);
                }
                else
                {
                    if (none)
                    {
                        all = false;
                        continue;
                    }

                    Debug.Assert(i > 0);
                    if (all)
                    {
                        Debug.Assert(builder == null);
                        all = false;
                        builder = ArrayBuilder<T>.GetInstance();
                        for (int j = 0; j < i; j++)
                        {
                            builder.Add(array[j]);
                        }
                    }
                }
            }

            if (builder != null)
            {
                Debug.Assert(!all);
                Debug.Assert(!none);
                return builder.ToImmutableAndFree();
            }
            else if (all)
            {
                return array;
            }
            else
            {
                Debug.Assert(none);
                return ImmutableArray<T>.Empty;
            }
        }

        /// <summary>
        /// Maps an immutable array to another immutable array.
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="items">The array to map</param>
        /// <param name="map">The mapping delegate</param>
        /// <returns>If the items's length is 0, this will return an empty immutable array</returns>
        public static ImmutableArray<TResult> SelectAsArray<TItem, TResult>(this ImmutableArray<TItem> items, Func<TItem, TResult> map)
        {
            return ImmutableArray.CreateRange(items, map);
        }

        internal static ImmutableArray<T> Concat<T>(this ImmutableArray<T> first, ImmutableArray<T> second)
        {
            return first.AddRange(second);
        }

        internal static ImmutableArray<T> Concat<T>(this ImmutableArray<T> first, T second)
        {
            return first.Add(second);
        }
    }
}
