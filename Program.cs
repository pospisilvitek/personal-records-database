
int pocetZnaku; 
int maxVaha, maxRokNarozeni; 
string nadpisBenchPress = "Bench press", nadpisDrep = "Dřep", nadpisMrtvyTah = "Mrtvý tah"; 
string? jmeno, prijmeni, vaha, rokNarozeni; 
string vypis; 
string? odstranitID; 
string ID; 
const string CESTA_BENCH_PRESS = "x", CESTA_DREP = "x", CESTA_MRTVY_TAH = "x"; 
char odpovedMenu, odpovedPridatMenu, odpovedZobrazitMenu, odpovedOdebratMenu, odpovedVytvoreniMenu; 
char prvniPismenoJmeno, prvniPismenoPrijmeni, predposledniCisloRokNarozeni,posledniCisloRokNarozeni; 
bool bezet = true; 
bool nalezeno; 

Console.Clear(); 
Menu(); 

void Menu() 
{   
    while(bezet)
    {
        Console.WriteLine("Menu"); 
        Console.WriteLine("------------------------");
        Console.WriteLine("Přidat rekord:       [p]");
        Console.WriteLine("Zobrazit rekordy:    [z]");
        Console.WriteLine("Odebrat rekord:      [o]");
        Console.WriteLine("------------------------");
        Console.WriteLine("Vytvoření souboru:   [v]");
        Console.WriteLine("Ukončení aplikace:   [k]");
        Console.WriteLine("------------------------");

        odpovedMenu = char.ToLower(Console.ReadKey().KeyChar); 
        switch (odpovedMenu) 
        {
            case 'p': 
                Console.Clear(); 
                PridatMenu(); 
                break; 
            
            case 'z':
                Console.Clear();
                ZobrazitMenu();
                break;
            
            case 'o':
                Console.Clear();
                OdebratMenu();
                break;

            case 'v':
                Console.Clear();
                VytvoreniMenu();
                break;
            
            case 'k':
                Console.Clear();
                Console.WriteLine("Na viděnou! \n"); 
                bezet = false; 
                break;

            default: 
                Console.Clear();
                Console.WriteLine("Neplatná volba.");
                Console.ReadKey(); 
                Console.Clear();
                break;
        }
    }
}

void PridatMenu() 
{
    while(true)
    {
        Console.WriteLine("Přidad rekord");
        Console.WriteLine("---------------------");
        Console.WriteLine("Návrat do menu:   [m]");
        Console.WriteLine("---------------------");
        Console.WriteLine("Bench press:      [b]");
        Console.WriteLine("Dřep:             [d]");
        Console.WriteLine("Mrtvý tah:        [t]");
        Console.WriteLine("---------------------");
        odpovedPridatMenu = char.ToLower(Console.ReadKey().KeyChar);

        switch (odpovedPridatMenu)
        {
            case 'm':
                Console.Clear();
                return; 
            
            case 'b':
                Console.Clear();
                Pridat(CESTA_BENCH_PRESS); 
                break;
            
            case 'd':
                Console.Clear();
                Pridat(CESTA_DREP);
                break;
            
            case 't':
                Console.Clear();
                Pridat(CESTA_MRTVY_TAH);
                break;
            
            default:
                Console.Clear();
                Console.WriteLine("Neplatná volba.");
                Console.ReadKey();
                Console.Clear();
                break;
        }
    }
}

