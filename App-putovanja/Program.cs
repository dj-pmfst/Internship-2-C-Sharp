using System.Windows.Markup;

namespace App_putovanja
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var users = new Dictionary<int, Tuple<string, string, string, List<int>>>();
            users[1] = Tuple.Create("Ana", "Anić", "1985-04-12", new List<int> {1, 2});
            users[2] = Tuple.Create("Ivo", "Ivić", "1992-09-25", new List<int> {5});
            users[3] = Tuple.Create("Hrvoje", "Horvat", "2000-07-06", new List<int> {1,3,4});
            users[4] = Tuple.Create("Maria", "Marić", "2002-07-09", new List<int>());


            var trips = new Dictionary<int, Tuple<string, double, double, double, double>>();
            trips[1] = Tuple.Create("2025-03-15", 350.0, 20.5, 1.60, 32.8);
            trips[2] = Tuple.Create("2025-03-18", 120.0, 8.0, 1.55, 12.4);
            trips[3] = Tuple.Create("2025-09-10", 100.0, 6.0, 1.45, 8.7);
            trips[4] = Tuple.Create("2025-12-11", 40.0, 6.0, 1.40, 8.4);
            trips[5] = Tuple.Create("2025-06-02", 320.0, 20.0, 1.65, 33.0);


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

            static string date_valid(string date_input)
            {
                while (!DateTime.TryParse(date_input, out DateTime date) || date.Year > 2025)
                {
                    Console.Write("Neispravan unos. \n Unesite opet:");
                    date_input = Console.ReadLine(); 
                }
                return date_input;
            }

            void users_menu(int user_menu_input)
            {
                string id;
                switch (user_menu_input)
                {
                    case 1:

                        //dodat petlje koje provjeravaju valjanost unosa

                        Console.Clear();
                        Console.WriteLine("Unos novog korisnika");
                        Console.Write("Unesite ime:");
                        var name = Console.ReadLine();
                        Console.Write("Unesite prezime:");
                        var surname = Console.ReadLine();
                        Console.Write("Unesite datum rođenja:");
                        var dob = date_valid(Console.ReadLine());

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
                                Console.WriteLine("\n Neispravan unos. Unesite opet. \n");
                                Console.Write("Unos:");
                                id = Console.ReadLine();
                            }
                            Console.Clear();
                            Console.Write("Jeste li sigurni da želite izbrisati korisnika {0}? (y/n)", int.Parse(id));
                            if (Console.ReadLine() == "y")
                            {
                                users.Remove(int.Parse(id));
                                Console.Write("\n Uspješno izbrisan korisnik {0} {1}", users[int.Parse(id)].Item1, users[int.Parse(id)].Item2);
                                Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
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
                                    Console.Write("\n Jeste li sigurni da želite izbrisati korisnika {0} {1}? (y/n)", input_name, input_surname);
                                    if (Console.ReadLine() == "y")
                                    {
                                        //users.Remove(int.Parse(id));

                                        Console.Write("\n Uspješno izbrisan korisnik {0} {1}", input_name, input_surname);
                                        Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Uneseni korisnik ne postoji.");
                                    Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
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
                        Console.Write("\n Jeste li sigurni da želite urediti korisnika {0} - {1} - {2} - {3} (y/n)?", int.Parse(id), users[int.Parse(id)].Item1, users[int.Parse(id)].Item2, users[int.Parse(id)].Item3);
                        if (Console.ReadLine() == "y")
                        {
                            Console.Write("\n Unesite novo ime:");
                            var new_name = Console.ReadLine();
                            Console.Write("Unesite novo prezime:");
                            var new_surname = Console.ReadLine();
                            Console.Write("Unesite novi datum rođenja:");
                            var new_dob = date_valid(Console.ReadLine());

                            users[int.Parse(id)] = Tuple.Create(new_name, new_surname, new_dob, users[int.Parse(id)].Item4);

                            Console.Write("Uspješno uređen korisnik {0} - {1} - {2} - {3} .", int.Parse(id), users[int.Parse(id)].Item1, users[int.Parse(id)].Item2, users[int.Parse(id)].Item3);
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

                            var user_list = new List<KeyValuePair<int, Tuple<string, string, string, List<int>>>>(users);

                            user_list.Sort((a, b) => string.Compare(a.Value.Item2, b.Value.Item2, StringComparison.OrdinalIgnoreCase));

                            foreach (var user in user_list)
                            {
                                Console.WriteLine("{0} - {1} - {2} - {3}", user.Key, user.Value.Item1, user.Value.Item2, user.Value.Item3);
                            }

                            Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                            Console.ReadKey();
                        }
                        else if (int.Parse(overview_input) == 2)
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

                            Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
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

            static void list_trips(List<KeyValuePair<int, Tuple<string, double, double, double, double>>> user_trips)
            {
                foreach (var trip in user_trips)
                {
                    Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", trip.Key, trip.Value.Item1, trip.Value.Item2, trip.Value.Item3, trip.Value.Item4, trip.Value.Item5);
                }
                Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                Console.ReadKey();
            }

            void trip_menu(int trip_menu_input)
            {
                switch (trip_menu_input)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Unos novog putovanja \n \n Unesite datum (YYYY-MM-DD):");
                        var date = date_valid(Console.ReadLine());
                        Console.Write("Unesite udaljenost u kilometrima:");
                        var distance = double.Parse(Console.ReadLine());
                        Console.Write("Unesite gorivo u litrama:");
                        var gas = double.Parse(Console.ReadLine());
                        Console.Write("Unesite cijenu goriva po litri u eurima:");
                        var price = double.Parse(Console.ReadLine());

                        trips.Add(trips.Count() + 1, Tuple.Create(date, distance, gas, price, gas * price));

                        Console.WriteLine("Ukupan trošak ovog putovanja je {0} €.", gas*price);
                        Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Brisanje putovanja \n \n 1-Unos ID-a \n 2-Putovanja s većim troškovima od unesenog iznosa \n 3-Putovanja s manjim troškovima od unesenog iznosa \n \n Odabir:");
                        var input_delete = Console.ReadLine();
                        while (!int.TryParse(input_delete, out int number) || int.Parse(input_delete) > 3 || int.Parse(input_delete) < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Neispravan unos. Unesite opet.");
                            Console.Write("Brisanje putovanja \n \n 1-Unos ID-a \n 2-Putovanja s većim troškovima od unesenog iznosa \n 3-Putovanja s manjim troškovima od unesenog iznosa \n \n Odabir:");
                            input_delete = Console.ReadLine();
                        }
                        if (int.Parse(input_delete) == 1)
                        {
                            Console.Clear();
                            Console.Write("Unesite ID putovanje koje želite izbrisati:");
                            trips.Remove(int.Parse(Console.ReadLine()));

                            Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                            Console.ReadKey();
                        }
                        else if (int.Parse(input_delete) == 2)
                        {
                            Console.Clear();
                            Console.Write("Brisanje putovanja s većim troškovima od određenog iznosa \n Unesite iznos:");
                            var ammount = int.Parse(Console.ReadLine());

                            foreach (var trip in trips)
                            {
                                if (trip.Value.Item5 > ammount)
                                {
                                    trips.Remove(trip.Key);
                                }
                            }
                            Console.Write("\n Uspjesno izbrisana putovanja s troškovima većim do {0} €. \n Pritisnite bilo koju tipku za nastavak...", ammount);
                            Console.ReadKey();
                        }
                        else if (int.Parse(input_delete) == 3)
                        {
                            Console.Clear();
                            Console.Write("Brisanje putovanja s manjim troškovima od određenog iznosa \n Unesite iznos:");
                            var ammount = int.Parse(Console.ReadLine());

                            foreach (var trip in trips)
                            {
                                if (trip.Value.Item5 < ammount)
                                {
                                    trips.Remove(trip.Key);
                                }
                            }
                            Console.Write("\n Uspjesno izbrisana putovanja s troškovima manjim do {0} €. \n Pritisnite bilo koju tipku za nastavak...", ammount);
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
                            var new_date = date_valid(Console.ReadLine());
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

                        var trip_list = new List<KeyValuePair<int, Tuple<string, double, double, double, double>>>(trips);

                        switch (int.Parse(input_overview))
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Ispis svih putovanja prema redoslijedu spremanja \n \n");
                                foreach (var trip in trips)
                                {
                                    Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", trip.Key, trip.Value.Item1, trip.Value.Item2, trip.Value.Item3, trip.Value.Item4, trip.Value.Item5);
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
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Izvještaji i analize \n \n Izaberite korisnika \n");
                        foreach (var user in users) { Console.WriteLine("{0} - {1} - {2} - {3}", user.Key, user.Value.Item1, user.Value.Item2, user.Value.Item3); }

                        Console.Write("\n Odabir:");
                        id = Console.ReadLine();

                        while (!int.TryParse(id, out int number) || int.Parse(id) > users.Count() || int.Parse(id) < 0)
                        {
                            Console.WriteLine("\n Neispravan unos. Unesite opet. \n");
                            Console.Write("Unos:");
                            id = Console.ReadLine();
                        }

                        Console.Write("\n Odaberite željeni izvještaj \n \n 1-Ukupna potrošnja goriva \n 2-Ukupni troškovi goriva \n 3-Prosječna potrošnja goriva \n 4-Putovanje s najvećom potrošnjom goriva \n 5-Pregled putovanja po određenom datumu \n \n Odabir:");
                        var input_report = Console.ReadLine();
                        while (!int.TryParse(input_report, out int number) || int.Parse(input_report) > 5 || int.Parse(input_report) < 0)
                        {
                            Console.WriteLine("\n Neispravan unos. Unesite opet. \n");
                            Console.Write("Odabir:");
                            input_report = Console.ReadLine();
                        }

                        var user_trips = users[int.Parse(id)].Item4;

                        double total_gas = 0.0;
                        var total_cost = 0.0;
                        foreach (var trip in user_trips){ total_gas += trips[trip].Item3; }   
                        foreach (var trip in user_trips){ total_cost += trips[trip].Item5; }

                        switch (int.Parse(input_report))
                        {
                            case 1:
                                Console.WriteLine("\n Ukupna potrošnja goriva za korisnika {0} je {1} litara.", id, Math.Round(total_gas,2));
                                Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.WriteLine("\n Ukupni troškovi goriva za korisnika {0} su {1} eura.", id, Math.Round(total_cost,2));
                                Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                                Console.ReadKey();
                                break;
                            case 3:
                                var average_gas = (total_gas / total_cost)*100;
                                Console.WriteLine("\n Prosječna potrošnja goriva za korisnika {0} je {1} L/100 km.", id, Math.Round(average_gas, 2));
                                Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                                Console.ReadKey();
                                break;
                            case 4:
                                var max_id = -1;
                                double max_gas = -1;
                                foreach (var trip_id in user_trips)
                                {
                                    double spent_gas = trips[trip_id].Item3;
                                    if (spent_gas > max_gas) {max_gas = spent_gas; max_id = trip_id; }

                                }
                                if (max_id != -1) { Console.WriteLine("\n Putovanje s najvećom potrošnjom goriva za korisnika {0} je {1} s potrošnjom od {2} L.", id, max_id, Math.Round(max_gas,2)); }
                                else { Console.WriteLine("Korisnik nema unesenih putovanja."); }
                                    
                                Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
                                Console.ReadKey();
                                break;
                            case 5:
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

                                Console.Write("\n Pritisnite bilo koju tipku za nastavak...");
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
