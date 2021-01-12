﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebApi.BLL.Interfaces;

namespace WebApi.BLL.Services
{
    public class FileManager : IFileManager
    {
        private const string DirName = "Files";

        public FileManager()
        {
            Directory.CreateDirectory(DirName);
        }

        public async Task<string> SaveFile(byte[] fileBytes, string hash)
        { 
            var path = DirName + '/' + hash;

            await File.WriteAllBytesAsync(path, fileBytes);

            return hash;
        }

        public byte[] GetFile(string hash)
        {
            var path = DirName + '/' + hash;

            var file = File.ReadAllBytesAsync(path);

            return file.Result;
        }
    }
}
