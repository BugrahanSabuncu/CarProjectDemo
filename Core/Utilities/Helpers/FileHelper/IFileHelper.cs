using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.FileHelperManager
{
    public interface IFileHelper
    {
        string Upload(IFormFile file,string root);
        void Delete(string filePath);
        string Update(IFormFile formFile, string filePath, string root);
    }
}
