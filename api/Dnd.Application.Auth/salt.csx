#r "C:\Users\kacar\RiderProjects\DnD_CA\Dnd.Application.Auth\bin\Debug\net9.0\Dnd.Application.Auth.dll"

using Dnd.Application.Auth.Infrastructure.Security;

var salt = Convert.ToBase64String(Passwords.GenerateSalt());

Console.WriteLine(salt);

var hash = Passwords.HashPassword("asdf", salt);

Console.WriteLine(hash)