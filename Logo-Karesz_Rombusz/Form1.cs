using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static LogoKaresz.Form1;

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
            Kitölt(Color.Black);
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
            Kitölt(Color.Black);
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

        void Kitölt( Color p ) {
            Tollat(fel);
            Lépj(5);
            Tölt(p);
            Lépj(-5);
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
            Jobbra(90);
            Lépj(-n); // továbbmegy
            Jobbra(-90);
        }

        void Örs_vezér_tere(int oldal) // oldal = Zuglói || Kőbányai
        {
            if (!Kilépek_e_a_pályáról(oldal)) // ha !Vége_van_a_világnak && !A_Föld_lapos
            {
                Lépj(oldal);
            }
            Jobbra(-90);
        }

       

     

        void Zongora (int n = 50, int o = 6)
        {
            for (int i = 0; i < o; i++)
            {
                Széles_Ultrahang(n);
            }
        }

        void Széles_Ultrahang (int n = 50) // ez a jövő 
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


        void Fekete_négyzet(double n = 50)
        {
            for (int i = 0; i < 4; i++)
            {
                Lépj(n);
                Jobbra(90);
            }
            Alakzat_kifest(6,n,Color.Black);
        }

        

        void Hermann_sor(double n = 50, int o = 6) // o == db, n == hossz
        {
            for(int i = 0;i < o; i++)
            {
                Fekete_négyzet (n);
                Tollat (fel);
                Jobbra(90);
                Lépj (n * 1.25);
                Jobbra(-90);
                Tollat(le);
            }
            Tollat(fel);
            for (int i = 0; i < o; i++)
            {
                Jobbra(-90);
                Előre(n * 1.25);
                Jobbra(90);
            }
            Tollat(le); 
            
        }

        void Hermann_rács(int o = 5, int p = 5, int n = 50)// o == db sor, p == db oszlop, 
        {
            for (int i = 0; i < o; i++)
            {
                Hermann_sor(n, p);
                Tollat(fel);
                Lépj(n * 1.25);
                Tollat(le);
            }
            Tollat(fel);
            Lépj(o * -1.25 * n);
        }
        
        void Csempe_sor(double n, int o, Color p, Color q, int s) // n == hossz, o == db, p/q == eggyik/másik szín, s == mivel kezdejn
        {
            Color r = p;
            if (s == 1)
            {
                r = q;
            }
            for ( int i = 0;i < o; i++)
            {
                
                Négyzet(n, r);
                if (r == p)
                {
                    r = q;
                }
                else
                {
                    r = p;
                }
                
                Tollat(fel);
                Jobbra(90);
                Előre(n);
                Jobbra(-90);
                Tollat(le);
            }
            Tollat(fel);
            Balra(90);
            Előre(n * o);
            Jobbra(90);
            Tollat(le);
        }

        void Csempézés(double n, int sor, int oszlop, Color p, Color q)
        {
            int s = 0;
            for (int i = 0; i < sor ; i++)
            {
                if (s == 0)
                {
                    s++;
                }
                else
                {
                    s = 0;
                }
                Csempe_sor(n, sor, p, q, s);
                Color t = q;
                q = p;
                q = t;
                Tollat(fel);
                Lépj(n);
                Tollat(le);
            }
            Tollat(fel);
            Jobbra(180);
            Lépj(sor * n);
            Jobbra(-180);
            Tollat(le);
        }

        void Lépj_oda_vissza(double n)
        {
            Lépj(n);
            Lépj(-n);
        }

        void Odavissza_níl(double n)
        {
            
            Jobbra(90);
            Lépj(n / 2);
            Jobbra(180-45);
            Lépj_oda_vissza(n / 4);
            Jobbra(90);
            Lépj_oda_vissza(n / 4);
            Jobbra(-45);
            Lépj(n);

            Jobbra(180 - 45);
            Lépj_oda_vissza(n / 4);
            Jobbra(90);
            Lépj_oda_vissza(n / 4);
            Jobbra(-45);
            Lépj(n / 2);
            Jobbra(-90);
        }


        void Kocka_nyíl(double n)
        {
            Tollvastagság(7);
            Jobbra(-45);
            Odavissza_níl(n);
            Jobbra(90);
            Odavissza_níl(n);
            Jobbra(-45); 
        }

        void Nyílsor(double n, int db)
        {
            for (int i = 0; i < db; i++)
            {
                Tollat(le);
                Kocka_nyíl(n);
                Tollat(fel);
                Jobbra(90);
                Lépj(n* 0.86);
                Jobbra(-90);
            }
            
            Jobbra(-90);
            Lépj(db * n * 0.86);
            Jobbra(90);
        }

        void Nyílminta(double n, int sor, int oszlop)// sor == db sor, oszlop == db oszlop
        {

            for (int i = 0; i < sor; i++)
            {

                Nyílsor(n, oszlop);

                Lépj(n*0.86);

            }
            Lépj(-n * 0.86 * sor);
        }

        void Mozaik_harmad(double n)
        {
            Jobbra(60);
            Lépj(n / 2);
            Jobbra(-120);
            Lépj(n / 4);
            Jobbra(-60);
            Lépj(n / 4);
            Jobbra(60);
            Lépj(n / 4);
            Balra(60);
            Lépj(n / 4);

            Jobbra(-120);
            Lépj(n / 2);

            Jobbra(60);
            Jobbra(180);
        }

        void Mozaik_db(double n)
        {
            for (int i = 0; i < 3; i++)
            {
                Mozaik_harmad(n);
                Jobbra(120);
            }
        }

        void Mozaik_sor (double n, int o)
        {
            for(int i = 0; i < o; i++)
            {
                Tollat(le);
                Mozaik_db(n);
                Tollat(fel);
                Jobbra(60);
                Lépj(n/8 * 6);
                Jobbra(-60);
            }
            Jobbra(60);
            Lépj(-n / 8 * 6 * o);
            Jobbra(-60);
        }

        void Mozaik(double n, int sor, int oszlop)
        {
            for (int i = 0; i < sor; i++)
            {
                Mozaik_sor(n, oszlop);
                Lépj(n / 8 * 6);
            }
            Lépj(-n / 8 * 6 * sor);
        }

        void Mozaik_háló_db(double n)
        {
            Ív(90, n);
            Jobbra(-90);
            Ív(-180, n);
            Jobbra(-90);
            Ív(90, n);
            Jobbra(180);
        }

        void Mozaik_szem(double n)
        {
            for(int i = 0; i < 4; i++)
            {
                Mozaik_háló_db(n);
                Tollat(fel);
                Lépj(2 * n);
                Jobbra(90);
                Tollat(le);
            }
        }

        void Mozaik_szem_sor(double n, int db)
        {
            for (int i = 0; i< db; i++)
            {
                Tollat(le);
                Mozaik_szem(n);
                Tollat(fel);
                Lépj(2 * n);
                Jobbra(90);
                Lépj(2 * n);
                Jobbra(-90);
            }
            for (int i = 0; i < 2; i++)
            {
                Balra(90);
                Lépj(2 * db * n);
            }
            Jobbra(180);
        }

        void Mozaik_szem_háló (double n, int sor, int oszlop)
        {
            for( int i = 0;i< sor; i++)
            {
                Mozaik_szem_sor(n, oszlop);
                Lépj(4 * n);
            }
            Lépj(-4 * n * sor);
        }

        void Mozaik_asztal_alap(double n = 50)
        {
            n = n / 3;
            Jobbra(-90);
            Lépj(n/2);
            Jobbra(90);
            for(int i = 0; i < 2; i++)
            {
                Jobbra(90);
                Lépj(n);
                Jobbra(-90);
                Ív(90, n);
                Jobbra(-90);
                Lépj(n);
                Jobbra(90);
                Ív(90, -n);
            }
            Jobbra(90);
            Lépj(n / 2);
            Jobbra(-90);
            Kitölt(Color.Brown);
        }

        void Mozaik_asztal_sor(double n, int db)
        {
            for (int i = 0; i < db ; i++)
            {

                Tollat(le); 
                Mozaik_asztal_alap(n);
                Tollat(fel);
                Jobbra(90);
                Lépj(n* 1.15);
                Jobbra(-90);
            }
            Jobbra(-90);
            Lépj(n * db * 1.15);
            Jobbra(90);
        }

        void Mozaik_asztal (double n, int sor, int oszlop)
        {
            for (int i = 0; i < sor; i++)
            {
                Mozaik_asztal_sor(n, oszlop);
                Lépj(n * 1.15);
            }
            Lépj(n * -1.15 * sor);
            Lépj(-n * 0.15);
            Jobbra(90);
            Tollat(le);
            Lépj(-n / 2);
            Lépj(n * 1.15 * (oszlop - 1));
            Lépj(n * 1.25);
            Jobbra(-90);
            Lépj(n * 1.15 * (sor - 1));
            Lépj(n * 1.25);
            Jobbra(-90);
            Lépj(n * 1.3 * (oszlop - 1));
            Lépj(n * 1.25);
            Jobbra(-90);
            Lépj(n * 1.15 * (sor - 1));
            Lépj(n * 1.25);
            Jobbra(-90);
            Lépj(n);
            Jobbra(-90);
            Kitölt(Color.Yellow);

        }

        void Három_db_szög(double n, int l)
        {
            Jobbra(90);
            if (l != 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    Lépj(n);
                    Jobbra(-120);
                }  
            }
            else
            {
                Tollat(fel);
                Lépj(n);
                Jobbra(-120);
                Tollat(le);
                for (int i = 0; i < 2; i++)
                {
                    Lépj(n);
                    Jobbra(-120);
                }
            }
            Jobbra(-90);
        }

        void Cipzar_db (double n, Color szín)
        {
            Tollvastagság(2);
            Lépj(n);
            Jobbra(90);
            Tollat(fel);
            Lépj(n);
            Jobbra(90);
            Tollat(le);
            for (int i = 0; i < 2; i++)
            {
                Lépj(n);
                Jobbra(90);
            }
            Lépj(n);
            Három_db_szög(n, 1);
            Jobbra(50);
            Tollat(fel);
            Lépj(n * 0.25);
            Kitölt(szín);
            Tollat(fel);
            Lépj(-n * 0.25);
            Jobbra(-50);
            Lépj(-n);
            Tollat(le);
        }

        void Cipzar_sor1(double n, int db)
        {
            int jsz = 0;
            for (int i = 0; i < db; i++)
            {
                if (jsz == 0)
                {
                    Cipzar_db(n, Color.Green);
                    Jobbra(90);
                    Lépj(n);
                    Jobbra(-90);
                    jsz++;
                }
                else if (jsz == 1)
                {
                    Cipzar_db(n, Color.Purple);
                    Jobbra(90);
                    Lépj(n);
                    Jobbra(-90);
                    jsz = 0;
                }
            }
            Jobbra(90);
            Lépj(-n * db);
            Jobbra(-90);
        }

        void Cipzar_sor2 (double n, int db)
        {
            Jobbra(90);
            Lépj(n * db);
            Jobbra(90);
            int jsz = 0;
            for (int i = 0; i < db; i++)
            {
                if (jsz == 0)
                {
                    Cipzar_db(n, Color.Red);
                    Jobbra(90);
                    Lépj(n);
                    Jobbra(-90);
                    jsz++;
                }
                else if (jsz == 1)
                {
                    Cipzar_db(n, Color.Yellow);
                    Jobbra(90);
                    Lépj(n);
                    Jobbra(-90);
                    jsz = 0;
                }
            }
            Jobbra(-180);
        }

        void Cipzár_dupla (double n , int db)
        {
            Tollvastagság(2);
            Cipzar_sor1 (n, db);
            Tollat(fel);
            Lépj(2.85 * n);
            Jobbra(90);
            Lépj(n * 0.5);
            Jobbra(-90);
            Tollat(le);
            Cipzar_sor2(n, db);
            Tollat(fel);
            Lépj(2.85 * -n);
            Jobbra(90);
            Lépj(-n * 0.5);
            Jobbra(-90);
            Tollat(le);
        }

        void Cipzár_fal (double n, int sor, int oszlop)
        {
            for (int i = 0; i < sor; i++)
            {
                Cipzár_dupla(n, oszlop);
                Tollat(fel);
                Lépj(2.85 * n);
                Jobbra(90);
                Lépj(n * 0.5);
                Jobbra(-90);
                Tollat(le);
            }

            for (int i = 0; i < sor; i++)
            {
                Tollat(fel);
                Lépj(2.85 * -n);
                Jobbra(90);
                Lépj(n * -0.5);
                Jobbra(-90);
                Tollat(le);
            } 
        }

        void Háromszög (double n, Color p)
        {
            for ( int i = 0; i < 3; i++)
            {
                Lépj(n);
                Jobbra(120);
            }
            Jobbra(30);
            Tollat(fel);
            Lépj(n * 0.25);
            Tölt(p, false);
            Tollat(fel);
            Lépj(-n * 0.25);
            Jobbra(-30);
        }

        void Hatszög(double n, Color p)
        {
            
            Jobbra(120+180);
            for ( int i = 0;i < 6; i++)
            {
                
                Lépj(n);
                Jobbra(60);
            }
            Jobbra(50);
            Tollat(fel);
            Lépj(n * 0.25);
            Tölt(p, false);
            Tollat(fel);
            Lépj(-n * 0.25);
            Jobbra(10);
        }

        void Téglalap_kitöltve(double n, double o, Color p)
        {
            for (int i = 0; i < 2; i++)
            {
                Lépj(n);
                Jobbra(90);
                Lépj(o);
                Jobbra(90);
            }
            Jobbra(50);
            Tollat(fel);
            Lépj(n * 0.25);
            Tölt(p, false);
            Tollat(fel);
            Lépj(-n * 0.25);
            Jobbra(-50);
        }

        void Mozaik_korong(double n)
        {
            Tollvastagság(2);
            Hatszög(n / 2, Color.Green);
            Tollat(fel);
            Jobbra(150);
            int szín = 0;
            for (int i = 0 ; i < 6; i++)
            {
                
                Tollat(le);
                if (szín == 0)
                {
                    Háromszög(n, Color.Red);
                    szín++;
                }else if (szín == 1)
                {
                    Háromszög(n, Color.Blue);
                    szín = 0;
                }
                Jobbra(60);
                Tollat(le);
                Téglalap_kitöltve(n, n / 2, Color.Yellow);
                Jobbra(90);
                Lépj(n / 2);
                Jobbra(-90);
            }
            Jobbra(-150);
        }

        void Mozaik_korong_sor(double n, int db)
        {
            for (int i = 0; i < db; i++)
            {
                Tollat(le);
                Mozaik_korong(n);
                Tollat(fel);
                Jobbra(90);
                Lépj(1.85 * n);
                Jobbra(-90);
            }
            Tollat(fel);
            Jobbra(90);
            Lépj(-1.85* n  * db);
            Jobbra(-90);
        }

        void Mozaik_korong_rács (double n, int sor, int oszlop)
        {
            for(int i = 0;i < sor; i++)
            {
                Tollat(le);
                Mozaik_korong_sor(n, oszlop);
                Tollat(fel);
                Jobbra(30);
                Lépj(1.85 * n);
                Jobbra(-30);
            }
            Jobbra(30);
            Lépj(1.85 * n * -oszlop);
            Jobbra(-30);
        }

        void Alakzat_kifest(double n, double o, Color p) // o == fok, n == hossz, p == szín
        {
            Tollat(fel);
            Jobbra(o);
            Előre(n);
            Tölt(p, false);
            Előre(-n);
            Jobbra(-o);
            Tollat(le);
        }


       



        void Katyvasz_alapsor(double n, int db)
        {
            for(int i = 0; i < db; i++)
            {
                Tollat(le);
                Négyzet(n, Color.Green);
                Tollat(fel);
                Jobbra(90);
                Lépj(n * 2);
                Jobbra(-90);
            }
            Jobbra(90);
            Lépj(n * -db * 2);
            Jobbra(-90);
            Tollat(le);
        }

        void Katyvasz_felsősor (double n, int db, int x, int xedik) // x = hányadik piros
        {
            for (int i = 0; i < db; i++)
            {
                Tollat(le);
                
                if (xedik == x)
                {
                    Négyzet(n, Color.Red);
                    xedik = 0;
                }
                else
                {
                    Négyzet(n, Color.White);
                    xedik++;
                }
                
                Tollat(fel);
                Jobbra(90);
                Lépj(n     * 1.5  );
                Jobbra(-90);
            }
            Jobbra(90);
            Lépj(n * -db *  1.5        );
            Jobbra(-90);
            Tollat(le);
        }

        void Mozaik_alap_katyvasz(double n, int sor, int oszlop)
        {
            for (int i = 0;i < sor; i++)
            {
                Tollat(le);
                Katyvasz_alapsor(n, oszlop);
                Tollat(fel);
                Lépj(2 * n);
            }
            Lépj(2 * n * -sor);
            Tollat(le);
            
        }

        void Mozaik_felső_katyvasz(double n, int sor, int oszlop, int x)
        {
            int xedik = x - 1;
            for (int i = 0; i < sor; i++)
            {
                Tollat(le);
                Katyvasz_felsősor(n, oszlop,x, xedik );

                if (xedik == x)
                {
                    xedik = 0;
                }
                else
                {
                    xedik++;
                }
                Tollat(fel);
                Lépj(n * 1.5 );
            }
            Lépj(-n * sor * 1.5);
            Tollat(le);
        }

        void Mozaik_katyvasz(double n, int sor, int oszlop)
        {
            
            Mozaik_alap_katyvasz(n, sor, oszlop);
            Tollat(fel);
            Jobbra(45);
            Lépj(n );
            Jobbra(-45);
            Tollat(le);
            Mozaik_felső_katyvasz(n *0.65, (sor - 1) * 2 , (oszlop-  1) * 2, 2);
            Tollat(fel);
            Jobbra(45);
            Lépj(-n  );
            Jobbra(-45);
            Tollat(le);
        }

        void Rombusz (double n, int ir,Color p) // ir = irány
        {
            Tollat(le);
            Jobbra(ir);
            for (int i = 0; i < 2; i++)
            {
                
                Jobbra(30);
                Lépj(n);
                Jobbra(-60);
                Lépj(n);
                Jobbra(210);
            }
            Tollat(fel);
            Lépj(n * 0.2);
            Tölt(p, false);
            Lépj(n * -0.2);
            Jobbra(-ir);
            Tollat(le);
        }

        void Rombusz_sor (double n, int db, int kezdo)
        {
            if(kezdo == 1)
            {
                for (int i = 0; i < db/2; i++)
                {
                    Rombusz(n, 0, Color.Yellow);

                    Jobbra(30);
                    Lépj(n);
                    Jobbra(60);

                    Rombusz(n, 0, Color.Green);
                    Tollat(fel);

                    Jobbra(30);
                    Lépj(n);
                    Jobbra(-60);
                    Lépj(n);
                    Jobbra(90);
                    Lépj(n);
                    Jobbra(-150);
                }
                Tollat(fel);
                for (int i = 0; i < db / 2; i++)
                {
                    Jobbra(30);
                    Lépj(-n);
                    Jobbra(90);
                    Lépj(-n);
                    Jobbra(-60);
                    Lépj(-n);
                    Jobbra(90);
                    Lépj(-n);
                    Jobbra(-150);
                }
                Tollat(le);
            }
            else
            {
                for(int i = 0;i < db / 2; i++)
                {
                    Jobbra(90);
                    Rombusz(n, 0, Color.Green);
                    Jobbra(-90);

                    Jobbra(120);
                    Lépj(n);
                    Jobbra(-60);
                    Lépj(n);
                    Jobbra(90);
                    Lépj(n);
                    Jobbra(-150);
                    Rombusz(n, 0, Color.Yellow);

                    Jobbra(30);
                    Lépj(n);
                    Jobbra(-30);
                }

                Tollat(fel);
                for (int i = 0; i < db / 2; i++)
                {
                    Jobbra(30);
                    Lépj(-n);
                    Jobbra(90);
                    Lépj(-n);
                    Jobbra(-60);
                    Lépj(-n);
                    Jobbra(90);
                    Lépj(-n);
                    Jobbra(-150);
                }
                Tollat(le);
            }
        }

        void Tombusz_Mozaik(double n, int sor, int oszlop)
        {
            for (int i = 0; i < sor / 2; i++)
            {
                Tollat(le);
                Rombusz_sor(n, oszlop, 1);
                Tollat(fel);
                Jobbra(-45);
                Lépj(n);
                Jobbra(90);
                Lépj(n);
                Jobbra(-45);
                Jobbra(-45);
                Lépj(n * 1.2);
                Jobbra(45);
                Tollat(le);
                Rombusz_sor(n, oszlop, 2);
                Tollat(fel);
                Jobbra(60);
                Lépj(n);
                Jobbra(-60);
            }
            for(int i = 0; i < sor/2; i++)
            {
                Jobbra(60);
                Lépj(-n);
                Jobbra(60);
                Lépj(n);

                Jobbra(30);
                Lépj(n);
                Jobbra(120);
                Lépj(n);
                Jobbra(-120);
                Lépj(n);
                Jobbra(-150);
            }
        }

      
        void Félnégyzet (double n, Color p)
        {
            Tollat(fel);
            Jobbra(45);
            Lépj(n * 0.15);
            Jobbra(-45);
            Tollvastagság(1);
            Tollszín(p);
            Tollat(le);
            Lépj(n);
            Jobbra(135);
            Lépj(n * Math.Sqrt(2));
            Jobbra(135);
            Lépj(n);
            Jobbra(90);
            Tollat(fel);
            Jobbra(45);
            Lépj(n * 0.15);
            Tölt(p, false);
            Lépj(n * -0.15);
            Jobbra(-45);
            Tollszín(Color.Black);
            Jobbra(45);
            Lépj(n * -0.15);
            Jobbra(-45);
            Tollat(le);
        }

        void Négyzet(double n, Color p) // n = méret, p = szín
        {
            Tollszín(p);
            if (p == Color.White)
            {
                Tollszín(Color.Red);
            }
            for (int i = 0; i < 4; i++)
            {
                Tollat(le);
                Lépj(n);
                Jobbra(90);
            }
            for (int i = 0; i < 4; i++)
            {
                Tollat(fel);
                Lépj(n);
                Jobbra(150);
                Lépj(n * 0.2);
                Tölt(p, false);
                Lépj(-n * 0.2);
                Jobbra(-60);
            }
        }

        void Sávos_fehér_négyzet(double n, Color p)
        {
            
            Tollat(fel);
            for (int i = 0; i < 2; i++)
            {
                Félnégyzet(n * 0.3, p);
                Tollszín(Color.White);
                for (int j = 0; j < 2; j++)
                {
                    Lépj(n);
                    Jobbra(90);
                }
            }
            Tollszín(Color.Black);
            Tollat(le);
        }

        void Sávos_fekete_négyzet (double n)
        {
            Négyzet(n, Color.Black);
            Sávos_fehér_négyzet(n, Color.White);
            Tollat(le);
            for (int i = 0; i < 4; i++)
            {
                Lépj(n);
                Jobbra(90);
            }
        }

        void Sávos_sor (double n, int db, int kezdő) // kezdő = 1 = ketete /vagy/ kezdő != 1 = fehét
        {
            int db_ment = db;
            if (kezdő == 1)
            {
                Sávos_fekete_négyzet(n);
                Tollat(fel);
                Jobbra(90);
                Lépj(n);
                Jobbra(-90);
                db--;
            }
            
            if (db % 2 == 0)
            {
                for (int i = 0; i < db; db = db-2)
                {
                    Tollat(le);
                    Sávos_fehér_négyzet(n, Color.Black);
                    Tollat(fel);
                    Jobbra(90);
                    Lépj(n);
                    Jobbra(-90);
                    Tollat(le);
                    Sávos_fekete_négyzet(n);
                    Tollat(fel);
                    Jobbra(90);
                    Lépj(n);
                    Jobbra(-90);
                }
            }
            else
            {
                Tollat(le);
                Sávos_fehér_négyzet(n, Color.Black);
                Tollat(fel);
                Jobbra(90);
                Lépj(n);
                Jobbra(-90);
                db--;
                for (int i = 0; i < db; db = db - 2)
                {
                    Tollat(le);
                    Sávos_fekete_négyzet(n);
                    Tollat(fel);
                    Jobbra(90);
                    Lépj(n);
                    Jobbra(-90);
                    Tollat(le);
                    Sávos_fehér_négyzet(n, Color.Black);
                    Tollat(fel);
                    Jobbra(90);
                    Lépj(n);
                    Jobbra(-90);
                }
            }
            Tollat(fel);
            Jobbra(90);
            Lépj(-db_ment * n);
            Jobbra(-90);
            Tollat(le);
        }

        void Sávos_mozaik (double n, int sor, int oszlop)
        {
            int melyik_jön = 0;
            for (int i = 0; i < sor; i++)
            {
                if (melyik_jön != 0)
                {
                    Tollat(le);
                    Sávos_sor(n, oszlop, melyik_jön);
                    melyik_jön = 0;
                    Tollat(fel);
                    Lépj(n);
                }
                else
                {
                    Tollat(le);
                    Sávos_sor(n, oszlop, melyik_jön);
                    melyik_jön++;
                    Tollat(fel);
                    Lépj(n);
                }
            }
            Tollat(fel);
            Lépj(-sor * n);
            Tollat(le);
        }

        void Háttér(double n, double o, Color p)//n = magasság, o = szélesség
        {
            Tollszín(p);
            for (int i = 0;i < 2; i++)
            {
                Lépj(n);
                Jobbra(90);
                Lépj(o);
                Jobbra(90);
            }
            Tollat(fel);
            Jobbra(45);
            Lépj(n * 0.15);
            Tölt(p, false);
            Lépj(n * -0.15);
            Jobbra(-45);
            Tollat(le);
            Tollszín(Color.Black);
        }

        void Kávébab(double n, int fok)
        {
            n = n * 0.3;
            if (fok != 90)
            {
                Jobbra(35 + fok);
                for (int i = 0; i < 2; i++)
                {

                    Lépj(n);
                    Jobbra(-35);
                    Lépj(n);
                    Jobbra(-35);
                    Lépj(n);
                    Jobbra(-110);
                }
                Tollat(fel);
                Lépj(n * 0.15);
                Tölt(Color.Brown);
                Lépj(n * -0.15);
                Jobbra(-fok - 35);
                Tollat(le);
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    Jobbra(90);
                    Lépj(n * 0.5);
                    Jobbra(-30);
                    Lépj(n);
                    Jobbra(-120);
                    Lépj(n);
                    Jobbra(-30);
                    Lépj(n * 0.5);
                    Jobbra(-90);
                }
                Tollat(fel);
                Lépj(n * 0.15);
                Tölt(Color.Brown);
                Lépj(n * -0.15);
                Tollat(le);
            }
        }

        void Lépjél_nyomtalanul(double n)
        {
            Tollat(fel);
            Jobbra(90);
            Lépj(n);
            Jobbra(-90);
            Tollat(le);
        }
        

        void Kávébab_illúzió (double n, int sor, int oszlop)
        {
            Háttér(n * 2 * sor, n * 2 * oszlop, Color.LimeGreen);
            int irá = 0;
            int mivel_kezd = 0;
            for (int i = 0; i < sor; i++)
            {
                irá = mivel_kezd;
                Kávébab(n, irá);
                Lépjél_nyomtalanul(n);
                if (irá == 0)
                {
                    
                    irá = -30;
                }
                else if (irá == -30)
                {
               
                    irá = -45;
                }
                else if (irá == -45)
                {
            
                    irá = 90;
                }
                else if (irá == 90)
                {
                    Kávébab(n, irá);
                    Lépjél_nyomtalanul(n);
                    irá = 30;
                }
                else if (irá == 30)
                {
                    Kávébab(n, irá);
                    Lépjél_nyomtalanul(n);
                    irá = 45;
                }
                else if (irá == 45)
                {
                    Kávébab(n, irá);
                    Lépjél_nyomtalanul(n);
                    irá = 0;
                }

                mivel_kezd = -30;
                Lépj(n * 1.25);
            }
            Lépj(n * -1.25);
        }

        void FELADAT()
		{
            Tollat(le);
            Kávébab_illúzió(25, 3, 3);
            //Kávébab(100, 90);
            //Háttér(70, 70, Color.LimeGreen);

            //Sávos_mozaik(50, 5, 5);
            //Sávos_sor(35, 5, 0);
            //Sávos_fekete_négyzet(50);
            //Sávos_fehér_négyzet(50, Color.Black);
            //Félnégyzet(100, Color.Black);
            //Hermann_rács(5, 5, 50);//oszlop, sor, méret

            /*Tombusz_Mozaik(15, 10, 10);
            Rombusz_sor(30, 5, 2);
            Mozaik_katyvasz(20, 2, 3);
            Mozaik_felső_katyvasz(30, 5, 5, 2);
            Mozaik_alap_katyvasz(30, 5, 5);
            Katyvasz_felsősor(30, 8,2,2);
            Katyvasz_alapsor(50, 5);
            Négyzet(50, Color.DarkRed);
            Mozaik_korong_rács(20,5,5);
            Mozaik_korong(30);
            Téglalap_kitöltve(50, 25, Color.Yellow);
            Hatszög(30, Color.Green);
            Háromszög(15, Color.Red);
            Jobbra(60);
            Cipzár_fal(25, 3, 4);
            Cipzár_dupla(50, 3);
            Cipzar_sor2(50, 5);
            Cipzar_db(50, Color.Aqua);
            Három_db_szög(50, 1);
            Mozaik_asztal(40, 2, 3);
            Mozaik_asztal_sor(25, 4);
            Mozaik_asztal_alap();
            Mozaik_szem_háló(25, 5, 3);
            Csempézés(50,5,5,Color.White, Color.Blue);
            Hermann_rács(110,55,10);
            Négyzet(50, Color.White);
            Nyílminta(50,5,7);
            Nyílsor(50, 4);
            Tollvastagság(2);
            Mozaik(50, 5, 7);
            Mozaik_db(50);
            Mozaik_sor(50, 5);
            Mozaik_szem_sor(25, 5);
           /**/
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
                      bool kontrolszakasz = false)*/