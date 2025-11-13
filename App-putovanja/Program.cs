using System.Windows.Markup;

namespace App_putovanja
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var users = new Dictionary<int, Tuple<string, string, string, List<int>>>();
            users[1] = Tuple.Create("Ana", "Anić", "1985-04-12", new List<int> {1, 2});
            users[2] = Tuple.Create("Ivo", "Ivić", "1992-09-25", new List<int>());
            users[3] = Tuple.Create("Hrvoje", "Horvat", "2000-07-06", new List<int> {1,3});


            var trips = new Dictionary<int, Tuple<string, double, double, double, double>>();
            trips[1] = Tuple.Create("2025-03-15", 350.0, 20.5, 1.60, 32.8);
            trips[2] = Tuple.Create("2025-03-18", 120.0, 8.0, 1.55, 12.4);
            trips[3] = Tuple.Create("2025-09-10", 100.0, 6.0, 1.45, 8.7);



            static int main_input()
            {
                Console.Write("Glavni izbornik \n \n Unesite broj za željenu opciju \n 1-Korisnici \n 2-Putovanja \n 0-Izlaz iz aplikacije \n \n Odabir:");
                var first_input = Console.ReadLine();
                while (!int.TryParse(first_input, out int number) || int.Parse(first_input) > 2 || int.Parse(first_input) < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Neispravan unos. Unesite opet.");
                    Console.Write("Unesite broj za željenu opciju \n 1-Korisnici \n 2-Putovanja \n 0-Izlaz iz aplikacije \n \n Odabir:");
                    first_input = Console.ReadLine();
                }

                return int.Parse(first_input);
            }

            static int users_input()
            {
                Console.Clear();
                Console.Write("Korisnici \n \n Unesite broj za željenu opciju \n 1-Unos novog korisnika \n 2-Brisanje korisnika \n 3-Uređivanje korisnika \n 4-Pregled svih korisnika \n 0-Povratak na glavni izbornik \n \n Odabir:");
                var input = Console.ReadLine();
                while (!int.TryParse(input, out int number) || int.Parse(input) > 4 || int.Parse(input) < 0)
                {
                    Console.Clear();
                    Console.WriteLine("\n Neispravan unos. Unesite opet. \n");
                    Console.Write("\n Unesite broj za željenu opciju \n 1-Unos novog korisnika \n 2-Brisanje korisnika \n 3-Uređivanje korisnika \n 4-Pregled svih korisnika \n 0-Povratak na glavni izbornik \n \n Odabir:");
                    input = Console.ReadLine();
                }
                return int.Parse(input);
            }

            void users_menu(int user_menu_input)
            {
                string id;
                switch (user_menu_input)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Unos novog korisnika");
                        Console.Write("Unesite ime:");
                        var name = Console.ReadLine();
                        Console.Write("Unesite prezime:");
                        var surname = Console.ReadLine();
                        Console.Write("Unesite datum rođenja:");
                        var dob = Console.ReadLine();

                        users.Add(users.Count()+1, Tuple.Create(name, surname, dob, new List<int>()));
                        Console.Write("Pritisnite bilo koju tipku za nastavak...");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Brisanje korisnika \n \n 1-Unos ID-a \n 2-Unos imena i prezimena \n \n Unos:");
                        var input_delete = Console.ReadLine();
                        while (!int.TryParse(input_delete, out int number) || int.Parse(input_delete) > 2 || int.Parse(input_delete) < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("\n Neispravan unos. Unesite opet. \n");
                            Console.Write("Unesite broj za željenu opciju \n 1-Unos ID-a \n 2-Unos imena i prezimena \n \n Unos:");
                            input_delete = Console.ReadLine();
                        }
                        if (int.Parse(input_delete) == 1)
                        {
                            Console.Write("Unesite ID:");
                            id = Console.ReadLine();
                            while (!int.TryParse(id, out int number) || int.Parse(id) > users.Count() || int.Parse(id) < 0)
                            {
                                Console.Clear();
                                Console.WriteLine("\n Neispravan unos. Unesite opet. \n");
                                Console.Write("Unos:");
                                id = Console.ReadLine();
                            }
                            Console.Write("Jeste li sigurni da želite izbrisati korisnika {0}? (y/n)", int.Parse(id));
                            if (Console.ReadLine() == "y")
                            {
                                users.Remove(int.Parse(id));
                                Console.Write("Uspješno izbrisan korisnik {0}", int.Parse(id));
                                Console.Write("Pritisnite bilo koju tipku za nastavak...");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.Clear();
                            }
                        }
                        else if (int.Parse(input_delete) == 2)
                        {
                            Console.Write("Unesite ime i prezime:");
                            var input_name = Console.ReadLine().Split(' ')[0];
                            var input_surname = Console.ReadLine().Split(' ')[1];

                            foreach (var entry in users)
                            {
                                var user = entry.Value; 
                                if (user.Item1.ToLower() == input_name.ToLower() && user.Item2.ToLower() == input_surname.ToLower())
                                {
                                    Console.Write("Jeste li sigurni da želite izbrisati korisnika {0} {1}? (y/n)", input_name, input_surname);
                                    if (Console.ReadLine() == "y")
                                    {
                                        //users.Remove(int.Parse(id));
                                        Console.Write("Uspješno izbrisan korisnik {0} {1}", input_name, input_surname);
                                        Console.Write("Pritisnite bilo koju tipku za nastavak...");
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Uneseni korisnik ne postoji.");
                                    Console.Write("Pritisnite bilo koju tipku za nastavak...");
                                    Console.ReadKey();
                                }
                            }


                        }
                            break;

                    case 3:
                        Console.Clear();
                        Console.Write("Uređivanje korisnika \n \n Unesite ID korisnika:");
                        id = Console.ReadLine();
                        while (!int.TryParse(id, out int number) || int.Parse(id) > users.Count() || int.Parse(id) < 0)
                        {
                            Console.WriteLine("\n Neispravan unos. Unesite opet. \n");
                            Console.Write("Unos:");
                            id = Console.ReadLine();
                        }
                        Console.Write("Jeste li sigurni da želite urediti korisnika {0}? (y/n)", int.Parse(id));
                        if (Console.ReadLine() == "y")
                        {
                            Console.Clear();
                            Console.Write("Unesite novo ime:");
                            var new_name = Console.ReadLine();
                            Console.Write("Unesite novo prezime:");
                            var new_surname = Console.ReadLine();
                            Console.Write("Unesite novi datum rođenja:");
                            var new_dob = Console.ReadLine();

                            users[int.Parse(id)] = Tuple.Create(new_name, new_surname, new_dob, users[int.Parse(id)].Item4);

                            Console.Write("Uspješno uređen korisnik {0}", int.Parse(id));
                        }
                        else
                        {
                            Console.Clear();
                            main_input();
                        }

                        break;

                    case 4:
                        Console.Clear();
                        Console.Write("Pregled svih korisnika \n \n 1-Ispis svih korisnika abecedno po prezimenu \n 2-Ispis svih korisnika iznad 20 godina \n 3-Ispis svih korisnika s 2 ili više putovanja \n \n Odabir:");
                        var overview_input = Console.ReadLine();
                        while (!int.TryParse(overview_input, out int number) || int.Parse(overview_input) > 3 || int.Parse(overview_input) < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("\n Neispravan unos. Unesite opet. \n");
                            Console.Write("1-Ispis svih korisnika abecedno po prezimenu \n 2-Ispis svih korisnika iznad 20 godina \n 3-Ispis svih korisnika s 2 ili više putovanja \n \n Odabir:");
                            overview_input = Console.ReadLine();
                        }
                        if (int.Parse(overview_input) == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Ispisi svih korisnika abecedno po prezimenu");
                            foreach (var user in users)
                            {
                                
                            }
                            Console.Write("Pritisnite bilo koju tipku za nastavak...");
                            Console.ReadKey();
                        }
                        else if (int.Parse(overview_input) == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("Ispis svih korisnika iznad 20 godina \n");

                            foreach (var user in users)
                            {
                                
                            }

                            Console.Write("Pritisnite bilo koju tipku za nastavak...");
                            Console.ReadKey();
                        }
                        else if (int.Parse(overview_input) == 3)
                        {
                            Console.Clear();
                            Console.WriteLine("Ispis svih korisnika s 2 ili više putovanja \n");

                            foreach (var user in users)
                            {
                                if (user.Value.Item4.Count() >= 2)
                                {
                                    Console.WriteLine("{0} - {1} - {2} - {3}",user.Key, user.Value.Item1, user.Value.Item2, user.Value.Item3);
                                }
                            }
                            Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                            Console.ReadKey();
                        }
                         break;

                    case 0:
                        Console.Clear();
                        break;
                }
            }

            static int trip_input()
            {
                Console.Clear();
                Console.Write("Putovanja\n \n Unesite broj za željenu opciju \n 1-Unos novog putovanja \n 2-Brisanje putovanja \n 3-Uređivanje postojećeg putovanja \n 4-Pregled svih putovanja \n 5-Izvještaji i analize \n 0-Povratak na glavni izbornik \n \n Odabir:");
                var input = Console.ReadLine();
                while (!int.TryParse(input, out int number) || int.Parse(input) > 5 || int.Parse(input) < 0)
                {
                    Console.Clear();
                    Console.WriteLine("\n Neispravan unos. Unesite opet. \n");
                    Console.Write("Putovanja\n \n Unesite broj za željenu opciju \n 1-Unos novog putovanja \n 2-Brisanje putovanja \n 3-Uređivanje postojećeg putovanja \n 4-Pregled svih putovanja \n 5-Izvještaji i analize \n 0-Povratak na glavni izbornik \n \n Odabir:");
                    input = Console.ReadLine();
                }
                return int.Parse(input);
            }

            void trip_menu(int trip_menu_input)
            {
                switch (trip_menu_input)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Unos novog putovanja");

                        Console.WriteLine("Ukupan trošak ovog putovanja je");
                        Console.Write("Pritisnite bilo koju tipku za nastavak...");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Brisanje putovanja \n \n 1-Unos ID-a \n 2-Putovanja skuplja od unesenog iznosa \n 3-Putovanja jeftinija od unesenog iznosa \n \n Odabir:");
                        var input_delete = Console.ReadLine();
                        while (!int.TryParse(input_delete, out int number) || int.Parse(input_delete) > 3 || int.Parse(input_delete) < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Neispravan unos. Unesite opet.");
                            Console.Write("Brisanje putovanja \n \n 1-Unos ID-a \n 2-Putovanja skuplja od unesenog iznosa \n 3-Putovanja jeftinija od unesenog iznosa \n \n Odabir:");
                            input_delete = Console.ReadLine();
                        }
                        if (int.Parse(input_delete) == 1)
                        {


                            Console.Write("Pritisnite bilo koju tipku za nastavak...");
                            Console.ReadKey();
                        }
                        else if (int.Parse(input_delete) == 2)
                        {


                            Console.Write("Pritisnite bilo koju tipku za nastavak...");
                            Console.ReadKey();
                        }
                        else if (int.Parse(input_delete) == 3)
                        {


                            Console.Write("Pritisnite bilo koju tipku za nastavak...");
                            Console.ReadKey();
                        }

                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("Uređivanje putovanja \n \n Unesite ID putovanja:");
                        var id = Console.ReadLine();
                        while (!int.TryParse(id, out int number) || int.Parse(id) > trips.Count() || int.Parse(id) < 0)
                        {
                            Console.WriteLine(" \n Neispravan unos. Unesite opet. \n");
                            Console.Write("Unos:");
                            id = Console.ReadLine();
                        }
                        Console.Write("Jeste li sigurni da želite urediti putovanje {0}? (y/n)", int.Parse(id));
                        if (Console.ReadLine() == "y")
                        {
                            Console.Write("Unesite novi datum:");
                            var new_date = Console.ReadLine();
                            Console.Write("Unesite novu kilometražu:");
                            var new_distance = double.Parse(Console.ReadLine());
                            Console.Write("Unesite novo gorivo:");
                            var new_gas = double.Parse(Console.ReadLine());
                            Console.Write("Unesite novu cijenu:");
                            var new_price = double.Parse(Console.ReadLine());

                            trips[int.Parse(id)] = Tuple.Create(new_date, new_distance, new_gas, new_price, new_price*new_gas);

                            Console.Write("Uspješno uređeno putovanje {0}", int.Parse(id));
                            Console.Write("Pritisnite bilo koju tipku za nastavak...");
                            Console.ReadKey();
                        }
                        else
                        {
                            main_input();
                        }
                        break;

                    case 4:
                        Console.Clear();
                        Console.Write("Pregled svih putovanja \n \n 1-Prema redoslijedu spremanja \n 2-Prema trošku uzlazno \n 3-Prema trošku silazno \n 4-Prema kilometraži uzlazno \n 5-Prema kilometraži silazno \n 6-Prema datumu uzlazno \n 7-Prema datumu silazno \n \n Odabir:");
                        var input_overview = Console.ReadLine();
                        while (!int.TryParse(input_overview, out int number) || int.Parse(input_overview) > 7 || int.Parse(input_overview) < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("\n Neispravan unos. Unesite opet. \n");
                            Console.Write("Pregled svih putovanja \n \n 1-Prema redoslijedu spremanja \n 2-Prema trošku uzlazno \n 3-Prema trošku silazno \n 4-Prema kilometraži uzlazno \n 5-Prema kilometraži silazno \n 6-Prema datumu uzlazno \n 7-Prema datumu silazno \n \n Odabir:");
                            input_overview = Console.ReadLine();
                        }

                        Console.Write("Pritisnite bilo koju tipku za nastavak...");
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Izvještaji i analize \n \n Izaberite korisnika");
                        foreach (var user in users)
                        {
                            Console.WriteLine("\n", user);
                        }
                        Console.Write("\n Odabir:");
                        id = Console.ReadLine();
                        while (!int.TryParse(id, out int number) || int.Parse(id) > users.Count() || int.Parse(id) < 0)
                        {
                            Console.WriteLine("\n Neispravan unos. Unesite opet. \n");
                            Console.Write("Unos:");
                            id = Console.ReadLine();
                        }
                        Console.Write("Odaberite želejni izvještaj \n \n 1-Ukupna potrošnja goriva \n 2-Ukupni troškovi goriva \n 3-Prosječna potrošnja goriva \n 4-Putovanje s najvećom potrošnjom goriva \n 5-Pregled putovanja po određenom datumu \n \n Odabir:");
                        var input_report = Console.ReadLine();
                        while (!int.TryParse(input_report, out int number) || int.Parse(input_report) > 5 || int.Parse(input_report) < 0)
                        {
                            Console.WriteLine("\n Neispravan unos. Unesite opet. \n");
                            Console.Write("Odabir:");
                            input_report = Console.ReadLine();
                        }
                        switch (int.Parse(input_report))
                        {
                            case 1:
                                var total_gas=0.0;
                                Console.WriteLine("Ukupna potrošnja goriva za korisnika {0} je {1} litara.", id, total_gas);
                                Console.Write("Pritisnite bilo koju tipku za nastavak...");
                                Console.ReadKey();
                                break;
                            case 2:
                                var total_cost = 0.0;
                                Console.WriteLine("Ukupni troškovi goriva za korisnika {0} su {1} €", id, total_cost);
                                Console.Write("Pritisnite bilo koju tipku za nastavak...");
                                Console.ReadKey();
                                break;
                            case 3:
                                var average_gas = 0.0;
                                Console.WriteLine("Prosječna potrošnja goriva za korisnika {0} je {1} litara", id, average_gas);
                                Console.Write("Pritisnite bilo koju tipku za nastavak...");
                                Console.ReadKey();
                                break;
                            case 4:
                                foreach (var item in users)
                                {
                                    
                                }
                                Console.WriteLine("Putovanje s najvećom potrošnjom goriva za korisnika je .");
                                Console.Write("Pritisnite bilo koju tipku za nastavak...");
                                Console.ReadKey();
                                break;
                            case 5:
                                Console.WriteLine("Pregled putovanja po određenom datumu");

                                Console.Write("Pritisnite bilo koju tipku za nastavak...");
                                Console.ReadKey();
                                break;
                        }

                        break;

                    case 0:
                        Console.Clear();
                        main_input();
                        break;
                }
            }

            bool inApp = true;
            while (inApp)
            {
                Console.Clear();
                var menu_input = main_input();
                if (menu_input == 1)
                {
                    users_menu(users_input());
                }
                else if (menu_input == 2)
                {
                    trip_menu(trip_input());
                }
                else if (menu_input == 0)
                {
                    Console.WriteLine("Izlazak iz aplikacije.");
                    inApp = false;
                }
            }
        }
    }
}
