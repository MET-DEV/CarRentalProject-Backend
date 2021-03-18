using Microsoft.AspNetCore.Http;
using MyCore.Utilities.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyCore.Utilities.FileHelper
{
    public class FileHelper
    {
        private static string directory = Environment.CurrentDirectory + @"\wwwroot\uploads\";

        public static IResult Add(IFormFile file)
        {
            if (file.FileName.Length > 0)
            {
                var guidName = Guid.NewGuid().ToString();
                var extension = Path.GetExtension(file.FileName);  
                using (FileStream stream = File.Create(directory + guidName + extension))
                {
                    file.CopyTo(stream);
                    stream.Flush();

                }
                return new SuccessDataResult((guidName + extension));
            }
            return new ErrorResult();
        }
        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessDataResult();
        }
        public static string Update(string sourcePath, IFormFile file)
        {
            var result = newPath(file);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }
            }
            File.Delete(sourcePath);
            return result;
        }
        public static string newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            string path = Environment.CurrentDirectory + @"\wwwroot\Images\carImages";
            var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;

            string result = $@"{path}\{newPath}";
            return result;
        }
    }
}
