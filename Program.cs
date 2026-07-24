
using System.Reflection;

class LastOneInTheChamber
{




    static void Main()  
    {
    Console.Clear();
    int lifes = 3;
    string[] Inventory = {"Nic", "Nic", "Nic", "Nic"};
    Console.WriteLine("Vítej ve hře Last One In The Chamber");
    Console.WriteLine("Chceš tutoriál? Y/N");
    string Ano = Console.ReadLine();
    if(Ano == "y"|Ano == "Y")
    {
    Tutorial(lifes, Inventory);
    }
    else{
    ZacatekHry(lifes, Inventory);
    }
    }

    static void Tutorial(int lifes, string[] Inventory)
    {
        Console.Clear();
        Console.WriteLine("Cíl hry: Zbavit se všech nábojů a přežít");
        Console.WriteLine("Máš 3 životy");
        Console.WriteLine("Pokud vyhodíš falešný náboj, příjdeš o život.");
        Console.WriteLine("Pokud vystřelíš realný náboj, přijdeš taky o život.");
        Console.WriteLine($"Pokud vystřelíš falešný náboj nebo vyhodíš realný, o žádné životy nepřijdeš a dostaneš náhodný předmět");
        Console.WriteLine("Předměty a jejich schopnosti:");
        Console.WriteLine("Léky: Přidají jeden život");
        Console.WriteLine("Pivo: Odebere ze zásobníku jeden realný náboj");
        Console.WriteLine("PivoXL: Odebere ze zásobníku jeden realný a jeden falešný náboj");
        Console.WriteLine("Hodně štěstí!");
        Console.WriteLine("(Bude potřeba...)");
        Console.WriteLine("Pro pokračování zmáčkni libovolnou klávesu");
        Console.ReadKey();
        ZacatekHry(lifes, Inventory);
    }
    static void ZacatekHry(int lifes, string[] Inventory)

        {
        int bullets = Nahoda();
        if(bullets == 0)
        {
            ZacatekHry(lifes, Inventory);
        }
        else 
        {

            Hra(lifes, bullets/2, bullets/2, bullets, Inventory);
        }
        }
    static void Hra(int lifes, int lifeRnd, int blankRnd, int bullets, string[] Inventory)
    {


        if(lifes==0)
        {
            Console.Clear();
            Console.WriteLine("Game Over!");
            Console.ReadKey();
            Main();
        }


        else
        {
            if(bullets == 0)
        {
            Console.Clear();
            Console.WriteLine("Vyhrál jsi!");
            Console.ReadKey();
            Main();
        }
        Console.Clear();
        Console.WriteLine($"Životy: {lifes} ");
        Console.WriteLine($"Střely dohromady: {bullets}");
        Console.WriteLine($"Z toho živé: {lifeRnd} ");
        Random rand = new Random();
        int nahoda = rand.Next(1, 3);
        Console.WriteLine("1) Vyhoďit jeden náboj z komory");
        Console.WriteLine("2) Vystřelit");
        Console.WriteLine("3) Použít předmět");
        Console.WriteLine("4) Přestat hrát");
        string Moznost = Console.ReadLine();
        if(Moznost=="1")
            {
                BulletOut(Moznost, nahoda, lifeRnd,blankRnd,lifes, bullets, Inventory);
            }
        else if(Moznost=="2")
            {
                Shoot(Moznost, nahoda, lifeRnd,blankRnd,lifes, bullets, Inventory);
            }
        else if(Moznost=="3")
            {
                Inv(Inventory, lifes, lifeRnd, blankRnd, bullets);
            }
        else if(Moznost=="4")
            {
                Console.Clear();
                Console.WriteLine("Vrať se brzy!");
            }
        else
        {
            Console.WriteLine("Invalid Input");
            Hra(lifes, lifeRnd, blankRnd, bullets, Inventory);
        }
        }
    }

    static int Nahoda()
    {

    Random rand = new Random();
    int bullets = rand.Next(10, 21);
    if(bullets%2 == 0){
        return bullets;
    }

    else
    {
        return 0;

    }
    }
    static void BulletOut(string Moznost, int Nahoda, int LifeRnd, int BlankRnd, int lifes, int bullets, string[] Inventory)

    {

            if(Nahoda==1)
            {
               if(BlankRnd>=1)
                {
                Console.Clear();
                lifes -= 1;
                Console.WriteLine("Falešný náboj");
                Console.WriteLine("Ztratil si jeden život");
                BlankRnd -= 1;
                bullets -= 1;
                Console.WriteLine("Pro pokračovaní zmáčkni libovolnou klávesu");
                Console.ReadKey();
                Hra(lifes, LifeRnd, BlankRnd, bullets, Inventory);
                }
                else 
                {
                    BulletOut(Moznost, Nahoda+1, LifeRnd, BlankRnd, lifes, bullets, Inventory);
                }
            }
            if(Nahoda==2)
            {
                if(LifeRnd>=1)
                {
                Console.Clear();
                Console.WriteLine("Realný náboj");
                Console.WriteLine("O žádné životy si nepřišel");
                LifeRnd -= 1;
                bullets -= 1;
                string item = ItemRnd();
                Console.WriteLine($"Dostal jsi {item}");
                Console.WriteLine("Do jakého slotu ho chceš uložit? (zadej cokoliv jiného pro zahození)");
                bool parsed = int.TryParse(Console.ReadLine(), out int slot);
                if(parsed)
                {
                    if(slot<5) 
                    {
                        Inventory[slot-1] = item;
                    }
                }
                Console.WriteLine("Pro pokračování zmáčkni libovolnou klávesu");
                Console.ReadKey();
                Hra(lifes, LifeRnd, BlankRnd, bullets, Inventory);
                }
                else 
                {
                    BulletOut(Moznost, Nahoda-1, LifeRnd, BlankRnd, lifes, bullets, Inventory);
                }


      }

    }

