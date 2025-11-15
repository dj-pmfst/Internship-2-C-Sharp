using System;
using System.Globalization;
using System.Windows.Markup;
using static System.Net.Mime.MediaTypeNames;

namespace App_putovanja
{
    internal class Program
    {
        static void Main(string[] args)
        {

            static int main_input()
            {
                Console.Write("Glavni izbornik \n \n ");
                var menu_text = "Unesite broj za željenu opciju " +
                    "\n 1-Korisnici \n 2-Putovanja " +
                    "\n 0-Izlaz iz aplikacije";

                var first_input = input_valid(menu_text, 2);

                return first_input;
            }

            static int users_input()
            {
                Console.Clear();
                var menu_text = "Unesite broj za željenu opciju " +
                    "\n 1-Unos novog korisnika \n 2-Brisanje korisnika " +
                    "\n 3-Uređivanje korisnika \n 4-Pregled svih korisnika " +
                    "\n 0-Povratak na glavni izbornik";
                Console.Write("Korisnici \n \n");

                var u_input = input_valid(menu_text, 4);

                return u_input;
            }

            static int trip_input()
            {
                Console.Clear();
                Console.Write("Putovanja \n \n ");
                var menu_text = "Unesite broj za željenu opciju " +
                    "\n 1-Unos novog putovanja \n 2-Brisanje putovanja " +
                    "\n 3-Uređivanje postojećeg putovanja \n 4-Pregled svih putovanja " +
                    "\n 5-Izvještaji i analize \n 0-Povratak na glavni izbornik";
                var input = input_valid(menu_text, 5);
                return input;
            }

            static string date_valid(string date_input)
            {
                while (!DateTime.TryParse(date_input, out DateTime date) || date.Year > 2025)
                {
                    Console.Write("\nNeispravan unos. \nUnesite opet:");
                    date_input = Console.ReadLine(); 
                }
                return date_input;
            }

            static double number_valid(string number_input) 
            {
                while (!double.TryParse(number_input, out double number) || double.Parse(number_input) < 0)
                {
                    Console.Write("\n Neispravan unos. \n Unesite opet: ");
                    number_input = Console.ReadLine();
                }
                return double.Parse(number_input);
            }

            static int input_valid(string text, int count)
            {
                if (text == "0") { Console.Write("\n\nOdabir: "); }
                else { Console.Write("{0}\n\nOdabir: ", text); }

                var input_input = Console.ReadLine();

                while (!int.TryParse(input_input, out int number) || int.Parse(input_input) > count || int.Parse(input_input) < 0)
                {
                    Console.Write("\n Neispravan unos. Unesite opet.");

                    if (text == "0") { Console.Write("\n\nOdabir: "); }
                    else { Console.Write("\n {0}\n\nOdabir: ", text); }

                    input_input = Console.ReadLine();
                }
                return int.Parse(input_input);
            }

            static string name_valid(string name_input, string type)
            {
                bool valid = name_input.All(Char.IsLetter);
                while (valid == false)
                {
                    Console.WriteLine("\nNeispravan unos. Unesite opet. \n");
                    if (type == "name") { Console.Write("\n\nUnesite ime: "); }
                    else if (type == "surname"){ Console.Write("\n\nUnesite prezime: "); }
                    name_input = Console.ReadLine();
                    valid = name_input.All(Char.IsLetter);
                }
                name_input = char.ToUpper(name_input[0]) + name_input.Substring(1).ToLower();
                return name_input;
            }

            static void list_trips(List<KeyValuePair<int, Tuple<string, double, double, double, double>>> user_trips)
            {
                foreach (var trip in user_trips)
                {
                    Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", 
                        trip.Key, trip.Value.Item1, trip.Value.Item2, trip.Value.Item3, trip.Value.Item4, 
                        Math.Round(trip.Value.Item5,2));
                }
                Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                Console.ReadKey();
            }


