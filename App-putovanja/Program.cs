using System;
using System.Globalization;
using System.Windows.Markup;

namespace App_putovanja
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var users = new Dictionary<int, Tuple<string, string, string>>();

            var trips = new Dictionary<int, Tuple<string, string, string, string, string>>();


            static int main_input()
            {
<<<<<<< Updated upstream
                Console.Write("Unesite broj za željenu opciju \n 1-Korisnici \n 2-Putovanja \n 0-Izlaz iz aplikacije \n \n Odabir:");
                var first_input = Console.ReadLine();
                while (!int.TryParse(first_input, out int number) || int.Parse(first_input) > 2 || int.Parse(first_input) < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Neispravan unos. Unesite opet.");
                    Console.Write("Unesite broj za željenu opciju \n 1-Korisnici \n 2-Putovanja \n 0-Izlaz iz aplikacije \n \n Odabir:");
                    first_input = Console.ReadLine();
                }
=======
                Console.Write("Glavni izbornik \n \n ");
                var menu_text = "Unesite broj za željenu opciju \n 1-Korisnici \n 2-Putovanja \n 0-Izlaz iz aplikacije";
>>>>>>> Stashed changes

                var first_input = input_valid(menu_text, 2);

                return first_input;
            }

            var menu_input = main_input();

            static int users_input()
            {
                Console.Clear();
<<<<<<< Updated upstream
                Console.Write("Korisnici \n \n Unesite broj za željenu opciju \n 1-Unos novog korisnika \n 2-Brisanje korisnika \n 3-Uređivanje korisnika \n 4-Pregled svih korisnika \n 0-Povratak na glavni izbornik \n \n Odabir:");
                var input = Console.ReadLine();
                while (!int.TryParse(input, out int number) || int.Parse(input) > 4 || int.Parse(input) < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Neispravan unos. Unesite opet.");
                    Console.Write("\n Unesite broj za željenu opciju \n 1-Unos novog korisnika \n 2-Brisanje korisnika \n 3-Uređivanje korisnika \n 4-Pregled svih korisnika \n 0-Povratak na glavni izbornik \n \n Odabir:");
                    input = Console.ReadLine();
                }
                return int.Parse(input);
            }

            void users_menu(int user_menu_input)
=======
                var menu_text = "Unesite broj za željenu opciju \n 1-Unos novog korisnika \n 2-Brisanje korisnika \n 3-Uređivanje korisnika \n 4-Pregled svih korisnika \n 0-Povratak na glavni izbornik";
                Console.Write("Korisnici \n \n");

                var u_input = input_valid(menu_text, 4);

                return u_input;
            }

            static int trip_input()
            {
                Console.Clear();
                Console.Write("Putovanja \n \n ");
                var menu_text = "Unesite broj za željenu opciju \n 1-Unos novog putovanja \n 2-Brisanje putovanja \n 3-Uređivanje postojećeg putovanja \n 4-Pregled svih putovanja \n 5-Izvještaji i analize \n 0-Povratak na glavni izbornik";
                var input = input_valid(menu_text, 5);
                return input;
            }

            static string date_valid(string date_input)
            {
                while (!DateTime.TryParse(date_input, out DateTime date) || date.Year > 2025)
                {
                    Console.Write("Neispravan unos. \n Unesite opet:");
                    date_input = Console.ReadLine(); 
                }
                return date_input;
            }

            static double number_valid(string number_input) 
