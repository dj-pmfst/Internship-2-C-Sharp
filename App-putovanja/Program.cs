using System.Windows.Markup;

namespace App_putovanja
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var id;

            var users = new Dictionary<int, Tuple<string, string, string>>();

            var trips = new Dictionary<int, Tuple<string, int, int, int, int>>();


            static int main_input()
            {
                Console.Write("Unesite broj za željenu opciju \n 1-Korisnici \n 2-Putovanja \n 0-Izlaz iz aplikacije \n \n Odabir:");
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

            var menu_input = main_input();

            //static void input_confirmation(string setting, string id)
            //{
            //    Console.Write("Jeste li sigurni da želite izbrisati korisnika {0}? (y/n)", id);
            //    if (Console.ReadLine() == "y")
            //    {
            //        users.Remove(int.Parse(id));
            //        Console.Write("Uspješno izbrisan korisnik {0}", int.Parse(id));
            //    }
            //    else
            //    {
            //        main_input();
            //    }
            //}

            static int users_input()
            {
                Console.Clear();
                Console.Write("Korisnici \n \n Unesite broj za željenu opciju \n 1-Unos novog korisnika \n 2-Brisanje korisnika \n 3-Uređivanje korisnika \n 4-Pregled svih korisnika \n 0-Povratak na glavni izbornik \n \n Odabir:");
                var input = Console.ReadLine();
                while (!int.TryParse(input, out int number) || int.Parse(input) > 4 || int.Parse(input) < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Neispravan unos. Unesite opet.");
                    Console.Write("Korisnici \n \n Unesite broj za željenu opciju \n 1-Unos novog korisnika \n 2-Brisanje korisnika \n 3-Uređivanje korisnika \n 4-Pregled svih korisnika \n 0-Povratak na glavni izbornik \n \n Odabir:");
                    input = Console.ReadLine();
                }
                return int.Parse(input);
            }

            void users_menu(int user_menu_input)
            {
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

                        users.Add(2, Tuple.Create(name, surname, dob));

                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Brisanje korisnika \n \n 1-Unos ID-a \n 2-Unos imena i prezimena");
                        Console.Write("Unos:");
                        var input_delete = Console.ReadLine();
                        while (!int.TryParse(input_delete, out int number) || int.Parse(input_delete) > 2 || int.Parse(input_delete) < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Neispravan unos. Unesite opet.");
                            Console.WriteLine("Brisanje korisnika \n \n 1-Unos ID-a \n 2-Unos imena i prezimena");
                            Console.Write("Unos:");
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
                                main_input();
                            }
                        }
                        else if (int.Parse(input_delete) == 2)
                        {
                            Console.Write("Unesite ime i prezime:");


                            Console.Write("Jeste li sigurni da želite izbrisati korisnika {0}? (y/n)", int.Parse(id));
                            if (Console.ReadLine() == "y")
                            {
                                users.Remove(int.Parse(id));
                                Console.Write("Uspješno izbrisan korisnik {0}", int.Parse(id));
                            }
                            else
                            {
                                main_input();
                            }
                        }

                            break;

                    case 3:
                        Console.WriteLine("Uređivanje korisnika \n \n Unesite ID korisnika:");
                        var id_input = Console.ReadLine();

                        break;

                    case 4:
                        Console.WriteLine("Pregled svih korisnika \n \n 1-Ispis svih korisnika abecedno po prezimenu \n 2-Ispis svih korisnika iznad 20 godina 3-Ispis svih korisnika s 2 ili više putovanja");
                        Console.Write("Unos:");

                        break;

                    case 0:
                        Console.Clear();
                        main_input();
                        break;
                }
            }

            static int trip_input()
            {
                Console.Clear();
                Console.Write("Putovanja\n \n Unesite broj za željenu opciju \n 1-Unos novog putovanja \n 2-Brisanje putovanja \n 3-Uređivanje postojećeg putovanja \n 4-Pregled svih putovanja \n 5-Izvještaji i analize \n 0-Povratak na glavni izbornik \n \n Odabir:");
                var input = Console.ReadLine();
                while (!int.TryParse(input, out int number) || int.Parse(input) > 4 || int.Parse(input) < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Neispravan unos. Unesite opet.");
                    Console.Write("Putovanja\n \n Unesite broj za željenu opciju \n 1-Unos novog putovanja \n 2-Brisanje putovanja \n 3-Uređivanje postojećeg putovanja \n 4-Pregled svih putovanja \n 5-Izvještaji i analize \n 0-Povratak na glavni izbornik \n \n Odabir:");
                    input = Console.ReadLine();
                }
                return int.Parse(input);
            }

            static void trip_menu(int trip_menu_input)
            {
                switch (trip_menu_input)
                {
                    case 1:
                        break;

                    case 2:
                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    case 5:
                        break;

                    case 0:
                        Console.Clear();
                        main_input();
                        break;
                }
            }

            switch (menu_input)
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