            static void user_delete_id(Dictionary<int, Tuple<string, string, string, List<int>>> user_list)
            {
                Console.Write("Unesite ID.");
                var id = input_valid("0", user_list.Count()-1);

                Console.Write("Jeste li sigurni da želite izbrisati korisnika {0}? (y/n)", id);
                string confirm = Console.ReadLine();
                if (confirm.ToLower() == "y" || confirm.ToLower() == "yes" || confirm.ToLower() == "da")
                {
                    user_list.Remove(id);
                    Console.Write("\n Uspješno izbrisan korisnik {0} {1}", 
                        user_list[id].Item1, user_list[id].Item2);
                }
                else
                {
                    Console.WriteLine("\n Brisanje otkazano.");
                }
                Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                Console.ReadKey();
            }

            static void user_delete_name(Dictionary<int, Tuple<string, string, string, List<int>>> user_list)
            {
                Console.Write("Unesite ime: ");
                var input_name = name_valid(Console.ReadLine(), "name");
                Console.Write("Unesite prezime: ");
                var input_surname = name_valid(Console.ReadLine(), "surname");

                var match = user_list.FirstOrDefault(u => string.Equals(u.Value.Item1.Trim(), input_name.Trim(), 
                    StringComparison.OrdinalIgnoreCase) && string.Equals(u.Value.Item2.Trim(), input_surname.Trim(), 
                    StringComparison.OrdinalIgnoreCase));

                if (match.Equals(default(KeyValuePair<int, Tuple<string, string, string, List<int>>>)))
                {
                    Console.WriteLine("\n Uneseni korisnik ne postoji.");
                }
                else
                {
                    Console.Write("\n Jeste li sigurni da želite izbrisati korisnika {0} {1}? (y/n): ", input_name, input_surname);

                    var confirmation = Console.ReadLine();
                    if (confirmation.ToLower() == "y" || confirmation.ToLower() == "yes" || confirmation.ToLower() == "da")
                    {
                        user_list.Remove(match.Key);
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

            static void user_edit(Dictionary<int, Tuple<string, string, string, List<int>>> user_list, string confirm, int id)
            {
                if (confirm.ToLower() == "y" || confirm.ToLower() == "yes" || confirm.ToLower() == "da")
                {
                    Console.WriteLine("\n");
                    Console.Write("Unesite novo ime:");
                    var new_name = name_valid(Console.ReadLine(), "name");
                    Console.Write("Unesite novo prezime:");
                    var new_surname = name_valid(Console.ReadLine(), "surname");
                    Console.Write("Unesite novi datum rođenja:");
                    var new_dob = date_valid(Console.ReadLine());

                    user_list[id] = Tuple.Create(new_name, new_surname, new_dob, user_list[id].Item4);
                    Console.WriteLine("\n");
                    Console.Write("Uspješno uređen korisnik {0} - {1} - {2} - {3} .", 
                        id, user_list[id].Item1, user_list[id].Item2, user_list[id].Item3);
                }
                else
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Uređivanje otkazano.");
                }
                Console.Write("\nPritisnite bilo koju tipku za nastavak...");
                Console.ReadKey();
            }

            static void user_sort_alphabet(Dictionary<int, Tuple<string, string, string, List<int>>> users_list)
            {
                Console.Clear();
                Console.WriteLine("Ispisi svih korisnika abecedno po prezimenu \n");

                var user_list = new List<KeyValuePair<int, Tuple<string, string, string, List<int>>>>(users_list);

                user_list.Sort((a, b) => string.Compare(a.Value.Item2, b.Value.Item2, StringComparison.OrdinalIgnoreCase));

                foreach (var user in user_list)
                {
                    Console.WriteLine("{0} - {1} - {2} - {3}", 
                        user.Key, user.Value.Item1, user.Value.Item2, user.Value.Item3);
                }
            }

            static void user_sort_over20 (Dictionary<int, Tuple<string, string, string, List<int>>> user_list)
            {
                Console.Clear();
                Console.WriteLine("Ispis svih korisnika iznad 20 godina \n");

                foreach (var user in user_list)
                {
                    if ((DateTime.Now.Year - DateTime.Parse(user.Value.Item3).Year) > 19)
                    {
                        Console.WriteLine("{0} - {1} - {2} - {3}", 
                            user.Key, user.Value.Item1, user.Value.Item2, user.Value.Item3);
                    }
                }
            }

            static void user_sort_2trips(Dictionary<int, Tuple<string, string, string, List<int>>> user_list)
            {
                Console.Clear();
                Console.WriteLine("Ispis svih korisnika s 2 ili više putovanja \n");

                foreach (var user in user_list)
                {
                    if (user.Value.Item4.Count() >= 2)
                    {
                        Console.WriteLine("{0} - {1} - {2} - {3}", 
                            user.Key, user.Value.Item1, user.Value.Item2, user.Value.Item3);
                    }
                }
            }


            static void trip_delete_id(Dictionary<int, Tuple<string, double, double, double, double>> trip_list)
            {
                Console.Write("\nUnesite ID putovanje koje želite izbrisati.");
                var id_remove = input_valid("0", trip_list.Count()-1);

                Console.Write("Jeste li sigurni da želite izbrisati putovanje {0}? (y/n)", id_remove);
                var confirmation = Console.ReadLine();
                if (confirmation.ToLower() == "y" || confirmation.ToLower() == "yes" || confirmation.ToLower() == "da")
                {
                    trip_list.Remove(id_remove);
                    Console.Write("\n Uspješno izbrisano putovanje {0}", id_remove);
                }
                else
                {
                    Console.WriteLine("\n Brisanje otkazano.");
                }
            }

            static void trip_delete_higher_cost (Dictionary<int, Tuple<string, double, double, double, double>> trip_list)
            {
                Console.Write("\nBrisanje putovanja s većim troškovima od određenog iznosa \n Unesite iznos:");
                var ammount = number_valid(Console.ReadLine());

                Console.Write("Jeste li sigurni da želite izbrisati putovanja s većim troškovima od {0} eura? (y/n)", ammount);
                var confirmation = Console.ReadLine();
                if (confirmation.ToLower() == "y" || confirmation.ToLower() == "yes" || confirmation.ToLower() == "da")
                {
                    foreach (var trip in trip_list)
                    {
                        if (trip.Value.Item5 > ammount)
                        {
                            trip_list.Remove(trip.Key);
                        }
                    }
                    Console.Write("\n Uspjesno izbrisana putovanja s troškovima većim do {0} eura.", ammount);
                }
                else
                {
                    Console.WriteLine("\n Otkazivanje brisanja.");
                }
            }

            static void trip_delete_lower_cost(Dictionary<int, Tuple<string, double, double, double, double>> trip_list)
            {
                Console.Write("\nBrisanje putovanja s manjim troškovima od određenog iznosa \n Unesite iznos:");
                var ammount = number_valid(Console.ReadLine());

                Console.Write("Jeste li sigurni da želite izbrisati putovanja s manjim troškovima od {0} eura? (y/n)", ammount);
                var confirmation = Console.ReadLine();
                if (confirmation.ToLower() == "y" || confirmation.ToLower() == "yes" || confirmation.ToLower() == "da")
                {
                    foreach (var trip in trip_list)
                    {
                        if (trip.Value.Item5 < ammount)
                        {
                            trip_list.Remove(trip.Key);
                        }
                    }
                    Console.Write("\n Uspjesno izbrisana putovanja s troškovima manjim do {0} eura.", ammount);
                }
                else
                {
                    Console.WriteLine("\n Otkazivanje brisanja.");
                }
            }

            static void trip_edit(Dictionary<int, Tuple<string, double, double, double, double>> trip_list)
            {
                Console.Write("Uređivanje putovanja \n \n Unesite ID putovanja.");
                var id = input_valid("0", trip_list.Count() - 1);

                Console.Write("Jeste li sigurni da želite urediti putovanje {0}? (y/n)", id);
                var confirmation = Console.ReadLine();
                if (confirmation.ToLower() == "y" || confirmation.ToLower() == "yes" || confirmation.ToLower() == "da")
                {
                    Console.Write("Unesite novi datum:");
                    var new_date = date_valid(Console.ReadLine());
                    Console.Write("Unesite novu kilometražu:");
                    var new_distance = number_valid(Console.ReadLine());
                    Console.Write("Unesite novo gorivo:");
                    var new_gas = number_valid(Console.ReadLine());
                    Console.Write("Unesite novu cijenu:");
                    var new_price = number_valid(Console.ReadLine());

                    trip_list[id] = Tuple.Create(new_date, new_distance, new_gas, new_price, new_price * new_gas);

                    Console.Write("\n Uspješno uređeno putovanje {0}.", id);
                }
                else
                {
                    Console.WriteLine("\n Otkazivanje uređivanja putovanja.");
                }
            }

            static void trips_overview(Dictionary<int, Tuple<string, double, double, double, double>> trips_list, int input)
            {
                var trip_list = new List<KeyValuePair<int, Tuple<string, double, double, double, double>>>(trips_list);
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Ispis svih putovanja prema redoslijedu spremanja \n \n");
                        foreach (var trip in trips_list)
                        {
                            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", 
                                trip.Key, trip.Value.Item1, trip.Value.Item2, trip.Value.Item3, trip.Value.Item4, 
                                trip.Value.Item5);
                        }
                        Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                        Console.ReadKey();
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
            }

            static void user_trip_analysis (int input_report, int id, double total_gas, double total_cost, 
                Dictionary<int, Tuple<string, double, double, double, double>> trips_list, List<int> user_trips)
            {
                switch (input_report)
                {
                    case 1:
                        Console.WriteLine("\n Ukupna potrošnja goriva za korisnika {0} je {1} litara.", id, Math.Round(total_gas, 2));
                        break;

                    case 2:
                        Console.WriteLine("\n Ukupni troškovi goriva za korisnika {0} su {1} eura.", id, Math.Round(total_cost, 2));
                        break;

                    case 3:
                        var average_gas = (total_gas / total_cost) * 100;
                        Console.WriteLine("\n Prosječna potrošnja goriva za korisnika {0} je {1} L/100 km.", id, Math.Round(average_gas, 2));
                        break;

                    case 4:
                        var max_id = -1;
                        double max_gas = -1;

                        foreach (var trip_id in user_trips)
                        {
                            double spent_gas = trips_list[trip_id].Item3;
                            if (spent_gas > max_gas) { max_gas = spent_gas; max_id = trip_id; }

                        }

                        if (max_id != -1) 
                        { Console.WriteLine("\n Putovanje s najvećom potrošnjom goriva za korisnika {0} je {1} s potrošnjom od {2} L.", 
                            id, max_id, Math.Round(max_gas, 2)); }
                        else { Console.WriteLine("Korisnik nema unesenih putovanja."); }
                        break;

                    case 5:
                        Console.Write("\n Pregled putovanja po određenom datumu \n \n Unesite željeni datum:");
                        var date_search = date_valid(Console.ReadLine());

                        bool found = false;

                        foreach (var trip_id in user_trips)
                        {
                            DateTime trip_date = DateTime.Parse(trips_list[trip_id].Item1);
                            if (trip_date == DateTime.Parse(date_search))
                            {
                                found = true;
                                Console.WriteLine("\n Pronađena putovanja s unesenim datumom:");
                                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", 
                                    trip_id, trips_list[trip_id].Item1, trips_list[trip_id].Item2, trips_list[trip_id].Item3,
                                    trips_list[trip_id].Item4, trips_list[trip_id].Item5);
                            }
                        }
                        if (found == false) { Console.WriteLine("Ne postoji putovanje s unesenim datumom."); }
                        break;
                }
            }


