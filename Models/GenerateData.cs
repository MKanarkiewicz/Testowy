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

        private Address RandomAddress()
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
        private Login RandomLogin(string imie, string nazwisko)
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
        private string RandomDateBirth()
        {
            Random r = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            DateTime end = new DateTime(1999, 12, 30);

            int range = (end - start).Days;
            DateTime randomDataUrodzenia = start.AddDays(r.Next(range));
            return randomDataUrodzenia.ToString("dd/MM/yyyy");
        }
        private string Pesel(string dataUrodzenia, int plec)
        {
            string pesel = "";
            char[] znaki;
            char[] cyfraKontrolna;
            int[] kontrolna = new int[] { 1,3,7,9,1,3,7,9,1,3};
            int mnozenieKontrolna = 0;
            int sumaKontrolna = 0;
            Random r = new Random();

            znaki = dataUrodzenia.ToCharArray();
            pesel = znaki[8].ToString() + znaki[9].ToString() + znaki[3].ToString() + znaki[4].ToString() + znaki[0].ToString() + znaki[1].ToString();
            pesel += r.Next(0,10);
            pesel += r.Next(0,10);
            pesel += r.Next(0,10);
            if (plec == 1)
            {
                string[] parzysta = new string[] { "0", "2", "4", "6", "8" };
                pesel += parzysta[r.Next(0, parzysta.Length)];
            }
            else
            {
                string[] nieparzysta = new string[] { "1", "3", "5", "7", "9" };
                pesel += nieparzysta[r.Next(0, nieparzysta.Length)];
            }
            cyfraKontrolna = pesel.ToCharArray();
            for (int i = 0; i < cyfraKontrolna.Length; i++)
            {
                mnozenieKontrolna += int.Parse(cyfraKontrolna[i].ToString()) * kontrolna[i];
                if (mnozenieKontrolna > 10)
                {
                    mnozenieKontrolna = mnozenieKontrolna % 10;
                }
                sumaKontrolna += mnozenieKontrolna;
                mnozenieKontrolna = 0;
            }
            sumaKontrolna = sumaKontrolna % 10;
            sumaKontrolna = 10 - sumaKontrolna;
            pesel += sumaKontrolna;
            return pesel;
        }
        public Student RandomPerson()
        {
            Student person = new Student();
            Random r = new Random();
            int plec = r.Next(0, 2); //0 - man, 1 - woman
            if (plec == 0)
            {
                person.ID = 1;
                person.FirstName = nameMale[r.Next(0, nameMale.Length)];
                person.LastName = surnameMale[r.Next(0, surnameMale.Length)];
                person.DateBirth = RandomDateBirth();
                person.Pesel = Pesel(person.DateBirth, plec);
            }
            else
            {
                person.ID = 1;
                person.FirstName = nameFemale[r.Next(0, nameMale.Length)];
                person.LastName = surnameFemale[r.Next(0, surnameMale.Length)];
                person.DateBirth = RandomDateBirth();
                person.Pesel = Pesel(person.DateBirth, plec);
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