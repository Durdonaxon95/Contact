using System;
using System.Collections.Generic;
using System.IO;
using Consol.Classes;

namespace Consol.Classes
{
    class Program
    {
        static void Main()
        {
            var asosiyXizmat = new Asosiyxizmat();
            while (true)
            {
                Console.WriteLine("\n1. Kontakt qo'shish\n2. Barcha kontaktlar\n3. Kontakt qidirish\n4. Chiqish");
                Console.Write("Tanlang: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        TryCatch.Handle(() =>
                        {
                            var contact = new Contact();
                            Console.Write("ID: ");
                            contact.Id = int.Parse(Console.ReadLine());
                            Console.Write("Nomi: ");
                            contact.Ism = Console.ReadLine();
                            Console.Write("Telefon raqami: ");
                            contact.Telefonraqam = Console.ReadLine();
                            asosiyXizmat.ContactQoshish(contact);
                        });
                        break;
                    case "2":
                        var contacts = asosiyXizmat.GetAllContacts();
                        foreach (var c in contacts)
                        Console.WriteLine($"ID: {c.Id}, Nomi: {c.Ism}, Tel: {c.Telefonraqam}");
                        break;
                    case "3":
                        Console.Write("Qidirish uchun nom kiriting: ");
                        var name = Console.ReadLine();
                        if (!string.IsNullOrEmpty(name))
                        {
                            var result = asosiyXizmat.SearchContact(name);
                            if (result != null)
                                Console.WriteLine($"Topildi: Tel - {result.Telefonraqam}");
                            else
                                Console.WriteLine("Kontakt topilmadi.");
                        }
                        else
                        {
                            Console.WriteLine("Qidirish uchun nom kiritilmadi.");
                        }
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Noto'g'ri tanlov!");
                        break;
            }
        }
    }
}
}