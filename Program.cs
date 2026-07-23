class LastOneInTheChamber
{




    static void Main()  
    {
    Console.Clear();
    int lifes = 3;
    int BulletMax = 10;
    int BulletLifeMax = 5;
    Console.WriteLine("Chces tutorial? Y/N");
    string Ano = Console.ReadLine();
    if(Ano == "y"|Ano == "Y")
    {
    Tutorial(lifes);
    }
    else{
    ZacatekHry(lifes);
    }
    }

    static void Tutorial(int lifes)
    {
        Console.WriteLine("Pokud vyhodis naboj ktery neni zivy, prijdes o zivot.");
        Console.WriteLine("Pokud vystrelis zivy naboj, prijdes taky o zivot.");
        Console.WriteLine("Pokud vystrelis mrtvy naboj nebo vyhodis zivy, o zadne zivoty neprijdes.");
        Console.WriteLine("Hodne stesti!");
        Console.ReadKey();
        ZacatekHry(lifes);
    }
    static void ZacatekHry(int lifes)

        {
        int bullets = Nahoda();
        if(bullets == 0)
        {
            ZacatekHry(lifes);
        }
        else 
        {

            Hra(lifes, bullets/2, bullets/2, bullets);
        }
        }
    static void Hra(int lifes, int lifeRnd, int blankRnd, int bullets)
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
            if(bullets < 1)
        {
            Console.Clear();
            Console.WriteLine("Vyhrál jsi!");
            Console.ReadKey();
            Main();
        }
        Console.Clear();
        Console.WriteLine($"Máš {lifes} zivoty");
        Console.WriteLine($"V komore jsou {bullets} strely");
        Console.WriteLine($"A {lifeRnd} zivych strel");
        Random rand = new Random();
        int nahoda = rand.Next(1, 3);
        Console.WriteLine("1) Vyhod jeden náboj z komory");
        Console.WriteLine("2) Vystrelit");
        Console.WriteLine("3) Prestat");
        string Moznost = Console.ReadLine();
        if(Moznost=="1")
            {
                BulletOut(Moznost,nahoda, lifeRnd,blankRnd,lifes, bullets);
            }
        if(Moznost=="2")
            {
                Shoot(Moznost,nahoda, lifeRnd,blankRnd,lifes, bullets);
            }
        if(Moznost=="3")
            {
                Console.Clear();
                Console.WriteLine("Vrat se brzy!");
            }
        else
        {
            Console.WriteLine("Invalid Input");
            Hra(lifes, lifeRnd, blankRnd, bullets);
        }
        }
    }

    static int Nahoda()
    {

    Random rand = new Random();
    int bullets = rand.Next(2, 11);
    if(bullets%2 == 0){
        return bullets;
    }

    else
    {
        return 0;

    }
    }
    static void BulletOut(string Moznost, int Nahoda, int LifeRnd, int BlankRnd, int lifes, int bullets)

    {

            if(Nahoda==1)
            {
               if(BlankRnd>=1)
                {
                Console.Clear();
                lifes -= 1;
                Console.WriteLine("mrtva");
                Console.WriteLine("Ztratil si jeden zivot");
                BlankRnd -= 1;
                bullets -= 1;
                Console.WriteLine("Pro pokracovani zmackni libovolnou klavesu");
                Console.ReadKey();
                Hra(lifes, LifeRnd, BlankRnd, bullets);
                }
                else 
                {
                    BulletOut(Moznost, Nahoda+1, LifeRnd, BlankRnd, lifes, bullets);
                }
            }
            if(Nahoda==2)
            {
                if(LifeRnd>=1)
                {
                Console.Clear();
                Console.WriteLine("ziva");
                Console.WriteLine("Netratil si jeden zivot");
                LifeRnd -= 1;
                bullets -= 1;
                Console.WriteLine("Pro pokracovani zmackni libovolnou klavesu");
                Console.ReadKey();
                Hra(lifes, LifeRnd, BlankRnd, bullets);
                }
                else 
                {
                    BulletOut(Moznost, Nahoda-1, LifeRnd, BlankRnd, lifes, bullets);
                }


      }

    }

    static void Shoot(string Moznost, int Nahoda, int LifeRnd, int BlankRnd, int lifes, int bullets)
    {

            {
            if(Nahoda==1)
            {
               if(BlankRnd>=1)
                {
                Console.Clear();
                Console.WriteLine("mrtva");
                Console.WriteLine("Neztratil si jeden zivot");
                BlankRnd -= 1;
                bullets -= 1;
                Console.WriteLine("Pro pokracovani zmackni libovolnou klavesu");
                Console.ReadKey();
                Hra(lifes, LifeRnd, BlankRnd, bullets);
                }
                else 
                {
                    Shoot(Moznost, Nahoda+1, LifeRnd, BlankRnd, lifes, bullets);
                }
            }
            if(Nahoda==2)
            {
                if(LifeRnd>=1)
                {
                lifes -= 1;
                Console.Clear();
                Console.WriteLine("ziva");
                Console.WriteLine("Ztratil si jeden zivot");
                LifeRnd -= 1;
                bullets -= 1;
                Console.WriteLine("Pro pokracovani zmackni libovolnou klavesu");
                Console.ReadKey();
                Hra(lifes, LifeRnd, BlankRnd, bullets);
                }
                else 
                {
                    Shoot(Moznost, Nahoda-1, LifeRnd, BlankRnd, lifes, bullets);
                }
            }
            
      }

    }
}

    
