using Social_Media_App_Api_.Net_Core.Models;

namespace Social_Media_App_Api_.Net_Core.Services
{
    public class ImageUpload
    {
        private static ImageUpload obj = new ImageUpload();
        private ImageUpload()
        {
        }

        public static async Task<String> ImageUploadHandle(PostModel post, IWebHostEnvironment env)
        {
            if (post.imageFile.Length > 0)
            {
                string FileName = Path.GetFileNameWithoutExtension(post.imageFile.FileName);
                string FileExtension = Path.GetExtension(post.imageFile.FileName);
                FileName = FileName + DateTime.Now.ToString("MM-dd-hh-mm-ss-ff") + FileExtension;
                string path = Path.Combine(env.ContentRootPath,"Images",FileName);

                using(FileStream fs = new FileStream(path, FileMode.Create))
                {
                    await post.imageFile.CopyToAsync(fs);
                }

                return FileName;
            }
            return "";
        } 

        public static ImageUpload GetImageUpload()
        {
            return obj;
        }
    }
}
