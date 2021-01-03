namespace BookListRazor2.Models
{
    public class HelloWorldService
    {
        public string Now { get; }

        //Constructor
        public HelloWorldService()
        {
            Now = $"Hello World! Now is: {System.DateTime.Now.Ticks}";
        }
    }
}