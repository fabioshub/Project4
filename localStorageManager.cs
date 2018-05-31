using System;
using System.IO;
using Android.Widget;
using PCLStorage;
using System.Threading.Tasks;

  namespace po4
{
    public class lst
    {
        public async Task PCLStorageSample()
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("MySubFolder", CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync("answer.txt", CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync("42");
        }  
    }

}
