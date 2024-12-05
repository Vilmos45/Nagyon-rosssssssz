using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
        /* Függvények */
        

        void Félkör(int n = 50)
        {
            Tollat(le);
            Ív(180, n);
            Jobbra(180);
            Tollat(fel);
            Ív(-180, n);
            Jobbra(180);
        }

        void Lábnyom_sarka(int n = 50/4)
        {
            Tollat(le);
            Jobbra(-90);
            Félkör(n / 4);
            Tollat(le);
            Jobbra(90);
            Lépj(2 * n /4);
            Balra(135);
            Kitölt();
            Balra(-45);
            Tollat(fel);
            Balra(90);
            Lépj(2 * n / 4);
            Jobbra(180);
        }

        void Lábnyom_eleje(int n = 50)
        {
            Tollat(le);
            Téglalap(n / 2, n / 2);
            Balra(-45);
            Kitölt();
            Balra(45);
            Lépj(n / 2);
            Jobbra(90);
            Lépj(n / 2);
            Jobbra(90);
            Lábnyom_sarka(n);
            Jobbra(90);
            Lépj(n / 2);
            Jobbra(90);
            Tollat(fel);
        }

        void Kitölt() {
            Tollat(fel);
            Lépj(3);
            Tölt(Color.Black);
            Lépj(-3);
            Tollat(le);
        }

        void Téglalap(int n = 25, int o = 50)
        {
            Tollat(le);
            for (int i = 0; i < 2; i++)
            {
                Lépj(n);
                Jobbra(90);
                Lépj(o);
                Jobbra(90);
            }
            Tollat(fel);
        }

        void Lábnyom(int n = 50)
        {
            Tollat(le);
            Lábnyom_sarka(n);
            Tollat(fel);
            Jobbra(90);
            Lépj(n/5);
            Jobbra(-90);
            Tollat(le);
            Lábnyom_eleje(n);
            Balra(90);
            Lépj(n / 5);
            Jobbra(90);
            Tollat(fel);
        }

        void Nyomok(int n= 50, int o = 4) // o == darab
        {
            o = o / 2;
            Nyomok_alsó_vasútállomás(n, o); // gondosan ki van kommentelve
        }

        void Nyomok_alsó_vasútállomás(int n, int o) //   Vonat-Karesz
        {
            for (int i = 0; i < o; i++)
            {
                Lábnyom(n); //alsó vasútállomás
                Lépj(n / 2);
                Jobbra(90);
                Lépj(n / 3 * 2);
                Jobbra(-90);
                Lábnyom(n); // felső vasútállomás
                Jobbra(180);
                Lépj(n / 2 * 3);
                Jobbra(-90);
                Örs_vezér_tere(n); // itt mindig felvesz 2-4 perc késést
                
            }
            Nyomok_felső_vasútállomás(n); // továbbmegy
            Kocsiszín(); // vége
        }

        void Örs_vezér_tere(int oldal) // oldal = Zuglói || Kőbányai
        {
            if (!Kilépek_e_a_pályáról(oldal)) // ha !Vége_van_a_világnak && !A_Föld_lapos
            {
                Lépj(oldal);
            }
            Jobbra(-90);
        }

        void Nyomok_felső_vasútállomás(int n) //   Vonat-Karesz
        { 
            Jobbra(90);
            Lépj(-n); // visszamegy a kocsiszínbe
        }

        void Kocsiszín()
        {
            Jobbra(-90);
        }

        void Zongora (int n = 50, int o = 6)
        {
            for (int i = 0; i < o; i++)
            {
                Zongora_oktáv(n);
            }
        }

        void Zongora_oktáv (int n = 50)
        {
            Zongora_fekete(n);
            Zongora_fekete(n);
            Zongora_fehér(n);
            Zongora_fekete(n);
            Zongora_fekete(n);
            Zongora_fekete(n);
            Zongora_fehér(n);
        }

        void Zongora_fekete(int n)
        {
            Tollat(le);
            Tollvastagság(1);
            Lépj(2*n);
            Jobbra(90);
            Lépj(n/2);
            Jobbra(90);

            if (n >= 25) {
                Tollvastagság(15);
            }else if (n < 10)
            {
                Tollvastagság(4);
            } else if(  10  > n && n < 25)
            {
                Tollvastagság(10);
            }
            

            Lépj(2*n / 5 * 3);
            Tollvastagság(1);
            Lépj(2 * n / 5 * 2);
            Jobbra(90);
            Lépj(n / 2);
            Jobbra(90);
            Tollat(fel);
            Jobbra(90);
            Lépj(n / 2);
            Jobbra(-90);
            Tollat(le);
        }
        void Zongora_fehér(int n)
        {
            Tollvastagság(1);
            for (int i = 0; i < 2; i++)
            {
                Lépj(2*n);
                Jobbra(90);
                Lépj(n/2);
                Jobbra(90);
            }

            Tollat(fel);
            Jobbra(90);
            Lépj(n / 2);
            Jobbra(-90);
            Tollat(le);
        }


        void FELADAT()
		{

            Zongora(50, 3);

		}
	}
}


