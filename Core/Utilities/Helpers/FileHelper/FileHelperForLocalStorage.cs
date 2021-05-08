using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper
{
    public static class FileHelperForLocalStorage
    {
        public static void Add(IFormFile file, string path)
        {
            if (file.Length > 0)
            {

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }

            }

        }

        public static void Delete(string pathToDelete)
        {
            if (File.Exists(pathToDelete))
            {
                File.Delete(pathToDelete);
            }
        }

        public static void Update(string oldPath, IFormFile fileForUpdate, string newPath)
        {
            if (newPath != null)
            {
                using (var stream = new FileStream(newPath, FileMode.Create))
                {
                    fileForUpdate.CopyTo(stream);
                    stream.Flush();
                }
            }
            File.Delete(oldPath);

        }
    }
}
