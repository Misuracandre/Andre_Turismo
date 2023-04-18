// See https://aka.ms/new-console-template for more information
using Andre_Turismo.Controllers;
using Andre_Turismo.Models;

Console.WriteLine("Hello, World!");

City city = new()
{
    Description = "Araraquara"
};

Address address = new()
{
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
    Name = "Andre",
    Phone = "16000000",
    Address = address,
    Registration_Date = DateTime.Now
};

Ticket ticket = new()
{
    Origin = address,
    Destination = address,
    Client = client,
    Value = 50
};

Hotel hotel = new()
{
    Name = "Hotel raiz",
    Address = address,
    Registration_Date = DateTime.Now
};

Package package = new()
{
    Hotel = hotel,
    Ticket = ticket,
    Value = 50,
    Client = client,
    Registration_Date = DateTime.Now
};

if (new PackageController().Insert(package))
{
    Console.WriteLine("Sucesso! Registro inserido!");
}
else
{
    Console.WriteLine("Erro ao inserir registro.");
}