            void users_menu(int user_menu_input, Dictionary<int, Tuple<string, string, string, List<int>>> users,
                Dictionary<int, Tuple<string, double, double, double, double>> trips)
            {
                int id;
                string menu_text;
                string confirmation;
                switch (user_menu_input)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Unos novog korisnika \n");
                        Console.Write("Unesite ime: ");
                        var name = name_valid(Console.ReadLine(), "name");
                        Console.Write("Unesite prezime: ");
                        var surname = name_valid(Console.ReadLine(), "surname");
                        Console.Write("Unesite datum rođenja: ");
                        var dob = date_valid(Console.ReadLine());

                        users.Add(users.Count(), Tuple.Create(name, surname, dob, new List<int>()));
                        Console.Write("\nUspješno dodan novi korisnik. \nPritisnite bilo koju tipku za nastavak...");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Brisanje korisnika \n \n ");
                        menu_text = "1-Unos ID-a \n 2-Unos imena i prezimena" +
                            "\n 0-Povratak na glavni izbornik";

                        var input_delete = input_valid(menu_text,2);

                        if (input_delete == 1)
                        {
                            user_delete_id(users);
                        }
                        else if (input_delete == 2)
                        {
                            user_delete_name(users);
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("Uređivanje korisnika \n \n Unesite ID korisnika.");
                        id = input_valid("0", users.Count() - 1);

                        Console.Write("\nJeste li sigurni da želite urediti korisnika {0} - {1} - {2} - {3} (y/n)?", 
                            id, users[id].Item1, users[id].Item2, users[id].Item3);

                        confirmation = Console.ReadLine();
                        user_edit(users, confirmation, id);
                        break;

                    case 4:
                        Console.Clear();
                        Console.Write("Pregled svih korisnika \n \n");
                        menu_text = " 1-Ispis svih korisnika abecedno po prezimenu " +
                            "\n 2-Ispis svih korisnika iznad 20 godina " +
                            "\n 3-Ispis svih korisnika s 2 ili više putovanja" +
                            "\n 0-Povratak na glavni izbornik";

                        var overview_input = input_valid(menu_text,3);

                        if (overview_input == 1)
                        {
                            user_sort_alphabet(users);
                        }
                        else if (overview_input == 2)
                        {
                            user_sort_over20(users);
                        }
                        else if (overview_input == 3)
                        {
                            user_sort_2trips(users);    
                        }
                        Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                        Console.ReadKey();
                        break;

                    case 0:
                        Console.Clear();
                        break;
                }
            }