>>>>>>> Stashed changes
            {
                while (!double.TryParse(number_input, out double number) || double.Parse(number_input) < 0)
                {
<<<<<<< Updated upstream
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Unos novog korisnika");
                        Console.Write("Unesite ime:");
                        var name = Console.ReadLine();
                        Console.Write("Unesite prezime:");
                        var surname = Console.ReadLine();
                        Console.Write("Unesite datum rođenja:");
                        var dob = Console.ReadLine();

                        users.Add(2, Tuple.Create(name, surname, dob));

                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Brisanje korisnika \n \n 1-Unos ID-a \n 2-Unos imena i prezimena \n \n Unos:");
                        var input_delete = Console.ReadLine();
                        while (!int.TryParse(input_delete, out int number) || int.Parse(input_delete) > 2 || int.Parse(input_delete) < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Neispravan unos. Unesite opet.");
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
                                Console.WriteLine("Neispravan unos. Unesite opet.");
                                Console.Write("Unos:");
                                id = Console.ReadLine();
                            }
                            Console.Write("Jeste li sigurni da želite izbrisati korisnika {0}? (y/n)", int.Parse(id));
                            if (Console.ReadLine() == "y")
                            {
                                users.Remove(int.Parse(id));
                                Console.Write("Uspješno izbrisan korisnik {0}", int.Parse(id));
                            }
                            else
                            {
                                Console.Clear();
                                main_input();
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
                                    }
                                    else
                                    {
                                        main_input();
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Uneseni korisnik ne postoji.");
                                    main_input();
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
                            Console.Clear();
                            Console.WriteLine("Neispravan unos. Unesite opet.");
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

                            users[int.Parse(id)] = Tuple.Create(new_name, new_surname, new_dob);

                            Console.Write("Uspješno uređen korisnik {0}", int.Parse(id));
                        }
                        else
                        {
                            Console.Clear();
                            main_input();
                        }

                        break;

                    case 4:
                        Console.Write("Pregled svih korisnika \n \n 1-Ispis svih korisnika abecedno po prezimenu \n 2-Ispis svih korisnika iznad 20 godina \n 3-Ispis svih korisnika s 2 ili više putovanja \n \n Odabir:");
                        var overview_input = Console.ReadLine();
                        while (!int.TryParse(overview_input, out int number) || int.Parse(overview_input) > 3 || int.Parse(overview_input) < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Neispravan unos. Unesite opet.");
                            Console.Write("1-Ispis svih korisnika abecedno po prezimenu \n 2-Ispis svih korisnika iznad 20 godina \n 3-Ispis svih korisnika s 2 ili više putovanja \n \n Odabir:");
                            overview_input = Console.ReadLine();
                        }
                        if (int.Parse(overview_input) == 1)
                        {

                        }
                        else if (int.Parse(overview_input) == 2)
                        {

                        }
                        else if (int.Parse(overview_input) == 3)
                        {

                        }
                         break;

                    case 0:
                        Console.Clear();
                        main_input();
                        break;
=======
                    Console.Write("\n Neispravan unos. \n Unesite opet:");
                    number_input = Console.ReadLine();
>>>>>>> Stashed changes
                }
                return double.Parse(number_input);
            }

            static int input_valid(string text, int count)
            {
                Console.WriteLine("{0} \n \n Odabir:", text);
                var input_input = Console.ReadLine();
                while (!int.TryParse(input_input, out int number) || int.Parse(input_input) > count || int.Parse(input_input) < 0)
                {
<<<<<<< Updated upstream
                    Console.Clear();
                    Console.WriteLine("Neispravan unos. Unesite opet.");
                    Console.Write("Putovanja\n \n Unesite broj za željenu opciju \n 1-Unos novog putovanja \n 2-Brisanje putovanja \n 3-Uređivanje postojećeg putovanja \n 4-Pregled svih putovanja \n 5-Izvještaji i analize \n 0-Povratak na glavni izbornik \n \n Odabir:");
                    input = Console.ReadLine();
=======
                    Console.WriteLine("\n Neispravan unos. Unesite opet. \n");
                    if (text == "0") { Console.Write("\n \n Odabir:"); }
                    else { Console.Write("\n {0} \n \n Odabir:", text); }
                    input_input = Console.ReadLine();
>>>>>>> Stashed changes
                }
                return int.Parse(input_input);
            }

            static string name_valid(string name_input)
            {
                bool valid = name_input.All(Char.IsLetter);
                while (valid == false)
                {
                    Console.WriteLine("\n Neispravan unos. Unesite opet. \n");
                    name_input = Console.ReadLine();
                    valid = name_input.All(Char.IsLetter);
                }
                name_input = char.ToUpper(name_input[0]) + name_input.Substring(1).ToLower();
                return name_input;
            }

