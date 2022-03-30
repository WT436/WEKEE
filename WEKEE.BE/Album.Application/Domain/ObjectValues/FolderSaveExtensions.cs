using System;

namespace Album.Domain.ObjectValues
{
    public static class FolderSaveExtensions
    {
        public enum FolderSave
        {
            AVATAR = 0,
            ICON = 1,
            COMMON = 2,
            POST = 3,
            PRODUCT = 4,
            ROOT_IMAGE = 5,
            EVALUATES = 6,
            FILE = 7,
            IMAGE_SYSTEM = 8,
            ROOT_EVALUATES = 9,
            VIDEO = 10,
            AUDIO = 11
        }

        public static string FolderSaveConvert(FolderSave folderSave)
        {
            return folderSave switch
            {
                FolderSave.AVATAR => "avatar",
                FolderSave.ICON => "icon",
                FolderSave.COMMON => "common",
                FolderSave.POST => "post",
                FolderSave.PRODUCT => "product",
                FolderSave.ROOT_IMAGE => "rootImage",
                FolderSave.EVALUATES => "evaluates",
                FolderSave.FILE => "file",
                FolderSave.IMAGE_SYSTEM => "imageSystem",
                FolderSave.ROOT_EVALUATES => "rootevaluates",
                FolderSave.VIDEO => "video",
                FolderSave.AUDIO => "audio",
                _ => throw new NotImplementedException(),
            };
        }
    }
}
