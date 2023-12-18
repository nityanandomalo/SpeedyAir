namespace SpeedyAir.Models
{
    internal class MenuModel
    {
        public string Header { get; set; }
        public IList<string> Items { get; set; }
        public int ExitValue { get; set; }

        public MenuModel()
        {
            Items = new List<string>();
        }
    }
}