<<<<<<< Updated upstream
=======
            static void list_trips(List<KeyValuePair<int, Tuple<string, double, double, double, double>>> user_trips)
            {
                foreach (var trip in user_trips)
                {
                    Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", trip.Key, trip.Value.Item1, trip.Value.Item2, trip.Value.Item3, trip.Value.Item4, trip.Value.Item5);
                }
                Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                Console.ReadKey();
            }


            void users_menu(int user_menu_input)
            {
                int id;
                string menu_text;
                switch (user_menu_input)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Unos novog korisnika \n");
                        Console.Write("Unesite ime: ");
                        var name = name_valid(Console.ReadLine());
                        Console.Write("Unesite prezime: ");
                        var surname = name_valid(Console.ReadLine());
                        Console.Write("Unesite datum rođenja: ");
                        var dob = date_valid(Console.ReadLine());

                        users.Add(users.Count()+1, Tuple.Create(name, surname, dob, new List<int>()));
                        Console.Write("\n Uspješno dodan novi korisnik. \n Pritisnite bilo koju tipku za nastavak...");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Brisanje korisnika \n \n ");
                        menu_text = "1-Unos ID-a \n 2-Unos imena i prezimena";

                        var input_delete = input_valid(menu_text,2);

                        if (input_delete == 1)
                        {
                            Console.Write("Unesite ID:");
                            id = input_valid("0", users.Count());

                            Console.Clear();
                            Console.Write("Jeste li sigurni da želite izbrisati korisnika {0}? (y/n)", id);
                            if (Console.ReadLine().ToLower() == "y" || Console.ReadLine().ToLower() == "yes" || Console.ReadLine().ToLower() == "da")
                            {
                                users.Remove(id);
                                Console.Write("\n Uspješno izbrisan korisnik {0} {1}", users[id].Item1, users[id].Item2);
                            }
                            else
                            {
                                Console.WriteLine("\n Brisanje otkazano.");
                            }
                            Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                            Console.ReadKey();
                        }
                        else if (input_delete == 2)
                        {
                            Console.Write("Unesite ime i prezime:");
                            var input_name = name_valid(Console.ReadLine().Split(' ')[0]);
                            var input_surname = name_valid(Console.ReadLine().Split(' ')[1]);
                            
                            var match = users.FirstOrDefault(u => string.Equals(u.Value.Item1, input_name, StringComparison.OrdinalIgnoreCase) && string.Equals(u.Value.Item2, input_surname, StringComparison.OrdinalIgnoreCase));

                            if (match.Equals(default(KeyValuePair<int, Tuple<string, string, string, List<int>>>)))
                            {
                                Console.WriteLine("\n Uneseni korisnik ne postoji.");
                            }
                            else
                            {
                                Console.Write("\n Jeste li sigurni da želite izbrisati korisnika {0} {1}? (y/n): ", input_name, input_surname);

                                if (Console.ReadLine().ToLower() == "y" || Console.ReadLine().ToLower() == "yes" || Console.ReadLine().ToLower() == "da")
                                {
                                    users.Remove(match.Key);
                                    Console.WriteLine("\n Uspješno izbrisan korisnik {0} {1}", input_name, input_surname);
                                }
                                else
                                {
                                    Console.WriteLine("\n Brisanje otkazano.");
                                }
                            }
                            Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                            Console.ReadKey();
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("Uređivanje korisnika \n \n Unesite ID korisnika:");
                        id = input_valid("0", users.Count());

                        Console.Write("\n Jeste li sigurni da želite urediti korisnika {0} - {1} - {2} - {3} (y/n)?", id, users[id].Item1, users[id].Item2, users[id].Item3);
                        if (Console.ReadLine().ToLower() == "y" || Console.ReadLine().ToLower() == "yes" || Console.ReadLine().ToLower() == "da")
                        {
                            Console.Write("\n Unesite novo ime:");
                            var new_name = name_valid(Console.ReadLine());
                            Console.Write("Unesite novo prezime:");
                            var new_surname = name_valid(Console.ReadLine());
                            Console.Write("Unesite novi datum rođenja:");
                            var new_dob = date_valid(Console.ReadLine());

                            users[id] = Tuple.Create(new_name, new_surname, new_dob, users[id].Item4);

                            Console.Write("Uspješno uređen korisnik {0} - {1} - {2} - {3} .", id, users[id].Item1, users[id].Item2, users[id].Item3);
                        }
                        else
                        {
                            Console.WriteLine("Uređivanje otkazano.");
                        }
                        Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Clear();
                        Console.Write("Pregled svih korisnika \n \n");
                        menu_text = "1-Ispis svih korisnika abecedno po prezimenu \n 2-Ispis svih korisnika iznad 20 godina \n 3-Ispis svih korisnika s 2 ili više putovanja";
                        var overview_input = input_valid(menu_text,3);

                        if (overview_input == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Ispisi svih korisnika abecedno po prezimenu");

                            var user_list = new List<KeyValuePair<int, Tuple<string, string, string, List<int>>>>(users);

                            user_list.Sort((a, b) => string.Compare(a.Value.Item2, b.Value.Item2, StringComparison.OrdinalIgnoreCase));

                            foreach (var user in user_list)
                            {
                                Console.WriteLine("{0} - {1} - {2} - {3}", user.Key, user.Value.Item1, user.Value.Item2, user.Value.Item3);
                            }
                        }
                        else if (overview_input == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("Ispis svih korisnika iznad 20 godina \n");

                            foreach (var user in users)
                            {
                                if ((DateTime.Now.Year - DateTime.Parse(user.Value.Item3).Year) > 19)
                                {
                                    Console.WriteLine("{0} - {1} - {2} - {3}", user.Key, user.Value.Item1, user.Value.Item2, user.Value.Item3);
                                }
                            }
                        }
                        else if (overview_input == 3)
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
                        }
                        Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                        Console.ReadKey();
                        break;

                    case 0:
                        Console.Clear();
                        break;
                }
            }



