using BEFOYS.DataLayer.Entity.Document;
using BEFOYS.DataLayer.Enums;
using BEFOYS.DataLayer.ServiceContext;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BEFOYS.DataLayer.Helpers
{
    public static class UploadHelper
    {

        public static async System.Threading.Tasks.Task<int> Upload(this IFormFile file,string folderpath,ServiceContext.ServiceContext context,Enum_Code code)
        {
            if (file == null || file.Length == 0)
                return 0;

            var folderName = Path.Combine("Uploads", folderpath);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            var uniqueFileName = $"{Guid.NewGuid()}_profilepic.png";
            var dbPath = Path.Combine(folderName, uniqueFileName);
            using (var fileStream = new FileStream(Path.Combine(filePath, uniqueFileName), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            var typeid = context.Tbl_Code.FirstOrDefault(x => x.Code_Display == code.ToString());

            Tbl_Document document = new Tbl_Document()
            {
                Document_FileName = file.FileName,
                Document_FolderName=folderpath,
                Document_Path= dbPath,
                Document_TypeCodeID=typeid.Code_ID
            };

            context.Tbl_Document.Add(document);
            await context.SaveChangesAsync();

            return document.Document_ID;
        }
    }
}