/* HASZNÁLHATÓ PARANCSOK:
 
void Előre(double d):
    Előre lép d hosszan, és ha le van téve a toll, akkor vonalat is húz maga után. 
    Negatív szám esetén hátra lép.

void Hátra(double d): 
    Hátra lép d hosszan. 
    Negatív szám esetén előre lép.

void Jobbra(double d):
    Jobbra fordul d fokot. 
    Negatív szám esetén balra fordul annyit.

void Balra(double d):
    Balra fordul d fokot. 
    Negatív szám esetén jobbra fordul annyit.

void Pihi(int i):
    Karesz várni fog i ezredmásodpercet, mielőtt továbbrajzol.

void Tollat(bool b): 
    Ha b igaz, akkor leteszi a tollat és vonalat húz, mikor mozog. 
    Ha b hamis, akkor felemeli a tollat és nem húz vonalat, mikor mozog.
    a fel és le kifejezések logikai konstansok, tehát a Tollat(fel) fel fogja emelni a tollat, a Tollat(le) pedig leteszi a tollat.

Color Milyen_szín_van_itt():
    Megmondja, hogy Karesz milyen színű területen áll. A visszaadott érték Color típusú!

void Tölt(Color c, bool beszólós = true):
    A megadott c színnel kitölti azt a másik színnel körülhatárolt azonos színű régiót, ahol van. 
    Amennyiben a felület már eleve ilyen színű, akkor felugrik egy idegesítő ablak
    Ha van egy további, hamis argumentum, ez lenne a "beszólós paraméter" értéke, akkor nem ugrik fel popup ablak.

void Tollszín(Color c):
    Átállítja a rajzolás színét c színre. A megadott paraméter Color típusú! 
    Tehát pl. az lehet egy lehetséges bemenet, hogy Color.Red

void Tollszín(int i): 
    Hasonló a fentihez, de néhány színhez sorszám van rendelve és a megadott i-edik színt választja ilyenkor. Hasznos olyankor, amikor random vagy összevissza színekkel kell valamit kiszínezni!

void Tollvastagság(float v): 
    Átállítja a toll vastagságát v vastagságúra. 

void Ív(double f, double r):
    Elindul egy r sugarú körön úgy, hogy a végén f fokkal lesz elfordulva jobbra. Negatív érték esetén balra rajzolja az ívet.
        
void Ív((double, double)fr):
    Ugyanaz, mint az előbb, de egy double-double párral dolgozik. Az első a fok, a második a sugár.
 
bool Kilépek_e_a_pályáról(double d): 
    megmondja, hogy d hosszú előremenés után Karesz kilépne-e a pályáról.
 
void Fordulj(double d):
    Ez valójában a Jobbra(d) parancs.

void Lépj(double d): 
    ez valójában az Előre(d) parancs
 

- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
A következő parancsok ún. Bezier-görbék rajzolására adnak lehetőséget. Ezeknek viszont nézz utána, mert nem nagyon lehet itt összefoglalni őket...

void Bezier(double ilyen_erővel_indul,
            double erre_néz_érkezéskor,
            double ilyen_erővel_érkezik,
            double az_érkezési_pont_jelenleg_ilyen_irányban_van,
            double az_érkezési_pont_ilyen_messze_van, 
            bool kontrolpont = false,
            bool kontrolszakasz = false
            ) 

void Bezier_3_pontos( (double, double) erre_indul, 
                      (double, double) erről_érkezik, 
                      (double, double) cél,
                      bool kontrolpont = false,
                      bool kontrolszakasz = false
                      )

void Bezier_3_pontos( Pont erre_indul, Pont erről_érkezik, Pont cél,
                      bool kontrolpont = false,
                      bool kontrolszakasz = false
                      ) 
 */