>>>>>>> Stashed changes
            void trip_menu(int trip_menu_input)
            {
                string menu_text;
                switch (trip_menu_input)
                {
                    case 1:
                        Console.Clear();
<<<<<<< Updated upstream
                        Console.Write("Unos novog putovanja");
=======
                        Console.Write("Unos novog putovanja \n \n Unesite datum: ");
                        var date = date_valid(Console.ReadLine());
                        Console.Write("Unesite udaljenost u kilometrima: ");
                        var distance = number_valid(Console.ReadLine());
                        Console.Write("Unesite gorivo u litrama: ");
                        var gas = number_valid(Console.ReadLine());
                        Console.Write("Unesite cijenu goriva po litri u eurima: ");
                        var price = number_valid(Console.ReadLine());
>>>>>>> Stashed changes

                        Console.WriteLine("Ukupan trošak ovog putovanja je");

<<<<<<< Updated upstream
=======
                        Console.WriteLine("\n Ukupan trošak ovog putovanja je {0} eura.", Math.Round(gas*price,2));
                        Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                        Console.ReadKey();
>>>>>>> Stashed changes
                        break;

                    case 2:
                        Console.Clear();
<<<<<<< Updated upstream
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

=======
                        Console.Write("Brisanje putovanja");
                        menu_text = "1-Unos ID-a \n 2-Putovanja s većim troškovima od unesenog iznosa \n 3-Putovanja s manjim troškovima od unesenog iznosa";
                        var input_delete = input_valid(menu_text,3);

                        if (input_delete == 1)
                        {
                            Console.Clear();
                            Console.Write("Unesite ID putovanje koje želite izbrisati:");
                            var id_remove = Console.ReadLine();
                            trips.Remove(int.Parse(id_remove));

                            Console.Write("\n Uspješno izbrisano putovanje {0}.", id_remove);
>>>>>>> Stashed changes
                        }
                        else if (input_delete == 2)
                        {
<<<<<<< Updated upstream

=======
                            Console.Clear();
                            Console.Write("Brisanje putovanja s većim troškovima od određenog iznosa \n Unesite iznos:");
                            var ammount = number_valid(Console.ReadLine());

                            Console.Write("Jeste li sigurni da želite izbrisati putovanja s većim troškovima od {0} eura? (y/n)", ammount);
                            if (Console.ReadLine().ToLower() == "y" || Console.ReadLine().ToLower() == "yes" || Console.ReadLine().ToLower() == "da")
                            {
                                foreach (var trip in trips)
                                {
                                    if (trip.Value.Item5 > ammount)
                                    {
                                        trips.Remove(trip.Key);
                                    }
                                }
                                Console.Write("\n Uspjesno izbrisana putovanja s troškovima većim do {0} eura.", ammount);
                            }
                            else
                            {
                                Console.WriteLine("\n Otkazivanje brisanja.");
                            };
>>>>>>> Stashed changes
                        }
                        else if (input_delete == 3)
                        {
<<<<<<< Updated upstream

=======
                            Console.Clear();
                            Console.Write("Brisanje putovanja s manjim troškovima od određenog iznosa \n Unesite iznos:");
                            var ammount = number_valid(Console.ReadLine());

                            Console.Write("Jeste li sigurni da želite izbrisati putovanja s manjim troškovima od {0} eura? (y/n)", ammount);
                            if (Console.ReadLine().ToLower() == "y" || Console.ReadLine().ToLower() == "yes" || Console.ReadLine().ToLower() == "da")
                            {
                                foreach (var trip in trips)
                                {
                                    if (trip.Value.Item5 < ammount)
                                    {
                                        trips.Remove(trip.Key);
                                    }
                                }
                                Console.Write("\n Uspjesno izbrisana putovanja s troškovima manjim do {0} eura.", ammount);
                            }
                            else
                            {
                                Console.WriteLine("\n Otkazivanje brisanja.");
                            }
>>>>>>> Stashed changes
                        }
                        Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("Uređivanje putovanja \n \n Unesite ID putovanja:");
<<<<<<< Updated upstream
                        var id = Console.ReadLine();
                        while (!int.TryParse(id, out int number) || int.Parse(id) > trips.Count() || int.Parse(id) < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Neispravan unos. Unesite opet.");
                            Console.Write("Unos:");
                            id = Console.ReadLine();
                        }
                        Console.Write("Jeste li sigurni da želite urediti putovanje {0}? (y/n)", int.Parse(id));
                        if (Console.ReadLine() == "y")
=======
                        var id = input_valid("0", trips.Count());

                        Console.Write("Jeste li sigurni da želite urediti putovanje {0}? (y/n)", id);
                        if (Console.ReadLine().ToLower() == "y" || Console.ReadLine().ToLower() == "yes" || Console.ReadLine().ToLower() == "da")
>>>>>>> Stashed changes
                        {
                            Console.Clear();
                            Console.Write("Unesite novoi datum:");
                            var new_date = Console.ReadLine();
                            Console.Write("Unesite novu kilometražu:");
<<<<<<< Updated upstream
                            var new_distance = Console.ReadLine();
                            Console.Write("Unesite novo gorivo:");
                            var new_gas = Console.ReadLine();
                            Console.Write("Unesite novu cijenu:");
                            var new_price = Console.ReadLine();

                            //trips[int.Parse(id)] = Tuple.Create(new_date, new_distance, new_gas, new_price);

                            Console.Write("Uspješno uređen putovanje {0}", int.Parse(id));
=======
                            var new_distance = number_valid(Console.ReadLine());
                            Console.Write("Unesite novo gorivo:");
                            var new_gas = number_valid(Console.ReadLine());
                            Console.Write("Unesite novu cijenu:");
                            var new_price = number_valid(Console.ReadLine());

                            trips[id] = Tuple.Create(new_date, new_distance, new_gas, new_price, new_price*new_gas);

                            Console.Write("\n Uspješno uređeno putovanje {0}.", id); 
>>>>>>> Stashed changes
                        }
                        else
                        {
                            Console.WriteLine("\n Otkazivanje uređivanja putovanja.");
                        }
                        Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Clear();
<<<<<<< Updated upstream
                        Console.Write("Pregled svih putovanja \n \n 1-Prema redoslijedu spremanja \n 2-Prema trošku uzlazno \n 3-Prema trošku silazno \n 4-Prema kilometraži uzlazno \n 5-Prema kilometraži silazno \n 6-Prema datumu uzlazno \n 7-Prema datumu silazno \n \n Odabir:");
                        var input_overview = Console.ReadLine();
                        while (!int.TryParse(input_overview, out int number) || int.Parse(input_overview) > 7 || int.Parse(input_overview) < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Neispravan unos. Unesite opet.");
                            Console.Write("Pregled svih putovanja \n \n 1-Prema redoslijedu spremanja \n 2-Prema trošku uzlazno \n 3-Prema trošku silazno \n 4-Prema kilometraži uzlazno \n 5-Prema kilometraži silazno \n 6-Prema datumu uzlazno \n 7-Prema datumu silazno \n \n Odabir:");
                            input_overview = Console.ReadLine();
                        }
=======
                        Console.Write("Pregled svih putovanja \n \n ");
                        menu_text = "1-Prema redoslijedu spremanja \n 2-Prema trošku uzlazno \n 3-Prema trošku silazno \n 4-Prema kilometraži uzlazno \n 5-Prema kilometraži silazno \n 6-Prema datumu uzlazno \n 7-Prema datumu silazno";
                        var input_overview = input_valid(menu_text, 7);

                        var trip_list = new List<KeyValuePair<int, Tuple<string, double, double, double, double>>>(trips);

                        switch (input_overview)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Ispis svih putovanja prema redoslijedu spremanja \n \n");
                                foreach (var trip in trips)
                                {
                                    Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", trip.Key, trip.Value.Item1, trip.Value.Item2, trip.Value.Item3, trip.Value.Item4, trip.Value.Item5);
                                }
                                break;

                            case 2:
                                Console.Clear();
                                Console.WriteLine("Ispis svih potovanja prema trošku uzlazno \n \n");

                                trip_list.Sort((a, b) => a.Value.Item5.CompareTo(b.Value.Item5));
                                list_trips(trip_list);
                                break;

                            case 3:
                                Console.Clear();
                                Console.WriteLine("Ispis svih potovanja prema trošku silazno \n \n");

                                trip_list.Sort((a, b) => b.Value.Item5.CompareTo(a.Value.Item5));
                                list_trips(trip_list);
                                break;

                            case 4:
                                Console.Clear();
                                Console.WriteLine("Ispis svih potovanja prema kilometraži uzlazno \n \n");

                                trip_list.Sort((a, b) => a.Value.Item2.CompareTo(b.Value.Item2));
                                list_trips(trip_list);
                                break;

                            case 5:
                                Console.Clear();
                                Console.WriteLine("Ispis svih potovanja prema kilometraži silazno \n \n");

                                trip_list.Sort((a, b) => b.Value.Item2.CompareTo(a.Value.Item2));
                                list_trips(trip_list);
                                break;

                            case 6:
                                Console.Clear();
                                Console.WriteLine("Ispis svih potovanja prema datumu uzlazno \n \n");

                                trip_list.Sort((a, b) => DateTime.Parse(a.Value.Item1).CompareTo(DateTime.Parse(b.Value.Item1)));
                                list_trips(trip_list);
                                break;

                            case 7:
                                Console.Clear();
                                Console.WriteLine("Ispis svih potovanja prema datumu silazno \n \n");

                                trip_list.Sort((a, b) => DateTime.Parse(b.Value.Item1).CompareTo(DateTime.Parse(a.Value.Item1)));
                                list_trips(trip_list);
                                break;
                        }
                        Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                        Console.ReadKey();
>>>>>>> Stashed changes
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Izvještaji i analize \n \n Izaberite korisnika");
                        foreach (var item in users)
                        {
                            Console.WriteLine("\n", item);
                        }
                        Console.Write("\n Odabir:");
<<<<<<< Updated upstream
                        id = Console.ReadLine();
                        while (!int.TryParse(id, out int number) || int.Parse(id) > users.Count() || int.Parse(id) < 0)
                        {
                            Console.WriteLine("Neispravan unos. Unesite opet.");
                            Console.Write("Unos:");
                            id = Console.ReadLine();
                        }
                        Console.Write("Odaberite želejni izvještaj \n \n 1-Ukupna potrošnja goriva \n 2-Ukupni troškovi goriva \n 3-Prosječna potrošnja goriva \n 4-Putovanje s najvećom potrošnjom goriva \n 5-Pregled putovanja po određenom datumu \n \n Odabir:");
                        var input_report = Console.ReadLine();
                        while (!int.TryParse(input_report, out int number) || int.Parse(input_report) > 5 || int.Parse(input_report) < 0)
                        {
                            Console.WriteLine("Neispravan unos. Unesite opet.");
                            Console.Write("Odabir:");
                            input_report = Console.ReadLine();
                        }
                        switch (int.Parse(input_report))
                        {
                            case 1:
                                var total_gas=0.0;
                                Console.WriteLine("Ukupna potrošnja goriva za korisnika {0} je {1} litara.", id, total_gas);
=======
                        id = input_valid("0", users.Count());


                        Console.Write("\n Odaberite željeni izvještaj \n \n ");
                        menu_text = "1-Ukupna potrošnja goriva \n 2-Ukupni troškovi goriva \n 3-Prosječna potrošnja goriva \n 4-Putovanje s najvećom potrošnjom goriva \n 5-Pregled putovanja po određenom datumu";
                        var input_report = input_valid(menu_text,5);

                        var user_trips = users[id].Item4;

                        double total_gas = 0.0;
                        var total_cost = 0.0;

                        foreach (var trip in user_trips){ total_gas += trips[trip].Item3; }   
                        foreach (var trip in user_trips){ total_cost += trips[trip].Item5; }

                        switch (input_report)
                        {
                            case 1:
                                Console.WriteLine("\n Ukupna potrošnja goriva za korisnika {0} je {1} litara.", id, Math.Round(total_gas,2));
>>>>>>> Stashed changes
                                break;

                            case 2:
<<<<<<< Updated upstream
                                var total_cost = 0.0;
                                Console.WriteLine("Ukupni troškovi goriva za korisnika {0} su {1} €", id, total_cost);
=======
                                Console.WriteLine("\n Ukupni troškovi goriva za korisnika {0} su {1} eura.", id, Math.Round(total_cost,2));
>>>>>>> Stashed changes
                                break;

                            case 3:
<<<<<<< Updated upstream
                                var average_gas = 0.0;
                                Console.WriteLine("Prosječna potrošnja goriva za korisnika {0} je {1} litara", id, average_gas);
=======
                                var average_gas = (total_gas / total_cost)*100;
                                Console.WriteLine("\n Prosječna potrošnja goriva za korisnika {0} je {1} L/100 km.", id, Math.Round(average_gas, 2));
>>>>>>> Stashed changes
                                break;

                            case 4:
                                foreach (var item in users)
                                {
<<<<<<< Updated upstream
                                    
                                }
                                Console.WriteLine("Putovanje s najvećom potrošnjom goriva za korisnika je .");
=======
                                    double spent_gas = trips[trip_id].Item3;
                                    if (spent_gas > max_gas) {max_gas = spent_gas; max_id = trip_id; }

                                }
                                if (max_id != -1) { Console.WriteLine("\n Putovanje s najvećom potrošnjom goriva za korisnika {0} je {1} s potrošnjom od {2} L.", id, max_id, Math.Round(max_gas,2)); }
                                else { Console.WriteLine("Korisnik nema unesenih putovanja."); }
>>>>>>> Stashed changes
                                break;

                            case 5:
<<<<<<< Updated upstream
                                Console.WriteLine("Pregled putovanja po određenom datumu");
                                break;
                        }

=======
                                Console.Write("\n Pregled putovanja po određenom datumu \n \n Unesite željeni datum:");
                                var date_search = date_valid(Console.ReadLine());

                                bool found = false; 

                                foreach (var trip_id in user_trips)
                                {
                                    DateTime trip_date = DateTime.Parse(trips[trip_id].Item1);
                                    if (trip_date == DateTime.Parse(date_search))
                                    {
                                        found = true;
                                        Console.WriteLine("\n Pronađena putovanja s unesenim datumom:");
                                        Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", trip_id, trips[trip_id].Item1, trips[trip_id].Item2, trips[trip_id].Item3, trips[trip_id].Item4, trips[trip_id].Item5);
                                    }
                                }
                                if (found == false) { Console.WriteLine("Ne postoji putovanje s unesenim datumom."); }
                                break;
                        }
                        Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                        Console.ReadKey();
>>>>>>> Stashed changes
                        break;

                    case 0:
                        break;
                }
            }

<<<<<<< Updated upstream
            switch (menu_input)
=======

            bool inApp = true;
            while (inApp)
>>>>>>> Stashed changes
            {
                case 1:
                    users_menu(users_input());
                    break;

                case 2:
                    trip_menu(trip_input());
                    break;

                case 0:
                    Console.Clear();
                    Console.Write("Izlazak iz aplikacije");
                    break;
            }
        }
    }
}