void Pridat(string cesta) 
{
    if (!File.Exists(cesta)) 
    {
        Console.Clear();
        Console.WriteLine("Textový soubor, do kterého chcete přidat rekord, neexistuje!");
        Console.ReadKey();
        Console.Clear();
        return; 
    }
    
    while(true) 
    {
        Console.WriteLine("Zadejte jméno (max 10 znaků)");
        Console.WriteLine("----------------------------");
        jmeno = Console.ReadLine(); 
        Console.Clear();

        pocetZnaku = jmeno.Length; 
        if (pocetZnaku > 10) 
        {
            Console.WriteLine("Přesáhli jste max počet znaků!");
            Console.ReadKey();
            Console.Clear();
        }

        else if (string.IsNullOrWhiteSpace(jmeno)) 
        {
            Console.WriteLine("Nic nebylo zadáno!");
            Console.ReadKey();
            Console.Clear();
        }

        else {break;} 
    }

    jmeno = jmeno.Replace(" ", ""); 
    jmeno = char.ToUpper(jmeno[0]) + jmeno.Substring(1).ToLower(); 

    while (true) 
    {
        Console.WriteLine("Zadejte příjmení (max 12 znaků)");
        Console.WriteLine("-------------------------------");
        prijmeni = Console.ReadLine();
        Console.Clear();

        pocetZnaku = prijmeni.Length;
        if (pocetZnaku > 12)
        {
            Console.WriteLine("Přesáhli jste max počet znaků!");
            Console.ReadKey();
            Console.Clear();
        }

        else if (string.IsNullOrWhiteSpace(prijmeni))
        {
            Console.WriteLine("Nic nebylo zadáno!");
            Console.ReadKey();
            Console.Clear();
        }

        else {break;}
    }

    prijmeni = prijmeni.Replace(" ", "");
    prijmeni = char.ToUpper(prijmeni[0]) + prijmeni.Substring(1).ToLower(); 

    while(true) 
    {
        Console.WriteLine("Zadejte váhu (rozmezí: 20 - 300)");
        Console.WriteLine("--------------------------------");
        vaha = Console.ReadLine();
        Console.Clear();
        
        if (string.IsNullOrWhiteSpace(vaha))
        {
            Console.WriteLine("Nic nebylo zadáno!");
            Console.ReadKey();
            Console.Clear();
        }

        else if (int.TryParse(vaha, out maxVaha)) 
        {
            if (maxVaha < 20 || maxVaha > 300) 
            {
                Console.WriteLine("Nedodrželi jste rozmezí!"); 
                Console.ReadKey();
                Console.Clear();
            }

            else {break;}
        }

        else 
        {
            Console.WriteLine("Zadali jste neplatný vstup!"); 
            Console.ReadKey();
            Console.Clear();
        }
    }

    vaha = vaha.Replace(" ", "");

    while(true) 
    {
        Console.WriteLine("Zadejte rok narození (4 znaky)");
        Console.WriteLine("------------------------------");
        rokNarozeni = Console.ReadLine();
        Console.Clear();
        
        if (string.IsNullOrWhiteSpace(rokNarozeni))
        {
            Console.WriteLine("Nic nebylo zadáno!");
            Console.ReadKey();
            Console.Clear();
        }

        else if (int.TryParse(rokNarozeni, out maxRokNarozeni)) 
        {
            if (maxRokNarozeni < 1908 || maxRokNarozeni > 2025) 
            {
                Console.WriteLine("Tolik vám nemůže být..."); 
                Console.ReadKey();
                Console.Clear();
            }

            else {break;}
        }

        else 
        {
            Console.WriteLine("Zadali jste neplatný vstup!"); 
            Console.ReadKey();
            Console.Clear();
        }
    }

    rokNarozeni = rokNarozeni.Replace(" ", "");

    prvniPismenoJmeno = jmeno[0]; 
    prvniPismenoPrijmeni = prijmeni[0];
    predposledniCisloRokNarozeni = rokNarozeni[2]; 
    posledniCisloRokNarozeni = rokNarozeni[3];

    ID = prvniPismenoJmeno.ToString() + prvniPismenoPrijmeni.ToString() + predposledniCisloRokNarozeni.ToString() + posledniCisloRokNarozeni.ToString(); 
    
    string[] kontrolaID = File.ReadAllLines(cesta); 
    
    foreach (var pomoc in kontrolaID)
    {
        string[] kontrolaIDNaPozici = pomoc.Split(',');

        if (kontrolaIDNaPozici[0] == ID)
        {
            Console.Clear();
            Console.WriteLine("Nelze přidat duplicitního uživatele!");
            Console.ReadKey();
            Console.Clear();
            return;
        }
    }

    Console.WriteLine("Vaše ID je: " + ID); 
    Console.ReadKey();
    Console.Clear();

    using (StreamWriter pridat = new StreamWriter(cesta, append: true)) 
    {
        pridat.WriteLine(ID + "," + jmeno + "," + prijmeni + "," + vaha); 
    }

    Console.WriteLine("Rekord byl úspěšně přidán!");
    Console.ReadKey();
    Console.Clear();
}     

