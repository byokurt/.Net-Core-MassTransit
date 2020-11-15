using OkurtProject.Contract;

namespace OkurtProject.API.Model
{
    public class ExampleCommand : IExampleCommand
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}