            void trip_menu(int trip_menu_input, Dictionary<int, Tuple<string, double, double, double, double>> trips,
                Dictionary<int, Tuple<string, string, string, List<int>>> users)
            {
                string menu_text;
                string confirmation;
                switch (trip_menu_input)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Unos novog putovanja \n \n Unesite datum: ");
                        var date = date_valid(Console.ReadLine());
                        Console.Write("Unesite udaljenost u kilometrima: ");
                        var distance = number_valid(Console.ReadLine());
                        Console.Write("Unesite gorivo u litrama: ");
                        var gas = number_valid(Console.ReadLine());
                        Console.Write("Unesite cijenu goriva po litri u eurima: ");
                        var price = number_valid(Console.ReadLine());

                        trips.Add(trips.Count(), Tuple.Create(date, distance, gas, price, gas * price));

                        Console.WriteLine("\n Ukupan trošak ovog putovanja je {0} eura.", Math.Round(gas*price,2));
                        Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Brisanje putovanja");
                        menu_text = "\n 1-Unos ID-a " +
                            "\n 2-Putovanja s većim troškovima od unesenog iznosa " +
                            "\n 3-Putovanja s manjim troškovima od unesenog iznosa" +
                            "\n 0-Povratak na glavni izbornik";

                        var input_delete = input_valid(menu_text,3);

                        if (input_delete == 1)
                        {
                            trip_delete_id(trips);
                        }
                        else if (input_delete == 2)
                        {
                            trip_delete_higher_cost(trips);  
                        }
                        else if (input_delete == 3)
                        {
                            trip_delete_lower_cost(trips);

                        }
                        Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();
                        trip_edit(trips);
                        Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Clear();
                        Console.Write("Pregled svih putovanja \n \n ");
                        menu_text = "1-Prema redoslijedu spremanja " +
                            "\n 2-Prema trošku uzlazno \n 3-Prema trošku silazno " +
                            "\n 4-Prema kilometraži uzlazno \n 5-Prema kilometraži silazno " +
                            "\n 6-Prema datumu uzlazno \n 7-Prema datumu silazno" +
                            "\n 0-Povratak na glavni izbornik";

                        var input_overview = input_valid(menu_text, 7);

                        trips_overview(trips, input_overview);

                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Izvještaji i analize \n \n Izaberite korisnika \n");

                        foreach (var user in users) { Console.WriteLine("{0} - {1} - {2} - {3}", 
                            user.Key, user.Value.Item1, user.Value.Item2, user.Value.Item3); }

                        var id = input_valid("0", users.Count() - 1);

                        Console.Write("\n Odaberite željeni izvještaj \n \n ");
                        menu_text = "1-Ukupna potrošnja goriva " +
                            "\n 2-Ukupni troškovi goriva " +
                            "\n 3-Prosječna potrošnja goriva " +
                            "\n 4-Putovanje s najvećom potrošnjom goriva " +
                            "\n 5-Pregled putovanja po određenom datumu " +
                            "\n 0-Povratak na glavni izbornik";

                        var input_report = input_valid(menu_text,5);

                        var user_trips = users[id].Item4;

                        double total_gas = 0.0;
                        var total_cost = 0.0;

                        foreach (var trip in user_trips){ total_gas += trips[trip].Item3; }   
                        foreach (var trip in user_trips){ total_cost += trips[trip].Item5; }

                        user_trip_analysis(input_report, id, total_gas, total_cost, trips, user_trips);

                        Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                        Console.ReadKey();
                        break;

                    case 0:
                        break;
                }
            }