void ZobrazitMenu() 
{
    while(true)
    {
        Console.WriteLine("Zobrazit rekordy");
        Console.WriteLine("----------------------------");
        Console.WriteLine("Návrat do menu:          [m]");
        Console.WriteLine("----------------------------");
        Console.WriteLine("Bench press:             [b]");
        Console.WriteLine("Dřep:                    [d]");
        Console.WriteLine("Mrtvý tah:               [t]");
        Console.WriteLine("----------------------------");
        odpovedZobrazitMenu = char.ToLower(Console.ReadKey().KeyChar);
        
        switch (odpovedZobrazitMenu)
        {
            case 'm':
                Console.Clear();
                return;

            case 'b':
                Console.Clear();
                Zobrazit(CESTA_BENCH_PRESS, nadpisBenchPress);
                break;

            case 'd':
                Console.Clear();
                Zobrazit(CESTA_DREP, nadpisDrep);
                break;

            case 't':
                Console.Clear();
                Zobrazit(CESTA_MRTVY_TAH, nadpisMrtvyTah);
                break;

            default:
                Console.Clear();
                Console.WriteLine("Neplatná volba.");
                Console.ReadKey();
                Console.Clear();
                break;
        }
    }
}

void Zobrazit(string cesta, string nadpis) 
{  
    if (!File.Exists(cesta))
    {
        Console.Clear();
        Console.WriteLine("Textový soubor, který chcete zobrazit, neexistuje!");
        Console.ReadKey();
        Console.Clear();
        return; 
    }

    vypis = File.ReadAllText(cesta);

    if (string.IsNullOrWhiteSpace(vypis)) 
    {
        Console.Clear();
        Console.WriteLine("Soubor je prázdný.");
        Console.ReadKey();
        Console.Clear();
        return; 
    }

    string[] format = File.ReadAllLines(cesta); 
    var seraditSoubor = format.Select(line => 
    {
        string[] casti = line.Split(","); 
        int vaha = int.Parse(casti[3]);  
        return new {Id = casti[0], Jméno = casti[1], Příjmení = casti[2], Váha = vaha}; 
    }).OrderByDescending(x => x.Váha).ToList(); 
    
    Console.WriteLine(nadpis); 
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("{0,-4} | {1,-10} | {2,-12} | {3,-5}", "ID", "Jméno", "Příjmení", "Váha"); 
    Console.WriteLine("----------------------------------------");

    foreach (var zaznam in seraditSoubor) 
    {
        Console.WriteLine("{0,-4} | {1,-10} | {2,-12} | {3,-5}", zaznam.Id, zaznam.Jméno, zaznam.Příjmení, zaznam.Váha + "kg"); 
    }

    Console.ReadKey();
    Console.Clear();
}

void OdebratMenu() 
{
    while(true)
    {
        Console.WriteLine("Odebrat rekord");
        Console.WriteLine("----------------------------");
        Console.WriteLine("Návrat do menu:          [m]");
        Console.WriteLine("----------------------------");
        Console.WriteLine("Bench press:             [b]");
        Console.WriteLine("Dřep:                    [d]");
        Console.WriteLine("Mrtvý tah:               [t]");
        Console.WriteLine("----------------------------");
        odpovedOdebratMenu = char.ToLower(Console.ReadKey().KeyChar);
        
        switch (odpovedOdebratMenu)
        {
            case 'm':
                Console.Clear();
                return;

            case 'b':
                Console.Clear();
                Odebrat(CESTA_BENCH_PRESS);
                break;

            case 'd':
                Console.Clear();
                Odebrat(CESTA_DREP);
                break;

            case 't':
                Console.Clear();
                Odebrat(CESTA_MRTVY_TAH);
                break;

            default:
                Console.Clear();
                Console.WriteLine("Neplatná volba.");
                Console.ReadKey();
                Console.Clear();
                break;
        }
    }
}

