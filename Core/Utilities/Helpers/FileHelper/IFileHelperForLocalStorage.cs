using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileHelperForLocalStorage
    {
        string Add(IFormFile file, string path);
        string Update(List<IFormFile> filesForUpdate, string pathForUpdate);
        string Delete(List<IFormFile> filesToDelete, string pathToDelete);

    }
}
