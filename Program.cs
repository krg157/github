//jméno hry
class LastOneInTheChamber
{



// Životy, inventář a začátek 
    static void Main()  
    {
    Console.Clear();
    int lifes = 3;
    int MinCislo = 0;
    int MaxCislo = 0;
    string[] Inventory = {"Nic", "Nic", "Nic", "Nic"};
    Console.WriteLine("========================================");
    Console.WriteLine("| Vítej ve hře Last One In The Chamber |");
    Console.WriteLine("========================================");
    Console.WriteLine("Jakou chceš obtížnost?");
    Console.WriteLine("Easy (E) - 4-10");
    Console.WriteLine("Medium (M) - 10-20");
    Console.WriteLine("Hard (H) - 20-30");
    string difficulty = Console.ReadLine();
    if(difficulty == "E"|difficulty == "e")
        {
            MinCislo = 4; //Fanda nám všem dokázal že easy, bylo až moc easy. Děkujeme! <3 (puvodne byl min je 2)
            MaxCislo = 11;
        }
    else if(difficulty == "M"|difficulty == "m")
        {
            MinCislo = 10;
            MaxCislo = 21;
        }
    else if(difficulty == "H"|difficulty == "h")
        {
            MinCislo = 20;
            MaxCislo = 31;
        }
        else
        {
            Console.WriteLine("Zkus to znovu");
            Console.ReadKey();
            Main();
        }
    Console.WriteLine("Chceš tutoriál? Y/N");
    string Ano = Console.ReadLine();
    if(Ano == "y"|Ano == "Y")
    {
    Tutorial(lifes, Inventory, MinCislo, MaxCislo);
    }
    else{
    ZacatekHry(lifes, Inventory, MinCislo, MaxCislo);
    }
    }
// Vypíše tutorial a po stisknutí jakého koliv tlačítka začne hra.
    static void Tutorial(int lifes, string[] Inventory, int MinCislo, int MaxCislo)
    {
        Console.Clear();
        Console.WriteLine("===========================");
        Console.WriteLine("| Last One In The Chamber |");
        Console.WriteLine("===========================");
        Console.WriteLine();
        Console.WriteLine("-Cíl hry: Zbavit se všech nábojů a přežít");
        Console.WriteLine("-Máš 3 životy");
        Console.WriteLine("-Pokud vyhodíš falešný náboj, příjdeš o život.");
        Console.WriteLine("-Pokud vystřelíš realný náboj, přijdeš taky o život.");
        Console.WriteLine($"-Pokud vystřelíš falešný náboj nebo vyhodíš realný, o žádné životy nepřijdeš a dostaneš náhodný předmět");
        Console.WriteLine("=============================");
        Console.WriteLine("Předměty a jejich schopnosti:");
        Console.WriteLine();
        Console.WriteLine("-Léky: Přidají jeden život");
        Console.WriteLine("-Pivo: Odebere ze zásobníku jeden realný náboj");
        Console.WriteLine("-PivoXL: Odebere ze zásobníku jeden realný a jeden falešný náboj");
        Console.WriteLine("=============");
        Console.WriteLine("Hodně štěstí!");
        Console.WriteLine("(Bude potřeba...)");
        Console.WriteLine("Pro pokračování zmáčkni libovolnou klávesu");
        Console.ReadKey();
        ZacatekHry(lifes, Inventory, MinCislo, MaxCislo);
    }
    // Generace náhodného počtu munice v zásobníku.
    static void ZacatekHry(int lifes, string[] Inventory, int MinCislo, int MaxCislo)

