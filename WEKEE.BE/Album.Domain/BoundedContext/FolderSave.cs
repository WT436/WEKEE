using System;
using System.Collections.Generic;
using System.Text;

namespace Album.Domain.BoundedContext
{
    static class FolderSave
    {
        internal static string ReturnName(ObjectValues.FolderSave folderSave)
        {
            return folderSave switch
            {
                ObjectValues.FolderSave.avatar => "avatar",
                ObjectValues.FolderSave.icon => "icon",
                ObjectValues.FolderSave.common => "common",
                ObjectValues.FolderSave.post => "post",
                ObjectValues.FolderSave.product => "product",
                ObjectValues.FolderSave.rootImage => "rootImage",
                _ => throw new NotImplementedException(),
            };
        }
    }
}
