using Java.IO;
using Xamarin.Forms;
using PriceChecker.SERVICE;
using Android.Content;
using Android.Provider;

[assembly: Dependency(typeof(PriceChecker.Droid.PhotoManager))]
namespace PriceChecker.Droid
{

    public class PhotoManager:IPhotoManager
    {
        public void DeletePhoto(string path)
        {
            Context context = Android.App.Application.Context;
            Java.IO.File file = new Java.IO.File(path);

            string where = MediaStore.MediaColumns.Data + "=?";
            string[] selectionArgs = new string[] { file.AbsolutePath };
            ContentResolver contentResolver = context.ContentResolver;
            Android.Net.Uri filesUri = MediaStore.Files.GetContentUri("external");

            if (file.Exists())
            {
                contentResolver.Delete(filesUri, where, selectionArgs);
            }

        }
    }
}