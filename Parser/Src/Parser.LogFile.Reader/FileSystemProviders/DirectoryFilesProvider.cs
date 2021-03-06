﻿using System.Collections.Generic;
using System.IO;

using Bytes2you.Validation;
using Parser.LogFile.Reader.Contracts;

namespace Parser.LogFile.Reader.FileSystemProviders
{
    public class DirectoryFilesProvider : IDirectoryFilesProvider
    {
        public IEnumerable<string> GetDirectoryFiles(string directoryPath)
        {
            Guard.WhenArgument(directoryPath, nameof(directoryPath)).IsNullOrEmpty().Throw();

            if (Directory.Exists(directoryPath))
            {
                return Directory.GetFiles(directoryPath);
            }
            else
            {
                throw new DirectoryNotFoundException(directoryPath);
            }
        }
    }
}
