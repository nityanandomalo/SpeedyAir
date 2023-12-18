namespace SpeedyAir.Extention
{
    internal class FileReader
    {
        public static string ReadAllText(string path)
        {
            return File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), path));
        }
    }
}
