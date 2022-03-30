using Album.Domain.ObjectValues;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Album.Domain.BoundedContext
{
    public static class SaveFile
    {
        /// <summary>
        /// Save Image 
        /// </summary>
        public static string SaveImage(Bitmap bitmap,
                                        string name)
        {
            // đường dẫn trả về
            string path = Path.GetFullPath(
                          Path.Combine(Directory.GetCurrentDirectory() + @$"\RootFiles\album\{FolderSave.ReturnName(ObjectValues.FolderSave.common)}\"));
            // tên trả về
            string pathtest;
            string nameFormat = ConfigFormatImage.SetNameFormat(formatImage: ObjectValues.FormatImage.JPEG_JPG);
            int level = -1;
            do
            {
                level++;
                string nameFile = NameImage.NameProcessConvert(text: name, level: level);
                pathtest = path + nameFile + nameFormat;
            } while (File.Exists(pathtest));

            bitmap.Save(pathtest, ConfigFormatImage.GetImageFormat(formatImage: ObjectValues.FormatImage.JPEG_JPG));

            return (path);
        }

        /// <summary>
        /// Save Image
        /// </summary>
        public static string SaveImage(Bitmap bitmap,
                                        string name,
                                        ObjectValues.FolderSave folderSave)
        {
            string path = Path.GetFullPath(
                        Path.Combine(Directory.GetCurrentDirectory() + @$"\RootFiles\"));
            string pathImage = @$"album\{ FolderSave.ReturnName(folderSave)}\";
            string pathtest;
            string nameFile;
            int level = -1;
            do
            {
                level++;
                nameFile = NameImage.NameProcessConvert(text: name, level: level);
                pathtest = path + pathImage + nameFile + ExtensionType.JPG;
            } while (File.Exists(pathtest));
            bitmap.Save(pathtest, ImageFormat.Jpeg);

            return (pathImage + nameFile + ExtensionType.JPG);
        }

        /// <summary>
        /// Save Image
        /// </summary>
        public static string SaveImage(Bitmap bitmap,
                                        string name,
                                        ObjectValues.FolderSave folderSave,
                                        ObjectValues.FormatImage formatImage)
        {
            // đường dẫn trả về
            string path = Path.GetFullPath(
                          Path.Combine(Directory.GetCurrentDirectory() + @$"\RootFiles\album\{FolderSave.ReturnName(folderSave)}\"));
            // tên trả về
            string pathtest;
            string nameFormat = ConfigFormatImage.SetNameFormat(formatImage: formatImage);
            int level = -1;
            do
            {
                level++;
                string nameFile = NameImage.NameProcessConvert(text: name, level: level);
                pathtest = path + nameFile + nameFormat;
            } while (File.Exists(pathtest));

            bitmap.Save(pathtest, ConfigFormatImage.GetImageFormat(formatImage: formatImage));

            return (path);
        }

        /// <summary>
        /// Save Image
        /// </summary>
        public static string SaveImage(Bitmap bitmap,
                                       string name,
                                       ObjectValues.FolderSave folderSave,
                                       ObjectValues.FormatImage formatImage,
                                       SizeImage sizeImages)
        {
            string path = Path.GetFullPath(
                          Path.Combine(Directory.GetCurrentDirectory() + @$"\RootFiles\"));
            string pathImage = @$"album\{ FolderSave.ReturnName(folderSave)}\";
            string pathtest;
            string nameFormat = ConfigFormatImage.SetNameFormat(formatImage: formatImage);
            string nameSize = ConfigSizeImage.NameSizeDefault(sizeImages);
            string nameFile;
            int level = -1;
            do
            {
                level++;
                nameFile = NameImage.NameProcessConvert(text: name, level: level);
                pathtest = path + pathImage + nameFile + nameSize + nameFormat;
            } while (File.Exists(pathtest));
            bitmap.Save(pathtest, ConfigFormatImage.GetImageFormat(formatImage: formatImage));

            return (pathImage + nameFile + nameSize + nameFormat);
        }
    }
}