void Odebrat(string cesta) 
{
    if (!File.Exists(cesta)) 
    {
        Console.Clear();
        Console.WriteLine("Textový soubor, z kterého chcete odstranit rekord, neexistuje!");
        Console.ReadKey();
        Console.Clear();
        return;
    }
    
    vypis = File.ReadAllText(cesta); 
    
    if (string.IsNullOrWhiteSpace(vypis)) 
    {
        Console.Clear();
        Console.WriteLine("Soubor je prázdný.");
        Console.ReadKey();
        Console.Clear();
        return;
    }

    while (true) 
    {
        string[] format = File.ReadAllLines(cesta); 
        
        Console.WriteLine("Zadejte ID, které chcete odstranit.");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("{0,-4} | {1,-10} | {2,-12} | {3,-5}", "Id", "Jméno", "Příjmení", "Váha"); 
        Console.WriteLine("----------------------------------------");

        for (int i = 0; i < format.Length; i++) 
        {   
            string [] casti = format[i].Split(","); 
            Console.WriteLine("{0,-4} | {1,-10} | {2,-12} | {3,-5}", casti[0], casti[1], casti[2], casti[3] + "kg"); 
        }

        Console.WriteLine("----------------------------------------");

        odstranitID = Console.ReadLine(); 

        if (string.IsNullOrWhiteSpace(odstranitID)) 
        {
            Console.Clear();
            Console.WriteLine("Nic nebylo zadáno!");
            Console.ReadKey();
            Console.Clear();
            continue; 
        }

        nalezeno = false; 

        foreach (var pomoc in format) 
        {
            string[] kontrolaIDNaPozici = pomoc.Split(','); 
            if (kontrolaIDNaPozici[0] == odstranitID) 
            {
                nalezeno = true;
                break; 
            }
        }

        if (!nalezeno) 
        {
            Console.Clear();
            Console.WriteLine("Zadané ID nebylo nalezeno!");
            Console.ReadKey();
            Console.Clear();
            continue; 
        }

        var smazaniRadku = File.ReadLines(cesta).Where(line => line.Split(",")[0] != odstranitID).ToList(); 

        using (StreamWriter odebrat = new StreamWriter(cesta, append: false)) 
        {
            foreach (var radek in smazaniRadku)
            {
                odebrat.WriteLine(radek); 
            }
        }

        Console.Clear();
        Console.WriteLine("Rekord byl úspěšně odstraněn.");
        Console.ReadKey();
        Console.Clear();
        return; 
    }
}

void VytvoreniMenu() 
{
    while(true)
    {
        Console.Clear();
        Console.WriteLine("Vytvoření souboru");
        Console.WriteLine("------------------");
        Console.WriteLine("Menu:          [m]");   
        Console.WriteLine("------------------");
        Console.WriteLine("Bench press:   [b]");
        Console.WriteLine("Dřep:          [d]");
        Console.WriteLine("Mrtvý tah:     [t]");
        Console.WriteLine("------------------");

        odpovedVytvoreniMenu = char.ToLower(Console.ReadKey().KeyChar);

        switch (odpovedVytvoreniMenu)
        {
            case 'm':
                Console.Clear();
                return;

            case 'b':
                Console.Clear();
                Vytvoreni(CESTA_BENCH_PRESS);
                break;

            case 'd':
                Console.Clear();
                Vytvoreni(CESTA_DREP);
                break;

            case 't':
                Console.Clear();
                Vytvoreni(CESTA_MRTVY_TAH);
                break;

            default:
                Console.Clear();
                Console.WriteLine("Neplatná volba.");
                Console.ReadKey();
                Console.Clear();
                break;
        }
    }
}

void Vytvoreni(string cesta) 
{
    if (File.Exists(cesta)) 
    {
        Console.WriteLine("Soubor již existuje!");
        Console.ReadKey();
        Console.Clear();
    }

    else 
    {
        using (StreamWriter writer = new StreamWriter(cesta)) 
        Console.WriteLine("Soubor byl úspěšně vytvořen!");
        Console.ReadKey();
        Console.Clear();
    }
}