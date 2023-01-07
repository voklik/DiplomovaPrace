using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CaptionsLibrary
{
    public static Dictionary<string, string> slovnik = new Dictionary<string, string>
    {
                //MENU//
        {"btnStart","Zahajit simulaci"},
        {"btnMenuTitle","Simulátor - Vlk, ovce a travina"},
        {"btnMenuExterminate","Ukonèit simulaci"},

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
        {"timeZizenIfo","Množství, které jedinec získá za èas. V simulaci se poèítá od 0, kdy není žádná potøebam k maximální hranici, kdy je urgentní potøeba"},
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
}
