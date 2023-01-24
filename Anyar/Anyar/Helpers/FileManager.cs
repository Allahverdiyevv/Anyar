namespace Anyar.Helpers
{
    public static class FileManager
    {
        public static string SaveFile(string rootpash , string filename  ,IFormFile file)
        {
            string name = file.FileName;
            string paht = Path.Combine(rootpash, filename , name);
            using (FileStream fileStream =  new FileStream(paht , FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return name;
        }

        public static void DeletFile(string rootpash , string filename ,string name)
        {
            string path = Path.Combine(rootpash, filename , name );
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            
        }


    }
}