            bool inApp = true;


            var users = new Dictionary<int, Tuple<string, string, string, List<int>>>();
            users[0] = Tuple.Create("Ana", "Anic", "1985-04-12", new List<int> { 1, 2 });
            users[1] = Tuple.Create("Ivo", "Ivic", "1992-09-25", new List<int> { 5 });
            users[2] = Tuple.Create("Hrvoje", "Horvat", "2000-07-06", new List<int> { 1, 3, 4 });
            users[3] = Tuple.Create("Maria", "Maric", "2002-07-09", new List<int>());


            var trips = new Dictionary<int, Tuple<string, double, double, double, double>>();
            trips[0] = Tuple.Create("2025-03-15", 350.0, 20.5, 1.60, 32.8);
            trips[1] = Tuple.Create("2025-03-18", 120.0, 8.0, 1.55, 12.4);
            trips[2] = Tuple.Create("2025-09-10", 100.0, 6.0, 1.45, 8.7);
            trips[3] = Tuple.Create("2025-12-11", 40.0, 6.0, 1.40, 8.4);
            trips[4] = Tuple.Create("2025-06-02", 320.0, 20.0, 1.65, 33.0);




            while (inApp)
            {
                Console.Clear();
                var menu_input = main_input();
                if (menu_input == 1)
                {
                    users_menu(users_input(), users, trips);
                }
                else if (menu_input == 2)
                {
                    trip_menu(trip_input(), trips, users);
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
