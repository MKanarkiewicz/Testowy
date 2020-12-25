using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ICollege_WebApp.Models
{
    public class GenerateData
    {
        private string[] nameMale = new string[] {  "Adam","Wojciech","Sławomir","Grzegorz","Andrzej","Marcel","Piotr", "Paweł", "Gaweł", "Antoni", "Szymon","Kacper","Maciej","Dariusz", "Mariusz", "Dawid", "Daniel", "Bartłomiej" };
        private string[] surnameMale = new string[] { "Nowicki", "Kowalski", "Adamczyk", "Lewandowski", "Nowak", "Zieliński", "Kwiatkowski", "Kaczmarek", "Woźniak", "Wiśniewski", "Pawłowski", "Grabowski", "Wojciechowski", "Nowakowski"};
        private string[] nameFemale = new string[] {"Ewa","Monika", "Joanna", "Paulina", "Magda", "Klaudia","Martyna", "Oliwia", "Aleksandra", "Zuzanna", "Edyta", "Anna", "Alicja", "Angelika","Anita", "Barbara", "Blanka", "Bożena","Beata","Czesława"};
        private string[] surnameFemale = new string[] { "Nowicka","Kowalska", "Adamczyk", "Lewandowska","Nowak","Zielińska","Kwiatkowska", "Kaczmarek","Woźniak","Wiśniewska","Pawłowska","Grabowska","Wojciechowska","Nowakowska"};
        private string[] town = new string[] {"Poznań","Warszawa","Lublin","Gdańsk","Gdynia", "Opole","Włocławek","Toruń","Kołobrzeg","Wrocław","Sopot","Piła","Grudziądz","Kraków","Białystok","Szczecin","Łódź","Bielsko-Biała","Bolków","Bytom"};
        private string[] street = new string[] { "Radosna","Wesoła","Szkolna","Miodowa","3 Maja","Jana Kochanowskiego", "Mikołaja Reja","Bielska","Krzywa","Okrzei","Powstańców Wielkopolskich", "Łąkowa","Kwiatowa","Krótka","Lipowa","Brzozowa","Ogrodowa","Mickiewicza","Astronautów" };

        public Address RandomAddress()
        {
            Address address = new Address();
            Random r = new Random();

            address.ID = 1;
            address.Street = street[r.Next(0, street.Length)];
            address.Town = town[r.Next(0, town.Length)];

            address.Number = r.Next(1, 55).ToString() + "/" + r.Next(1, 55).ToString();
            address.ZipCode = r.Next(10, 99).ToString() + "-" + r.Next(100, 999).ToString();

            return address;
        }
        public Login RandomLogin(string imie, string nazwisko)
        {
            string[] mail = new string[] { "onet.pl", "gmail.com", "wp.pl", "interia.pl"};
            string[] passwd = new string[] { "a", "b", "c", "d", "e", "Q", "E", "@", "#", ".", "f", "q" };
            string haslo = "";
            Random r = new Random();
            Login login = new Login();
            
            for (int i = 0; i < 8; i++)
            {
                haslo += passwd[r.Next(0, passwd.Length)];
            }
            login.ID = 1;
            login.Mail = imie + "." + nazwisko + "@" + mail[r.Next(0, mail.Length)];
            login.Password = haslo;

            return login;
        }
        public DateTime RandomDateBirth()
        {
            Random r = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(r.Next(range));
        }
        public Student RandomPerson()
        {
            Student person = new Student();
            Random r = new Random();
            int plec = r.Next(0, 1); //0 - man, 1 - woman
            if (plec == 0)
            {
                person.ID = 1;
                person.FirstName = nameMale[r.Next(0, nameMale.Length)];
                person.LastName = surnameMale[r.Next(0, surnameMale.Length)];
                person.Pesel = "99022112345";
                person.DateBirth = RandomDateBirth();
            }
            else
            {
                person.ID = 1;
                person.FirstName = nameFemale[r.Next(0, nameMale.Length)];
                person.LastName = surnameFemale[r.Next(0, surnameMale.Length)];
                person.Pesel = "99022112345";
                person.DateBirth = RandomDateBirth();
            }

            person.Login = RandomLogin(person.FirstName , person.LastName);
            person.Address = RandomAddress();
            return person;
        }
        
        /*public string RandomName() 
        {
            string filePath = @"D:\WSB\Semestr 5\Programowanie zaawansowane\PROJEKTZALICZENIOWY\ICollege_WebApp-master\ICollege_WebApp-master\man.json";
            Random random = new Random();
            using (StreamReader r = new StreamReader(filePath, Encoding.Default))
            {
                string json = r.ReadToEnd();
                var dictionary = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);
                string firstname = dictionary["firstname"][random.Next(0, dictionary["firstname"].Count)];
                return firstname;
            }
        }*/
    }
}