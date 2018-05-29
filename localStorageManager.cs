using System;
using Android.Widget;
using PCLStorage;
using System.Threading.Tasks;



namespace po4
{
    public class LocalStorageManager
    {
        String folderName = "temp";
      


        public async void tempAsync()
        {
            IFolder folder = await FileSystem.Current.LocalStorage.CreateFolderAsync(folderName, CreationCollisionOption.ReplaceExisting);
            String filename = "list.txt";
            IFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

        }
        public async static Task<bool> IsFolderExistAsync(this string folderName, IFolder rootFolder = null)
        {
            // get hold of the file system  
            IFolder folder = rootFolder ?? FileSystem.Current.LocalStorage;
            ExistenceCheckResult folderexist = await folder.CheckExistsAsync(folderName);
            // already run at least once, don't overwrite what's there  
            if (folderexist == ExistenceCheckResult.FolderExists)
            {
                return true;

            }
            return false;
        }
    
    }
}
