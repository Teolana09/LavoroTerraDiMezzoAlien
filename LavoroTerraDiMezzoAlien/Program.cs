namespace LavoroTerraDiMezzoAlien
{    
        internal class Program
        {
        static string DialogoComando(int personaggioScelto)
        {
            Console.WriteLine("Sei nella sala di comando.\n");
            Console.WriteLine("La situazione è instabile. Dobbiamo decidere ora.\n");

            string fine = "Nessuna decisione presa"; 
            int opzione = 1;

            if (personaggioScelto != 4)
            {
                Console.WriteLine(opzione + ") Chiedere un parere tattico a Drax Morrow");
                opzione++;
            }

            if (personaggioScelto != 2)
            {
                Console.WriteLine(opzione + ") Chiedere un’analisi scientifica a Elias Vern");
                opzione++;
            }

            if (personaggioScelto != 3)
            {
                Console.WriteLine(opzione + ") Verificare i sistemi con Karla Rens");
                opzione++;
            }

            Console.Write("\nScelta: ");
            int scelta = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            if (scelta == 1)
            {
                if (personaggioScelto != 4)
                {
                    Console.WriteLine("Drax Morrow: \"Entriamo armati e mettiamo tutto in sicurezza.\"");
                    fine = "Missione offensiva avviata con Drax";
                }
                else
                {
                    Console.WriteLine("Elias Vern: \"Ci sono segnali biologici anomali.\"");
                    fine = "Missione scientifica avviata con Vern";
                }
            }
            else if (scelta == 2)
            {
                if (personaggioScelto == 1)
                {
                    Console.WriteLine("Elias Vern: \"Serve cautela e analisi approfondita.\"");
                    fine = "Missione scientifica avviata con Vern";
                }
                else
                {
                    Console.WriteLine("Karla Rens: \"I sistemi possono reggere ancora.\"");
                    fine = "Missione tecnica avviata con Karla";
                }
            }
            else if (scelta == 3 && personaggioScelto == 1)
            {
                Console.WriteLine("Karla Rens: \"Dammi qualche minuto e riparo tutto.\"");
                fine = "Missione tecnica avviata con Karla";
            }

            return fine;
        }



        static (int nuovaVita, int medikitRimasti) UsaOggettoCura(int vitaGiocatore, int medikit)
        {
            Random rnd = new Random();
            // gestione dell'uso del medikit per curare il giocatore
            if (medikit <= 0)
            {
                Console.WriteLine("Non hai medikit!");
                return (vitaGiocatore, medikit);
            }

            int cura = rnd.Next(5, 21); 

            vitaGiocatore += cura;
            if (vitaGiocatore > 100)
                vitaGiocatore = 100;

            medikit--; 

            Console.WriteLine("Usi un medikit e recuperi " + cura + " punti vita.");
            Console.WriteLine("Vita attuale: " + vitaGiocatore);
            Console.WriteLine("Medikit rimasti: " + medikit);

            return (vitaGiocatore, medikit);
        }

        static int AttaccoGiocatore(int vitaAlieno)
            {
                //gestione dell'attacco del giocatore

                Random rnd = new Random();
                int danno = rnd.Next(5, 16); 

                vitaAlieno -= danno;

                if (vitaAlieno < 0)
                {
                    vitaAlieno = 0;
                }


                Console.WriteLine("Attacchi l'alieno e infliggi" + danno + "danni.");
                Console.WriteLine("Vita alieno:" + vitaAlieno);

                return vitaAlieno;
            }

            static int boost(int avanza, int passi, bool scassaP)
            {
                //gestione del boost dei passi
                Random random = new Random();
                int bonus = random.Next(1, 7);
                bool bost = false;
                if (scassaP == true)
                {
                    Console.WriteLine("hai ricevuto un boost di 3 passi extra");
                    avanza = passi + 3;
                    bost = true;
                }
                else if (bonus > 4)
                {
                    Console.WriteLine("hai ricevuto un boost di 2 passi extra");
                    avanza = passi + 2;
                    bost = true;
                }
                else
                {
                    Console.WriteLine("non hai ricevuto nessun boost");
                    avanza = passi;
                    bost = false;
                }
                return avanza;
            }
            static string Imprevisti(string imprevisti)
            {
                //gestione degli imprevisti durante il gioco
                Random random = new Random();
                int evento = random.Next(1, 4);
                if (evento == 1)
                {
                    Console.WriteLine("un membro dell'equipaggio è stato ferito dallo xenomorfo");
                    imprevisti = "membro ferito";

                }
                else if (evento == 2)
                {
                    Console.WriteLine("lo xenomorfo ha bloccato alcune porte");
                    imprevisti = "porte bloccate";
                }
                else
                {
                    Console.WriteLine("lo xenomorfo si è avvicinato molto, fai attenzione");
                    imprevisti = "xenomorfo vicino";
                }
                return imprevisti;
            }
        static string turnoDIG(string turnoDIG, bool cacciatore, bool curatore, bool scassaP, bool armaletale, bool porteAPP, ref int proiettoli, ref int medikit)
        {
            //gestione del turno di gioco
            //scelte del giocatore
            bool trovatoOggetto = false, sceltaConSuccesso = false;
            Random random = new Random();
            int OggaC = random.Next(1, 50);
            Console.WriteLine("è il tuo turno di giocare, scegli cosa fare:");
            Console.WriteLine("---------------------------");


            Console.WriteLine("1) preparare una trappola");

            Console.WriteLine("2) provare a sbloccare le porte");

            Console.WriteLine("3) controllare per oggetti utili");            

            Console.WriteLine("-----------------------------------");
            int sceltaTurno = Convert.ToInt32(Console.ReadLine());
            while (sceltaTurno < 1 || sceltaTurno > 4)
            {
                Console.WriteLine("scelta non valida, riprova");
                sceltaTurno = Convert.ToInt32(Console.ReadLine());
            }
            while (sceltaConSuccesso == false)
            {
                if (sceltaTurno == 1)
                {
                    if (cacciatore == true)
                    {
                        Console.WriteLine("hai preparato una trappola per l'alieno");
                        sceltaConSuccesso = true;
                        Random random1 = new Random();
                        int cattura = random1.Next(1, 10);
                        if (cattura > 5)
                        {
                            Console.WriteLine("hai catturato lo xenomorfo con successo!");
                            Console.WriteLine("complimenti sei riuscito a diminuire la sua velocità");
                            sceltaConSuccesso = true;
                            Random random2 = new Random();
                            int rallenta = random2.Next(1, 5);
                            if (rallenta > 2)
                            {
                                Console.WriteLine("lo xenomorfo è stato rallentato di 2 passi");
                            }
                            else
                            {
                                Console.WriteLine("lo xenomorfo è stato rallentato di 1 passo");
                            }
                        }
                        else
                        {
                            Console.WriteLine("lo xenomorfo è riuscito a sfuggire alla trappola");

                        }
                    }
                    else
                    {
                        Console.WriteLine("non sei in grado di preparare una trappola");
                        Console.WriteLine("scelta non valida, riprova");
                        sceltaTurno = Convert.ToInt32(Console.ReadLine());
                    }

                }

                else if (sceltaTurno == 2)
                {
                    Random random1 = new Random();
                    int segnale = random1.Next(1, 10);
                    if (segnale > 7)
                    {
                        Console.WriteLine("hai sbloccato tutte le porte con successo");
                        sceltaConSuccesso = true;
                    }
                    else
                    {
                        Console.WriteLine("non sei riuscito a sbloccare le porte");
                        Console.WriteLine("scelta non valida, riprova");
                        sceltaTurno = Convert.ToInt32(Console.ReadLine());
                    }

                }
                else if (sceltaTurno == 3)
                {
                    Console.WriteLine("hai scelto di cercare oggetti utili");
                    sceltaConSuccesso = true;
                    if (OggaC > 25)
                    {
                        Equipaggiamento(0, ref medikit, ref proiettoli);
                        Console.WriteLine("trovare un oggetto utile");

                        Random oggetto = new Random();
                        int oggettoTrovato = oggetto.Next(1, 4);
                        if (oggettoTrovato == 1)
                        {
                            Console.WriteLine("hai trovato un medikit");
                            curatore = true;
                        }
                        else if (oggettoTrovato == 2)
                        {
                            Console.WriteLine("hai trovato dei proiettili");
                            proiettoli += 10;
                            armaletale = true;
                        }
                        else if (oggettoTrovato == 3)
                        {
                            Console.WriteLine("hai trovato una chiave magnetica");
                            scassaP = true;
                        }
                    }

                    else
                    {
                        Console.WriteLine("non trovare nulla di utile");
                    }
                }

            } 



                return turnoDIG;
        }


            static void AttaccoAlieno(ref int vita, bool armaletale)
            {
                //gestione dell'attacco alieno
                Random rnd = new Random();
                int danno = rnd.Next(1, 11); 
                Random difesa = new Random();
                int parata = difesa.Next(1, 7);
                vita -= danno;

                if (vita < 0)
                {
                    vita = 0;
                }
                if (armaletale == true )
                {
                vita += parata;
                }

            Console.WriteLine("       __.,,------.._\r\n      ,'\"   _      _   \"`.\r\n     /.__, ._  -=- _\"`    Y\r\n    (.____.-.`      \"\"`   j\r\n     VvvvvvV`.Y,.    _.,-'       ,     ,     ,\r\n        Y    ||,   '\"\\         ,/    ,/    ./\r\n        |   ,'  ,     `-..,'_,'/___,'/   ,'/   ,\r\n   ..  ,;,,',-'\"\\,'  ,  .     '     ' \"\"' '--,/    .. ..\r\n ,'. `.`---'     `, /  , Y -=-    ,'   ,   ,. .`-..||_|| ..\r\nff\\\\`. `._        /f ,'j j , ,' ,   , f ,  \\=\\ Y   || ||`||_..\r\nl` \\` `.`.\"`-..,-' j  /./ /, , / , / /l \\   \\=\\l   || `' || ||...\r\n `  `   `-._ `-.,-/ ,' /`\"/-/-/-/-\"'''\"`.`.  `'.\\--`'--..`'_`' || ,\r\n            \"`-_,',  ,'  f    ,   /      `._    ``._     ,  `-.`'//         ,\r\n          ,-\"'' _.,-'    l_,-'_,,'          \"`-._ . \"`. /|     `.'\\ ,       |\r\n        ,',.,-'\"          \\=) ,`-.         ,    `-'._`.V |       \\ // .. . /j\r\n        |f\\\\               `._ )-.\"`.     /|         `.| |        `.`-||-\\\\/\r\n        l` \\`                 \"`._   \"`--' j          j' j          `-`---'\r\n         `  `                     \"`,-  ,'/       ,-'\"  /\r\n                                 ,'\",__,-'       /,, ,-'\r\n                                 Vvv'            VVv'");

                Console.WriteLine("L'alieno ti ha attaccato! Perdi" + danno + " punti vita.");
                Console.WriteLine("Vita attuale:" + vita);
            }




        static string Equipaggiamento(int scelta, ref int medikit, ref int proiettili)
        {
            string testo = "";

            // MOSTRA EQUIPAGGIAMENTO
            if (scelta == 0)
            {
                testo = "Equipaggiamento:\n";
                testo += "- Medikit: " + medikit + "\n";
                testo += "- Proiettili: " + proiettili + "\n";
            }

            // USA MEDIKIT
            else if (scelta == 1)
            {
                if (medikit > 0)
                {
                    medikit--;
                    testo = "Hai usato un medikit.\n";
                    testo += "Medikit rimasti: " + medikit;
                }
                else
                {
                    testo = "Non hai medikit disponibili!";
                }
            }

            // ATTACCO GIOCATORE
            else if (scelta == 2)
            {
                if (proiettili >= 2)
                {
                    proiettili -= 2;
                    testo = "Attacchi l'alieno!\n";
                    testo += "Proiettili rimasti: " + proiettili;
                }
                else
                {
                    testo = "Non hai abbastanza proiettili!";
                }
            }

            return testo;

        }

            static int lancioDado()
            {
                Random dado = new Random();
                int risultato = dado.Next(1, 7);
                return risultato;
            }
            static string SCpercorso(ref bool scappato)
            {
                // elenco delle stanze
                string[] stanze =
                {
                 "Ponte di Comando Holo-Visivo", "Camera di Navigazione Quantistica", "Sala Motori a Fusione Oscura",
                "Laboratorio Xenobiologico", "Modulo di Criostasi Profonda", "Orto Idroponico Bioluminescente", 
                "Sala Olistica di Rilassamento Neurale", "Armeria a Campo Magnetico", "Centro di Comando Droni", 
                "Archivio di Memoria Cristallina", "Sala di Teletrasporto Molecolare", "Blocco Medico Rigenerativo", 
                "Corridoio di Gravità Variabile", "Simulatore Ambientale Totale", "Cupola Stellare Panoramica", 
                "Sala dei Reattori Antimateria", "Centro di Comunicazione Tachionica", "Quartieri dell’Equipaggio Modulari", 
                "Santuario del Silenzio Cosmico", "Hangar Multifase"
                };

            
                int passi = lancioDado();

            
                int posizione = passi;

            
            if (posizione >= stanze.Length)
            {
                posizione = stanze.Length - 1;
            }

            
                string stanzaAttuale = stanze[posizione];

                Console.WriteLine("Avanzi di " + passi + " passi");

            
            if (stanzaAttuale == "Hangar Multifase")
            {
                Console.WriteLine("Complimenti! Sei arrivato all'hangar e sei scappato!");
                scappato = true;
            }

            
                return stanzaAttuale;
        }
            static string OttieniDescrizioneStanza(string nomeStanza)
            {
                
                string descrizione = "";
                if (nomeStanza == "Ponte di Comando Holo-Visivo")
                {
                    descrizione = "Un'area operativa con schermi olografici che proiettano in 3D i dati tattici e la vista esterna.";
                }
                else if (nomeStanza == "Camera di Navigazione Quantistica")
                {
                    descrizione = "Contiene il computer di bordo che calcola istantaneamente le rotte attraverso lo spazio-tempo.";
                }
                else if (nomeStanza == "Sala Motori a Fusione Oscura")
                {
                    descrizione = "Il cuore pulsante della nave, dove una reazione controllata genera energia propulsiva illimitata.";
                }
                else if (nomeStanza == "Laboratorio Xenobiologico")
                {
                    descrizione = "Attrezzato per l'analisi e lo studio di forme di vita e campioni organici alieni.";
                }
                else if (nomeStanza == "Modulo di Criostasi Profonda")
                {
                    descrizione = "Contiene capsule per il sonno criogenico a lungo termine durante i viaggi interstellari.";
                }
                else if (nomeStanza == "Orto Idroponico Bioluminescente")
                {
                    descrizione = "Un sistema ecologico autonomo per la coltivazione di cibo fresco sotto luci organiche.";
                }
                else if (nomeStanza == "Sala Olistica di Rilassamento Neurale")
                {
                    descrizione = "Un ambiente di terapia sensoriale che riequilibra le onde cerebrali e lo stress dell'equipaggio.";
                }
                else if (nomeStanza == "Armeria a Campo Magnetico")
                {
                    descrizione = "Custodisce armi e attrezzature in sicurezza grazie a potenti campi di forza.";
                }
                else if (nomeStanza == "Centro di Comando Droni")
                {
                    descrizione = "Da qui si gestisce e si lancia una flotta di droni autonomi per ricognizione e manutenzione.";
                }
                else if (nomeStanza == "Archivio di Memoria Cristallina")
                {
                    descrizione = "Un caveau sicuro per il backup dei dati cruciali della missione su supporti cristallini indistruttibili.";
                }
                else if (nomeStanza == "Sala di Teletrasporto Molecolare")
                {
                    descrizione = "Permette il trasferimento istantaneo di persone e oggetti su brevi o lunghe distanze.";
                }
                else if (nomeStanza == "Blocco Medico Rigenerativo")
                {
                    descrizione = "Un'infermeria dotata di macchinari avanzati per la guarigione rapida e la rigenerazione tissutale.";
                }
                else if (nomeStanza == "Corridoio di Gravità Variabile")
                {
                    descrizione = "Un passaggio che può simulare diverse condizioni gravitazionali per l'allenamento o la necessità della missione.";
                }
                else if (nomeStanza == "Simulatore Ambientale Totale")
                {
                    descrizione = "Una stanza versatile per l'addestramento che replica qualsiasi clima e scenario planetario.";
                }
                else if (nomeStanza == "Cupola Stellare Panoramica")
                {
                    descrizione = "Offre una vista a 360 gradi dello spazio, ideale per l'osservazione e il relax.";
                }
                else if (nomeStanza == "Sala dei Reattori Antimateria")
                {
                    descrizione = "Dove si produce l'energia primaria della nave attraverso reazioni di annichilazione controllata.";
                }
                else if (nomeStanza == "Centro di Comunicazione Tachionica")
                {
                    descrizione = "Utilizzato per inviare e ricevere messaggi istantanei su distanze cosmiche.";
                }
                else if (nomeStanza == "Quartieri dell’Equipaggio Modulari")
                {
                    descrizione = "Alloggi flessibili che possono essere riconfigurati in base alle esigenze e al numero dell'equipaggio.";
                }
                else if (nomeStanza == "Santuario del Silenzio Cosmico")
                {
                    descrizione = "Una stanza di meditazione e isolamento acustico per la pace interiore.";
                }
                else if (nomeStanza == "Hangar Multifase")
                {
                    descrizione = "Un vasto spazio per l'attracco e la manutenzione di navette, caccia e veicoli ausiliari.";
                }
                else
                {
                    descrizione = "Descrizione non disponibile per questa stanza.";
                }
                return descrizione;
            }



            static void Main(string[] args)
            {
                string personaggio = "", stanza = "";

                int sceltapersonaggio = 0, equipaggio = 3;
                bool scassaP = false, armaletale = false, curatore = false, cacciatore = false, porteAPP = false;
                bool morto = false, scappato = false, alienomorto = false;
                //introduzione al gioco

                Console.WriteLine("La USCSS Covenant intercetta un misterioso segnale proveniente da un pianeta nascosto in una nebulosa. Oram, insieme a Daniels, Tennessee e Walter, scende a indagare.In una struttura aliena trovano delle uova. Oram ne osserva una da vicino… e un Facehugger gli balza sul volto.L’equipaggio corre alla nave e decolla in fretta, ma nella fuga la Covenant impatta contro una cintura di asteroidi. Le luci tremano, gli allarmi urlano.Nella sala medica, il corpo di Oram comincia a contorcersi. Qualcosa sta per nascere.");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Benvenuto in Alien comenant la minaccia ");
                Console.WriteLine("in questo gioco dovrai raggiundere le varie stanze per trovare oggetti utili");
                Console.WriteLine("Se farai troppo rumore lo xenomorfo ti troverà e porra fine alle tue sofferenze");
                Console.WriteLine("Piano piano nel gioco dovrai sceglere dove andare ma solo se avrai la chiave, fai il percorso più corto possibile a mantieni al meglio l'equipaggio vivo");
                Console.WriteLine("non ti resta che scegliere il personaggio e giocare!");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("1. Tenente Mira Solenz\r\nRuolo: Pilota\r\n\r\n\r\nAbilità: Velocità, accesso a porte bloccate nei settori di comando");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("2. Dottor Elias Vern\r\nRuolo: Medico di bordo\r\n\r\n\r\nAbilità: Cura ferite, analisi biologiche rapide");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("3. Ingegnere Karla Rens\r\nRuolo: Meccanica e manutenzione\r\n\r\n\r\nAbilità: Riparare sistemi, creare trappole contro l’alieno");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("4. Sergente Drax Morrow\r\nRuolo: Sicurezza\r\n\r\n\r\nAbilità: Forza fisica, uso di armi non letali");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("5. Analista Taryn Wells\r\nRuolo: Esperta in comunicazioni e sistemi informatici\r\n\r\n\r\nAbilità: Hackeraggio porte, attivazione manuale navicelle");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Ombre dense avvolgono pareti di metallo organico che sembrano respirare, illuminate solo dal fioco pulsare di venature bioluminescenti.\r Un ronzio sordo vibra nell'aria gelida, suggerendo una tecnologia incomprensibile in agguato nel buio.");
                sceltapersonaggio = Convert.ToInt32(Console.ReadLine());
                if (sceltapersonaggio == 1)
                {
                    Console.WriteLine("complimenti ha scelto : Tenente Mira Solenz");
                    scassaP = true;//apre le porte
                }
                else if (sceltapersonaggio == 2)
                {
                    Console.WriteLine("complimenti ha scelto : Dottor Elias Vern");
                    curatore = true;//cura i compagni feriti
                }
                else if (sceltapersonaggio == 3)
                {
                    Console.WriteLine("complimenti ha scelto : Ingegnere Karla Rens");
                    cacciatore = true;//può catturare l'alieno
                }
                else if (sceltapersonaggio == 4)
                {
                    Console.WriteLine("complimenti ha scelto : Sergente Drax Morrow");
                    armaletale = true;//può difendere dall'alieno
                }
                else if (sceltapersonaggio == 5)
                {
                    Console.WriteLine("complimenti ha scelto : Analista Taryn Wells");
                    scassaP = true;//apre le porte
                }
                int medikit = 3;
                int proiettili = 10;


                while (morto == false && scappato == false && alienomorto == false)
                {
                    string esitoMissione = DialogoComando(sceltapersonaggio);
                    //mostra l'esito della missione
                    Console.WriteLine("\nESITO FINALE:");
                    Console.WriteLine(esitoMissione);

                    Console.WriteLine("Ora inizia la tua avventura!");

                    Console.WriteLine("ecco il tuo equipaggiamento ");
                    string equipaggiamentoattuale;
                    equipaggiamentoattuale = Equipaggiamento(0,ref medikit,ref proiettili); 
                    Console.WriteLine(equipaggiamentoattuale);

                   
                    string stanzaAttuale = SCpercorso(ref scappato);
                    Console.WriteLine("Ti trovi in: " + stanzaAttuale);

                    
                    Console.WriteLine("descrizione della stanza:");
                    string descrizioneStanza = OttieniDescrizioneStanza(stanzaAttuale);
                    Console.WriteLine(descrizioneStanza);
                    int lanciodado;
                    lanciodado = lancioDado();
                    Console.WriteLine("hai fatto un lancio di dado e hai ottenuto: " + lanciodado);
                    int avanza = boost(0, lanciodado, scassaP);

                    Console.WriteLine("Avanzi di " + avanza + " passi totali");
                    string imprevisto = Imprevisti("");

                Console.WriteLine("--------------------------------");
                    int vitaGiocatore = 100;

                    Console.WriteLine("Vita iniziale:" + vitaGiocatore);

                    AttaccoAlieno(ref vitaGiocatore);

                    Console.WriteLine("Vita dopo l'attacco: " + vitaGiocatore);


                    Console.WriteLine("--------------------------------");

                    Console.WriteLine("ora dovrai scegliere cosa fare");
                    string scelta;

                    scelta = turnoDIG("", cacciatore, curatore, scassaP, armaletale, porteAPP, ref medikit, ref proiettili);
                    Console.WriteLine("hai scelto di: " + scelta);

                    int vitaAlieno = 40;

                    //richiama il combattimento
                    Console.WriteLine("\nCOMBATTIMENTO CONTRO L'ALIENO:");
                    vitaAlieno = AttaccoGiocatore(vitaAlieno);
                    int vita = vitaGiocatore;                   

                    (int nuovaVita, int medikitRimasti) = UsaOggettoCura(vita, medikit);

                    AttaccoAlieno(ref vita);
                    Console.WriteLine("Vita giocatore dopo l'attacco alieno: " + vita);

                    vita = nuovaVita;
                    medikit = medikitRimasti;
                    Console.WriteLine("Vita giocatore dopo l'uso del medikit: " + vita);
                    if (vitaAlieno == 0)
                    {
                        Console.WriteLine("Hai sconfitto l'alieno! Complimenti, sei un eroe!");
                        alienomorto = true;
                    }
                    else if (vita == 0)
                    {
                        Console.WriteLine("Sei stato sconfitto dall'alieno. La tua missione finisce qui.");
                        morto = true;


                    }

                }
                if (scappato == true)
                {
                    Console.WriteLine("Complimenti! Sei riuscito a fuggire dallo xenomorfo e a tornare alla USCSS Covenant. La tua astuzia e il tuo coraggio hanno salvato l'equipaggio e forse l'umanità stessa.");
                }
                else if (morto == true)
                {
                    Console.WriteLine("Purtroppo sei stato sopraffatto dallo xenomorfo. La tua missione finisce qui, ma il tuo sacrificio non sarà dimenticato.");
                    Console.WriteLine("Mentre la Terra appariva all'orizzonte, vide l'infezione aliena pulsare nelle sue vene e capì di essere diventato l'arma che avrebbe distrutto l'umanità. Con le lacrime agli occhi, deviò la rotta verso il Sole, scegliendo di bruciare nel silenzio eterno pur di proteggere la vita di chi lo aspettava a casa.");
                }
                else if (alienomorto == true)
                {
                    Console.WriteLine("Hai sconfitto lo xenomorfo e salvato l'equipaggio della USCSS Covenant! La tua astuzia e il tuo coraggio hanno fatto la differenza in questa missione pericolosa.");
                }
                Console.WriteLine("Grazie per aver giocato ad Alien comenant la minaccia!");
            }
        }
    
}