    static void Shoot(string Moznost, int Nahoda, int LifeRnd, int BlankRnd, int lifes, int bullets, string[] Inventory)
    {

            {
            if(Nahoda==1)
            {
               if(BlankRnd>=1)
                {
                Console.Clear();
                Console.WriteLine("Falešný náboj");
                Console.WriteLine("O žádné životy si nepřišel");
                BlankRnd -= 1;
                bullets -= 1;
                string item = ItemRnd();
                Console.WriteLine($"Dostal jsi {item}");
                Console.WriteLine("Do jakého slotu ho chceš uložit? (zadej cokoliv jiného pro zahození)");
                bool parsed = int.TryParse(Console.ReadLine(), out int slot);
                if(parsed)
                {
                    if(slot<5) 
                    {
                        Inventory[slot-1] = item;
                    }
                }
                Console.WriteLine("Pro pokračování zmáčkni libovolnou klávesu");
                Console.ReadKey();
                Hra(lifes, LifeRnd, BlankRnd, bullets, Inventory);
                }
                else 
                {
                    Shoot(Moznost, Nahoda+1, LifeRnd, BlankRnd, lifes, bullets, Inventory);
                }
            }
            if(Nahoda==2)
            {
                if(LifeRnd>=1)
                {
                lifes -= 1;
                Console.Clear();
                Console.WriteLine("Realný náboj");
                Console.WriteLine("Ztratil si jeden život");
                LifeRnd -= 1;
                bullets -= 1;
                Console.WriteLine("Pro pokračovaní zmáčkni libovolnou klávesu");
                Console.ReadKey();
                Hra(lifes, LifeRnd, BlankRnd, bullets, Inventory);
                }
                else 
                {
                    Shoot(Moznost, Nahoda-1, LifeRnd, BlankRnd, lifes, bullets, Inventory);
                }
            }
            
      }

    }
    static void Inv(string[]Inventory,int lifes, int lifeRnd, int blankRnd, int bullets)
    {
        Console.Clear();
        for(int i = 0; i < Inventory.Length; i++)
        {
            Console.WriteLine($"Slot {i+1}. {Inventory[i]}");
        }
        Console.WriteLine($"Jaký předmět chceš použít?");
        Console.WriteLine("Pokud chceš odejít bez použití předmětu, napiš 5");
        bool parsed = int.TryParse(Console.ReadLine(), out int volba);
        if(parsed)
        {
            if(volba<5)
             {   if(Inventory[volba-1] == "Léky")
                {
                    Console.WriteLine($"Použil jsi {Inventory[volba-1]}");
                    Console.WriteLine($"Vyléčil ses o jeden život.");
                    lifes = lifes + 1;
                }
                else if(Inventory[volba-1] == "Pivo")
                {
                    Console.WriteLine($"Použil jsi {Inventory[volba-1]}");
                    Console.WriteLine($"Magicky za zbraně zmizel jeden realný náboj.");
                    lifeRnd = lifeRnd - 1;
                    bullets = bullets - 1;
                }
                else if(Inventory[volba-1] == "PivoXL")
                {
                    Console.WriteLine($"Použil jsi {Inventory[volba-1]}");
                    Console.WriteLine($"Magicky za zbraně zmizel jeden realný a jeden falešný náboj.");
                    
                    lifeRnd = lifeRnd - 1;
                    blankRnd = blankRnd - 1;
                    bullets = bullets - 2;
                }
                else if(Inventory[volba-1] == "Nic")
                {
                    Console.WriteLine($"Použil jsi {Inventory[volba-1]}");
                    Console.WriteLine($"Překvapivě se nic nestalo, kdo by to byl řekl...");

                }
                Inventory[volba-1] = "Nic";
                Console.WriteLine("Pro pokračování zmáčkni libovolnou klávesu");
                Console.ReadKey();
                Inv(Inventory, lifes, lifeRnd, blankRnd, bullets);

             }
             else
            {
                Hra(lifes, lifeRnd, blankRnd, bullets, Inventory);
            }          
            }

            else
            {
                Console.WriteLine("Zkus to znova jo?");
                Console.ReadKey();
                Inv(Inventory, lifes, lifeRnd, blankRnd, bullets);
            }
            
    }
static string ItemRnd()
{
    string[] items = {"Léky","Pivo", "PivoXL"};
    Random rand = new Random();
    int item = rand.Next(0, 3);
    return items[item];
}


}

    