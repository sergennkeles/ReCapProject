using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileManagaments
{
    public static class FileManagament
    {
        public static bool AddImageFile(IFormFile formFile, string filePath, string ImageName)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), filePath, ImageName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public static bool CheckImageFile(IFormFile formFile)
        {
            var extension = "." + formFile.FileName.Split('.')[formFile.FileName.Split('.').Length - 1];
            return (extension == ".jpg" || extension == ".jpeg" || extension == ".png");
        }

        public static bool DeleteImageFile (string filePath, string fileName)
        {
            string fullPath = filePath + fileName;
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return true;
            }
            return false;
        }

       
    }
}
