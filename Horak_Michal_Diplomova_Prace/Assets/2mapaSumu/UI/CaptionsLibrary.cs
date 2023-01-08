using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CaptionsLibrary
{
    public static Dictionary<string, string> slovnik = new Dictionary<string, string>
    {
                //MENU//
        {"btnStart","Zahajit simulaci"},
        {"btnMenuTitle","Simul�tor - Vlk, ovce a travina"},
        {"btnMenuExterminate","Ukon�it simulaci"},
        {"btnStartSimulation","Spustit simulaci"},
        {"btnReturn","Vr�tit se zp�t"},
        {"btnContinue","Pokra�ovat"},
        {"btnReturnToMenu","Vr�tit se do menu"},
                //MENU-Entity//
        {"populace","Po��te�n� populace"},
        {"populaceInfo","Kolik jedinc� se bude generovat na za��tku simulace"},
        {"populaceReprodukce","Mo�nost reprodukce"},
        {"populaceReprodukceInfo","Zda tento druh se m��e rozmno�ovat"},
        {"potrava","Typ potravy"},
        {"potravaInfo","1-maso�ravec, 2-rostlino�ravec, 3-v�e�ravec"},
        {"matureAge","V�k dosp�v�n�"},
        {"matureAgeInfo","V�k, kdy jedinec dosp�v� a m��e zakl�dat rodiny / u roslin mo�nost ���it sem�nka kolem sebe"},
        {"dieAge","V�k um�r�n�"},
        {"dieAgeInfo","V�k, kdy jedinci za��n� pasivn� ub�vat zdrav� a nakonec po �ase um�r�"},
        {"maxHp","Maxim�ln� zdrav�"},
        {"maxHpInfo","Maxim�ln� zdrav� jedince. Tato hodnota m��e ovlivnit rychlost um�r�n�"},
        {"regenHp","Regenerace zdrav� za �as"},
        {"regenHpInfo","Mno�stv�, kter� si jedinec dopln� za �as. Tato hodnota m��e ovlivnit rychlost um�r�n�"},
        {"maxEnergy","Maxim�ln� energie"},
        {"maxEnergyInfo","Mno�stv� energie rozhoduje o mo�nosti vzplodit potomka/���it sem�nka. Pro zplozen� potomka je pot�eba maximum energie a vy��� hodnota zvy�uje dobu, ne� by mohl zplodit jedince"},
        {"regenEnergy","Regenerace energie za �as"},
        {"regenEnergyInfo","Mno�stv�, kter� si jedinec dopln� za �as"},
        {"foodValue","Hodnota potravy pro predatora"},
        {"foodValueInfo", "Hodnota potravy pro pred�tora, kter� sn� jedince tohoto druhu"},
        {"reproduceCooldown","�as mez porody"},
        {"reproduceCooldownInfo","�as, kter� ur�uje, jak dlouho po porodu/���en� sem�nek se bude sm�t samice zv��ete st�t znova gravitn� a u rostlin, kdy bude vypu�t�no dal�� sem�nko okolo"},
        {"timeHlad","Hlad za �as"},
        {"timeHladInfo","Mno�stv�, kter� jedinec z�sk� za �as. V simulaci se po��t� od 0, kdy nen� ��dn� pot�eba k maxim�ln� hranici, kdy je urgentn� pot�eba"},

        {"timeZizen","��ze� za �as"},
        {"timeZizenInfo","Mno�stv�, kter� jedinec z�sk� za �as. V simulaci se po��t� od 0, kdy nen� ��dn� pot�ebam k maxim�ln� hranici, kdy je urgentn� pot�eba"},
        {"timeSpanek","Pot�eba sp�nku za �as"},
        {"timeSpanekInfo","Mno�stv�, kter� jedinec z�sk� za �as. V simulaci se po��t� od 0, kdy nen� ��dn� pot�ebam k maxim�ln� hranici,  kdy je urgentn� pot�eba"},
        {"maxHlad","Max Hlad"},
        {"maxHladInfo","Maxim�ln� hranice hladu > ovliv�uje dobu, kdy jedinec bude uspokojovat tuto pot�ebu"},
        {"maxZizen","Max ��ze�"},
        {"maxZizenInfo","Maxim�ln� hranice hladu > ovliv�uje dobu, kdy jedinec bude uspokojovat tuto pot�ebu"},
        {"maxSpanek","Max Pot�eba sp�nku"},
        {"maxSpanekInfo","Maxim�ln� hranice hladu > ovliv�uje dobu, kdy jedinec bude uspokojovat tuto pot�ebu"},
        {"pregnancyTime","�as do porodu"},
        {"pregnancyTimeInfo","Doba, kter� ur�uje, po jak� dob�, se narod� nov� jedinec od zplozen�"},
        {"strenght","S�la �toku"},
        {"strenghtInfo","Ur�uje s�lu �toku jedince, kdy �to�� na jin� zv��ata (v obran�, �i pro potravu"},
       

          //MENU-Sv�t//
        {"Multiplier","N�sobi� v��ky"},
        {"MultiplierInfo","ur�uje v��kov� rozd�l mezi body"},
        {"SWidth","Po�et blok� do ���ky"},
        {"SWidthInfo","Po�et bod� v m��ce sm�rem doprava"},
        {"SDepth","Po�et blok� do hloubky"},
        {"SDepthInfo","Po�et bod� v m��ce sm�rem nahoru"},
        {"Seed","Sem�nko mapy - doporu�eno 270, anebo 435"},
        {"SeedInfo","Sem�nko mapy, kter� rozhoduje podobu ter�nu. N�kter� seedy nefunguj� a proto se doporu�uje seed 435,270, proto�e byly vyzkou�ny"},



         //Simulace-Sv�t//        
        {"ShowStatisticWindow","Zobrazit statistiku"},
        {"BackToMenu","Zp�tky do menu"},
        {"PauseSimulation","Zapauzovat Simulaci"},
        {"UnpauseSimulation","Odpauzovat Simulaci"},


          //Simulace-StatisticMenu//        
        {"ShowStatisticEvent","Zobrazit ud�losti"},
        {"ShowAnimals","Zobrazit zv��ata"},
        {"ShowKind","Zobrazit statistiky druh�"},
        {"ShowPlants","Zobrazit rostliny"},
        {"ResetStatWindow","Aktualizovat" },
        {"CloseWindow","Zav��t okno"},
    };

    public static string GetCaption(string KeyCaption)
    {
        if (string.IsNullOrEmpty(KeyCaption))
        {
            return "? Kl�� nebyl nastaven ?";
        }
        if (slovnik.TryGetValue(KeyCaption, out string caption))
        {
            return caption;
        }
        else return "? Nenalezen text - kl��: '" + KeyCaption + "' ?";
    }
}
