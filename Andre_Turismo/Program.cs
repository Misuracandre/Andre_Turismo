// See https://aka.ms/new-console-template for more information
using Andre_Turismo.Models;

Console.WriteLine("Hello, World!");

City city = new()
{
    Description = "Araraquara"
};

Address address = new()
{
    Id = 1,
    Street = "avenida",
    Number = 400,
    Neighborhood = "Jardim Morumbi",
    ZipCode = "14800",
    Extension = "Ap",
    City = city,
    Registration_Date = DateTime.Now
};

Client client = new()
{
    Id = 1,
    Name = "Andre",
    Phone = "16000000",
    Address = address,
    Registration_Date = DateTime.Now
};

Ticket ticket = new()
{



};
