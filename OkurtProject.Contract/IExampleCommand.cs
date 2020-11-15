using System;

namespace OkurtProject.Contract
{
    public interface IExampleCommand
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}