        {
        int bullets = Nahoda(MinCislo, MaxCislo);
        if(bullets == 0)
        {
            ZacatekHry(lifes, Inventory, MinCislo, MaxCislo);
        }
        else 
        {

            Hra(lifes, bullets/2, bullets/2, bullets, Inventory, MinCislo, MaxCislo);
        }
        }
        //Hlavní menu hry
    static void Hra(int lifes, int lifeRnd, int blankRnd, int bullets, string[] Inventory, int MinCislo, int MaxCislo)
    {

//Kontrola žívotů a počtů náboju a označuje konec hry a pošle hráče zpět na start.
        if(lifes==0)
        {
            Console.Clear();
            Console.WriteLine("================");
            Console.WriteLine("| Game Over!💀 |");
            Console.WriteLine("================");
            Console.ReadKey();
            Main();
        }


        else
        {
            if(bullets == 0)
        {
            Console.Clear();
            Console.WriteLine("=================");
            Console.WriteLine("| Vyhrál jsi!🎉 |");
            Console.WriteLine("=================");
            Console.ReadKey();
            Main();
        }
        //Text který vypusuje možnosti hry.
        Console.Clear();
        Console.WriteLine("===========================");
        Console.WriteLine("| Last One In The Chamber |");
        Console.WriteLine("===========================");
        Console.WriteLine();
        Console.WriteLine($"Životy: {lifes} ");
        Console.WriteLine($"Střely dohromady: {bullets}");
        Console.WriteLine($"Z toho živé: {lifeRnd} ");
        Console.WriteLine("======================");
        Random rand = new Random();
        int nahoda = rand.Next(1, 3);
        Console.WriteLine("1) Vyhoďit jeden náboj ze zásobíku");
        Console.WriteLine("2) Vystřelit");
        Console.WriteLine("3) Použít předmět");
        Console.WriteLine("4) Přestat hrát");
        Console.WriteLine("======================");
        string Moznost = Console.ReadLine();
        //Vybírání možností 1-4 a volání příslušných metod.
        if(Moznost=="1")
            {
                BulletOut(Moznost, nahoda, lifeRnd,blankRnd,lifes, bullets, Inventory, MinCislo, MaxCislo);
            }
        else if(Moznost=="2")
            {
                Shoot(Moznost, nahoda, lifeRnd,blankRnd,lifes, bullets, Inventory, MinCislo, MaxCislo);
            }
        else if(Moznost=="3")
            {
                Inv(Inventory, lifes, lifeRnd, blankRnd, bullets, MinCislo, MaxCislo);
            }
        else if(Moznost=="4")
            {
                //Vypínač hry
                Console.Clear();
                Console.WriteLine("Vrať se brzy!");
            }
        else
        {
            Console.WriteLine("Invalid Input");
            Hra(lifes, lifeRnd, blankRnd, bullets, Inventory, MinCislo, MaxCislo);
        }
        }
    }

// Výběr obtížnosti a následná generace počtu nábojů podle obtížnosti. 
    static int Nahoda(int MinCislo, int MaxCislo)
    {

    Random rand = new Random();
    int bullets = rand.Next(MinCislo, MaxCislo);
    if(bullets%2 == 0){
        return bullets;
    }

    else
    {
        return 0;

    }
    }
    // 1. metoda která dovoluje hráči vyhodit munici ze zásobníku.
    static void BulletOut(string Moznost, int Nahoda, int LifeRnd, int BlankRnd, int lifes, int bullets, string[] Inventory, int MinCislo, int MaxCislo)

