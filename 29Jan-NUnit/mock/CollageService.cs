namespace ConsoleApp2.Service
{
    public class CollageService : ICollageService
    {
        public string GetFarewellNote(string name)
        {
            return $"All the best {name}";
        }
        public string GetWelcomeNote(string name)
        {
            return $"Welcome to the college {name}";
        }
    }
}