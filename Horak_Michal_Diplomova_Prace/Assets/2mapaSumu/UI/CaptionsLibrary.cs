using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CaptionsLibrary
{
    public static Dictionary<string, string> slovnik = new Dictionary<string, string>
    {
                //MENU//
        {"btnStart","Zahajit simulaci"},
        {"btnMenuTitle","Simulátor - Vlk, ovce a travina " +
            "\n Diplomový projekt"+
            "\n Autor: Bc. Michal Horák"},
        {"btnMenuExterminate","Ukonèit simulaci"},
        {"btnStartSimulation","Spustit simulaci"},
        {"btnReturn","Vrátit se zpìt"},
        {"btnContinue","Pokraèovat"},
        {"btnReturnToMenu","Vrátit se do menu"},
                //Ovládání//
        {"Controls","Kamera se pohybuje pomocí kláves [W],[S],[A],[D] - Pohyb dopøedu, dozadu, vlevo a vpravo." +
            "\n\nKamera se otáèí pomocí kláves [Q] a [E] - Rotace vlevo a vpravo." +
            "\n\nKameru lze vrátit do výchozího stavu pomocí klávesy [R]. Koleèko myši urèuje výšku kamery."},
                //MENU-Entity//
        {"populace","Poèáteèní populace"},
        {"populaceInfo","Kolik jedincù se bude generovat na zaèátku simulace"},
        {"populaceReprodukce","Možnost reprodukce"},
        {"populaceReprodukceInfo","Zda tento druh se mùže rozmnožovat"},
        {"potrava","Typ potravy"},
        {"potravaInfo","1-masožravec, 2-rostlinožravec, 3-všežravec"},
        {"matureAge","Vìk dospívání"},
        {"matureAgeInfo","Vìk, kdy jedinec dospívá a mùže zakládat rodiny / u roslin možnost šíøit semínka kolem sebe"},
        {"dieAge","Vìk umírání"},
        {"dieAgeInfo","Vìk, kdy jedinci zaèíná pasivnì ubývat zdraví a nakonec po èase umírá"},
        {"maxHp","Maximální zdraví"},
        {"maxHpInfo","Maximální zdraví jedince. Tato hodnota mùže ovlivnit rychlost umírání"},
        {"regenHp","Regenerace zdraví za èas"},
        {"regenHpInfo","Množství, které si jedinec doplní za èas. Tato hodnota mùže ovlivnit rychlost umírání"},
        {"maxEnergy","Maximální energie"},
        {"maxEnergyInfo","Množství energie rozhoduje o možnosti vzplodit potomka/šíøit semínka. Pro zplození potomka je potøeba maximum energie a vyšší hodnota zvyšuje dobu, než by mohl zplodit jedince"},
        {"regenEnergy","Regenerace energie za èas"},
        {"regenEnergyInfo","Množství, které si jedinec doplní za èas"},
        {"foodValue","Hodnota potravy pro predatora"},
        {"foodValueInfo", "Hodnota potravy pro predátora, který sní jedince tohoto druhu"},
        {"reproduceCooldown","Èas mez porody"},
        {"reproduceCooldownInfo","Èas, který urèuje, jak dlouho po porodu/šíøení semínek se bude smìt samice zvíøete stát znova gravitní a u rostlin, kdy bude vypuštìno další semínko okolo"},
        {"timeHlad","Hlad za èas"},
        {"timeHladInfo","Množství, které jedinec získá za èas. V simulaci se poèítá od 0, kdy není žádná potøeba k maximální hranici, kdy je urgentní potøeba"},

        {"timeZizen","Žízeò za èas"},
        {"timeZizenInfo","Množství, které jedinec získá za èas. V simulaci se poèítá od 0, kdy není žádná potøebam k maximální hranici, kdy je urgentní potøeba"},
        {"timeSpanek","Potøeba spánku za èas"},
        {"timeSpanekInfo","Množství, které jedinec získá za èas. V simulaci se poèítá od 0, kdy není žádná potøebam k maximální hranici,  kdy je urgentní potøeba"},
        {"maxHlad","Max Hlad"},
        {"maxHladInfo","Maximální hranice hladu > ovlivòuje dobu, kdy jedinec bude uspokojovat tuto potøebu"},
        {"maxZizen","Max Žízeò"},
        {"maxZizenInfo","Maximální hranice hladu > ovlivòuje dobu, kdy jedinec bude uspokojovat tuto potøebu"},
        {"maxSpanek","Max Potøeba spánku"},
        {"maxSpanekInfo","Maximální hranice hladu > ovlivòuje dobu, kdy jedinec bude uspokojovat tuto potøebu"},
        {"pregnancyTime","Èas do porodu"},
        {"pregnancyTimeInfo","Doba, který urèuje, po jaké dobì, se narodí nový jedinec od zplození"},
        {"strenght","Síla útoku"},
        {"strenghtInfo","Urèuje sílu útoku jedince, kdy útoèí na jiná zvíøata (v obranì, èi pro potravu"},
       

          //MENU-Svìt//
        {"Multiplier","Násobiè výšky"},
        {"MultiplierInfo","urèuje výškový rozdíl mezi body"},
        {"SWidth","Poèet blokù do šíøky"},
        {"SWidthInfo","Poèet bodù v møížce smìrem doprava"},
        {"SDepth","Poèet blokù do hloubky"},
        {"SDepthInfo","Poèet bodù v møížce smìrem nahoru"},
        {"Seed","Semínko mapy - doporuèeno 270, anebo 435"},
        {"SeedInfo","Semínko mapy, které rozhoduje podobu terénu. Nìkteré seedy nefungují a proto se doporuèuje seed 435,270, protože byly vyzkoušny"},



         //Simulace-Svìt//        
        {"ShowStatisticWindow","Zobrazit statistiku"},
        {"BackToMenu","Zpátky do menu"},
        {"PauseSimulation","Zapauzovat simulaci"},
        {"UnpauseSimulation","Odpauzovat Simulaci"},


          //Simulace-StatisticMenu//        
        {"ShowStatisticEvent","Zobrazit události"},
        {"ShowAnimals","Zobrazit zvíøata"},
        {"ShowKind","Zobrazit statistiky druhù"},
        {"ShowPlants","Zobrazit rostliny"},
        {"ResetStatWindow","Aktualizovat" },
        {"CloseWindow","Zavøít okno"},


        //Výpisy
        {"Wolf","Vlk"},
        {"Sheep","Ovce"},
        {"Alleater","Všežravec"},
        {"Meateater","Býložravec"},
        {"Planteater","Rostli"},

        {"Yes","Ano"},
        {"No","Ne"},
        {"Age","Vìk"},
        {"Adult","Dospìlý"},
        {"AdultInAge","Dospìlost ve vìku"},
        {"Male","Samec"},
        {"Female","Samice"},
        {"HP","Životy"},

        {"Animal","Zvíøe"},
        {"Live","Žije"},
        {"Dead","Nežije"},
        {"Hungery","Hlad"},
        {"Thirsty","Žízeò"},
        {"Sleep","Spánek"},
        {"PregnantYes","Tìhotenství: Ano - èas k porodu"},
        {"PregnantNo","Tìhotenství: Ne"},
        {"FemalePartner","Partnerka"},
        {"MalePartner","Partner"},
        {"Mother","Matka"},
        {"Father","Otec"},
        {"Children","Potomci"},
        {"State","Stav"},
        {"None","Žádné"},
    };

    public static string GetCaption(string KeyCaption)
    {
        if (string.IsNullOrEmpty(KeyCaption))
        {
            return "? Klíè nebyl nastaven ?";
        }
        if (slovnik.TryGetValue(KeyCaption, out string caption))
        {
            return caption;
        }
        else return "? Nenalezen text - klíè: '" + KeyCaption + "' ?";
    }
    public static string GetCaption(Stav stav)
    {
        string text = "?";
        switch (stav)
        {
            case Stav.Going:
                text = "Pohybyje se";
                break;
            case Stav.Sleeping:
                text = "Spí";
                break;
            case Stav.Eating:
                text = "Krmí se";
                break;
            case Stav.Drinking:
                text = "Pije";
                break;
            case Stav.Attacking:
                text = "Útoèí";
                break;
            case Stav.Mating:
                text = "Rozmnožuje se";
                break;
            case Stav.Nothing:
                text = "Nic nedìlá";
                break;
            case Stav.Relax:
                text = "Odpoèívá";
                break;
            case Stav.GoingForWater:
                text = "Jde se napít";
                break;
            case Stav.GoingForFood:
                text = "Jde se krmit";
                break;
            case Stav.GoingForPlace:
                text = "Pohybuje se";
                break;
            case Stav.GoingForFight:
                text = "Útoèí";
                break;
            case Stav.GoingforDefend:
                text = "Brání se";
                break;
            case Stav.GoingforDefendPartner:
                text = "Brání partnera";
                break;
            case Stav.FollowParty:
                text = "Následuje skupinu";
                break;
            case Stav.GoRandom:
                text = "Náhodný pohyb";
                break;
        }
        return text;
    }
}