    {

            if(Nahoda==1)
            {
               if(BlankRnd>=1)
               //Systém který odebere život hráči po špatné volbě.
                {
                Console.Clear();
                lifes -= 1;
                Console.WriteLine("Falešný náboj");
                Console.WriteLine("Ztratil si jeden život 💥");
                Console.WriteLine("=========================");
                BlankRnd -= 1;
                bullets -= 1;
                Console.WriteLine("Pro pokračovaní zmáčkni libovolnou klávesu");
                Console.ReadKey();
                Hra(lifes, LifeRnd, BlankRnd, bullets, Inventory, MinCislo, MaxCislo);
                }
                else 
                {
                    BulletOut(Moznost, Nahoda+1, LifeRnd, BlankRnd, lifes, bullets, Inventory, MinCislo, MaxCislo);
                }
            }
            if(Nahoda==2)
            {
                if(LifeRnd>=1)
                {
                Console.Clear();
                Console.WriteLine("Realný náboj");
                Console.WriteLine("O žádné životy si nepřišel 👍");
                Console.WriteLine("=============================");
                //Vybere náhodný item a dá  možnost hráči  si ho uložit do inventáře.
                LifeRnd -= 1;
                bullets -= 1;
                string item = ItemRnd();
                Console.WriteLine($"Dostal jsi {item}");
                Console.WriteLine("Do jakého slotu (1-4) ho chceš uložit? (zadej cokoliv jiného pro zahození)");
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
                Hra(lifes, LifeRnd, BlankRnd, bullets, Inventory, MinCislo, MaxCislo);
                }
                else 
                {
                    BulletOut(Moznost, Nahoda-1, LifeRnd, BlankRnd, lifes, bullets, Inventory, MinCislo, MaxCislo);
                }


      }

    }
//2. metoda která povoluje hráči vystřelit náboj.
    static void Shoot(string Moznost, int Nahoda, int LifeRnd, int BlankRnd, int lifes, int bullets, string[] Inventory, int MinCislo, int MaxCislo)
    {

            {
            if(Nahoda==1)
            {
               if(BlankRnd>=1)
                {
                Console.Clear();
                Console.WriteLine("Falešný náboj");
                Console.WriteLine("O žádné životy si nepřišel 👍");
                Console.WriteLine("============================");
                BlankRnd -= 1;
                bullets -= 1;
                string item = ItemRnd();
                Console.WriteLine($"Dostal jsi {item}");
                 //Vybere náhodný item a dá  možnost hráči  si ho uložit do inventáře.
                Console.WriteLine("Do jakého slotu (1-4) ho chceš uložit? (zadej cokoliv jiného pro zahození)");
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
                Hra(lifes, LifeRnd, BlankRnd, bullets, Inventory, MinCislo, MaxCislo);
                }
                else 
                {
                    Shoot(Moznost, Nahoda+1, LifeRnd, BlankRnd, lifes, bullets, Inventory, MinCislo, MaxCislo);
                }
            }
            //Systém který odebere život hráči po špatné volbě.
            if(Nahoda==2)
            {
                if(LifeRnd>=1)
                {
                lifes -= 1;
                Console.Clear();
                Console.WriteLine("Realný náboj");
                Console.WriteLine("Ztratil si jeden život 💥");
                Console.WriteLine("=========================");
                LifeRnd -= 1;
                bullets -= 1;
                Console.WriteLine("Pro pokračovaní zmáčkni libovolnou klávesu");
                Console.ReadKey();
                Hra(lifes, LifeRnd, BlankRnd, bullets, Inventory, MinCislo, MaxCislo);
                }
                else 
                {
                    Shoot(Moznost, Nahoda-1, LifeRnd, BlankRnd, lifes, bullets, Inventory, MinCislo, MaxCislo);
                }
            }
            
      }

    }
    //3. metoda která dovoluje  hráči otevřít inventář a využít předmět.
    static void Inv(string[]Inventory,int lifes, int lifeRnd, int blankRnd, int bullets, int MinCislo, int MaxCislo)
    {
        Console.Clear();
        for(int i = 0; i < Inventory.Length; i++)
        {
            Console.WriteLine($"Slot {i+1}. {Inventory[i]}");
        }
        Console.WriteLine("==========================");
        Console.WriteLine($"Jaký předmět chceš použít?");
        Console.WriteLine("Pokud chceš odejít bez použití předmětu, napiš 5");
        bool parsed = int.TryParse(Console.ReadLine(), out int volba);
        if(parsed)
        {
            if(volba<5)
            //Všechny  itemy a co dělají.
             {   if(Inventory[volba-1] == "Léky")
                {
                    Console.WriteLine("==========================");
                    Console.WriteLine($"Použil jsi {Inventory[volba-1]}");
                    Console.WriteLine($"Vyléčil ses o jeden život.");
                    lifes = lifes + 1;
                }
                else if(Inventory[volba-1] == "Pivo")
                {
                    Console.WriteLine("==========================");
                    Console.WriteLine($"Použil jsi {Inventory[volba-1]}");
                    Console.WriteLine($"Magicky za zbraně zmizel jeden realný náboj.");
                    if(lifeRnd>0)
                    {
                    lifeRnd = lifeRnd - 1;
                    bullets = bullets - 1;
                    }
                }   
                else if(Inventory[volba-1] == "PivoXL")
                {
                    Console.WriteLine("==========================");
                    Console.WriteLine($"Použil jsi {Inventory[volba-1]}");
                    Console.WriteLine($"Magicky za zbraně zmizel jeden realný a jeden falešný náboj.");
                    if(blankRnd>0)
                    {
                    blankRnd = blankRnd - 1;
                    bullets = bullets - 1;
                    }
                    if(lifeRnd>0)
                    {
                    lifeRnd = lifeRnd - 1;
                    bullets = bullets - 1;
                    }
                }
                else if(Inventory[volba-1] == "Nic")
                {
                    Console.WriteLine("==========================");
                    Console.WriteLine($"Použil jsi {Inventory[volba-1]}");
                    Console.WriteLine($"Překvapivě se nic nestalo, kdo by to byl řekl...");

                }
                Inventory[volba-1] = "Nic";
                Console.WriteLine("Pro pokračování zmáčkni libovolnou klávesu");
                Console.ReadKey();
                Inv(Inventory, lifes, lifeRnd, blankRnd, bullets, MinCislo, MaxCislo);

             }
             else
            {
                Hra(lifes, lifeRnd, blankRnd, bullets, Inventory, MinCislo, MaxCislo);
            }          
            }

            else
            {
                Console.WriteLine("Zkus to znova jo?");
                Console.ReadKey();
                Inv(Inventory, lifes, lifeRnd, blankRnd, bullets, MinCislo, MaxCislo);
            }
            
    }
    //Náhodný výběr předmětů.
static string ItemRnd()
{
    string[] items = {"Léky","Pivo", "PivoXL"};
    Random rand = new Random();
    int item = rand.Next(0, 3);
    return items[item];
}


}

    