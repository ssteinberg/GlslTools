﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace ShaderTools.CodeAnalysis.Text
{
    /// <summary>
    /// Implementation of SourceText based on a <see cref="String"/> input
    /// </summary>
    internal sealed class StringText : SourceText
    {
        private readonly string _source;

        internal StringText(
            string source,
            string filePath)
            : base()
        {
            Debug.Assert(source != null);

            _source = source;
            FilePath = filePath;
        }

        /// <summary>
        /// Underlying string which is the source of this <see cref="StringText"/>instance
        /// </summary>
        public string Source => _source;

        /// <summary>
        /// The length of the text represented by <see cref="StringText"/>.
        /// </summary>
        public override int Length => _source.Length;

        public override string FilePath { get; }

        /// <summary>
        /// Returns a character at given position.
        /// </summary>
        /// <param name="position">The position to get the character from.</param>
        /// <returns>The character.</returns>
        /// <exception cref="ArgumentOutOfRangeException">When position is negative or 
        /// greater than <see cref="Length"/>.</exception>
        public override char this[int position]
        {
            get
            {
                // NOTE: we are not validating position here as that would not 
                //       add any value to the range check that string accessor performs anyways.

                return _source[position];
            }
        }

        /// <summary>
        /// Provides a string representation of the StringText located within given span.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">When given span is outside of the text range.</exception>
        public override string ToString(TextSpan span)
        {
            if (span.End > this.Source.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(span));
            }

            if (span.Start == 0 && span.Length == this.Length)
            {
                return this.Source;
            }

            return this.Source.Substring(span.Start, span.Length);
        }

        public override void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
        {
            this.Source.CopyTo(sourceIndex, destination, destinationIndex, count);
        }

        public override void Write(TextWriter textWriter, TextSpan span, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (span.Start == 0 && span.End == this.Length)
            {
                textWriter.Write(this.Source);
            }
            else
            {
                base.Write(textWriter, span, cancellationToken);
            }
        }
    }
}