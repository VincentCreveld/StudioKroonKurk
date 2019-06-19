using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TreeQuest : Quest
{
    public List<Transform> questMarkerPositions;
    public Transform marker;
    public int questNo;
    public Transform emptyBucket, waterBucket;
    public GameObject jack;
    public Transform memorialPoint;
    public string characterName = "Alex";

    public RuneRootController TreeRoots;
    public RuneRootController HouseRoots;
    public RuneRootController HillRoots;

    private int currentMarkerPos = -1;

    private void Start()
    {
        questId = questNo;
		gm = GameManager.instance;
        state = QuestState.canAccept;
        Initialise(questNo);
		gm.SetNewQuestProgress("Vind Jack in het bos");

        IncrementQuestMarkerPos();

        if(PlayerPrefs.HasKey("PlayerName"))
            characterName = PlayerPrefs.GetString("PlayerName");

	}

	public override void Initialise(int i)
	{
		gm.questList.Add(i, this);
		CreateProgressTreeStructure();
		CreateQPNeg1();
		CreateQP0();
		CreateQP1();
		CreateQP2();
        CreateQP3();
        CreateQP4();
    }

	public void CreateProgressTreeStructure()
	{
		AddOption(new QuestGate(EntryId, QuestComp, Progress0, PN1_Entry, QuestClosed, questNo));
		AddOption(new QuestStepGate(Progress0, P0_Entry, Progress1, questNo, 0));
		AddOption(new QuestStepGate(Progress1, P1_Entry, QuestComp, questNo, 1));
        AddOption(new QuestStepGate(Progress2, P2_Entry, QuestComp, questNo, 0));

		AddOption(new ReturnControl(CloseDialog));
		AddOption(new Function(AddProg, CloseDialog, CloseDiaFunc));
        AddOption(new Function(RemoveRoots, AddProg, RemoveRootsFunc));
        AddOption(new Function(EnableRoots, AddProg, EnableRootsFunc));
        AddOption(new Function(ChangeRootsToTree, AddProg, RootsToTreeFunc));
        AddOption(new Function(ChangeRootsToHouse, 404, RootsToHouseFunc));
        AddOption(new Function(EndScene, AddProg, StartEndSceneFunc));

        AddOption(new Function(SetToInProgress, PN1_C1, SetToInProgressFunc));
		gm.dSFuncDict.Add(SetToInProgressFunc, () => SetQuestState(QuestState.ongoing));
		gm.dSFuncDict.Add(CloseDiaFunc, IncrementQuestProgress);
		gm.dSFuncDict.Add(RemoveRootsFunc, RemoveTheBlockade);
		gm.dSFuncDict.Add(RootsToTreeFunc, RootsToTree);
		gm.dSFuncDict.Add(RootsToHouseFunc, RootsToHouse);
        gm.dSFuncDict.Add(EnableRootsFunc, EnableTheBlockade);
        gm.dSFuncDict.Add(StartEndSceneFunc, StartEndScene);


        AddOption(new DialogText(QuestComp, CloseDialog, "Je hebt me een groote dienst bewezen!\nDankjewel!"));
		AddOption(new DialogText(QuestCanAccept, CloseDialog, "Je hebt me een groote dienst bewezen!\nDankjewel!"));
		AddOption(new DialogText(QuestClosed, CloseDialog, "Ik heb je hulp niet meer nodig."));
	}

	public void CreateQPNeg1()
	{
        AddOption(new DialogText(PN1_D0, PN1_D1, "Oh! Hey! ehm..."));
        AddOption(new DialogText(PN1_D1, PN1_D2, "Ik ben Jack! \n...."));
        AddOption(new DialogText(PN1_D2, PN1_C0, "Ik ben... de kluts een beetje kwijt. \nZou je mij willen helpen? Met deze bloem?"));
        AddOption(new DialogText(PN1_D3, PN1_D4, "Nee, sorry ik heb nu eigenlijk geen tijd.", true));
        AddOption(new DialogText(PN1_D4, CloseDialog, "Oh... sorry. Ik wilde je niet lastig vallen. \nAls je later tijd hebt, zou je dan nog even terug willen komen?"));
        AddOption(new DialogText(PN1_D5, SetToInProgress, "Ja tuurlijk kan ik helpen, waar heb je hulp bij nodig?", true));
        AddOption(new DialogText(PN1_D6, PN1_D10, "Als ze in de zon staan is het goed.\nGeef je ze ook water?", true));
        AddOption(new DialogText(PN1_D7, PN1_D10, "Ja, dan zou dat geen probleem kunnen zijn. \nGeef je ze ook water?", true));
        AddOption(new DialogText(PN1_D8, PN1_D10, "Hmmm...geef je ze ook water?", true));
        AddOption(new DialogText(PN1_D9, PN1_D10, "Heb je de bloemen al water gegeven?", true));
        AddOption(new DialogText(PN1_D10, PN1_C2, "Ik heb het water uit de rivier geprobeerd, maar dat werkt dus niet zo goed...  "));
        AddOption(new DialogText(PN1_D11, PN1_D12, "Ik zal wel even voor je rondkijken.", true));
        AddOption(new DialogText(PN1_D13, PN1_C4, "Waarom kan je niet zelf wat water halen?", true));
        AddOption(new DialogText(PN1_D14, PN1_C5, "Oh, waarom heb je die bloem dan zo hard nodig?", true));
        AddOption(new DialogText(PN1_D15, PN1_D16, "Wat vervelend zeg, ik zal je meteen helpen.", true));
        AddOption(new DialogText(PN1_D16, PN1_D12, "Ik zal wel even rond gaan kijken voor je.", true));

        AddOption(new DialogText(PN1_D12, ChangeRootsToTree, "Dankjewel! Naast mijn schuurtje staat een emmer. "));

        AddOption(new Choice(PN1_C0, PN1_D3, PN1_D5, "Het is echt heel belangrijk!", "Nee", "Ja, tuurlijk!"));
        AddOption(new Choice(PN1_C1, PN1_D9, PN1_C3, "Het lukt me niet om deze bloem te laten groeien...", "Vraag over water.", "Vraag over zonlicht."));
        AddOption(new Choice(PN1_C2, PN1_D11, PN1_D13, "Volgens mij is er ergens nog een vijver met heel schoon water. Zou jij die kunnen zoeken?", "Ik zal wel kijken.", "Kun je dat niet zelf?"));
        AddOption(new Choice(PN1_C3, PN1_D6, PN1_D7, "Ja, ze staan de hele dag in de zon, dat zou toch goed moeten zijn?", "Vraag over water.", "Ja dat is goed."));
        AddOption(new Choice(PN1_C4, PN1_D16, PN1_D14, "Ik... Ehm... Ik kan hier nog niet weg. \nIk moet echt eerst die bloem hebben.", "Ah oké, is goed.", "Oh, waarom dan?"));
        AddOption(new Choice(PN1_C5, PN1_D16, PN1_D15, "De bloem is voor mijn moeder. Ik heb er namelijk spijt van \ndat ik zo weinig tijd met haar heb doorgebracht...", "Ik zal je wel helpen.", "Oh wat naar."));

    }

	public void CreateQP0()
	{
        AddOption(new ItemGate(P0_IG0, P0_IG1, P0_D0, P0_I0));
        AddOption(new ItemGate(P0_IG1, P0_D4, P0_D2, P0_I1));

        AddOption(new DelayElement(P0_A0, P0_C0, P0_AI0));
        AddOption(new DelayElement(P0_A1, P0_D14, P0_AI1));
        AddOption(new DelayElement(P0_A2, RemoveRoots, P0_AI2));

        // Emmer niet aanwezig
        AddOption(new DialogText(P0_D0, P0_D1, "Heb je de emmer al gevonden? Hij zou ergens naast\nmijn schuurtje moeten staan."));
        AddOption(new DialogText(P0_D1, CloseDialog, "Top! Ik neem nog een kijkje.", true));

        // Emmer nog niet gevuld met water
        AddOption(new DialogText(P0_D2, P0_D3, "In het noorden, aan de top van die berg. Volgens mij heb ik daar een vijver gezien."));
        AddOption(new DialogText(P0_D3, CloseDialog, "Ik zal wel even kijken!", true));

        // Emmer en water aanwezig
        AddOption(new DialogText(P0_D4, P0_D15, "Ik heb het water voor je!", true));
        AddOption(new DialogText(P0_D5, P0_C1, "Weet je... Nu ze er niet meer is heb ik heel erg spijt dat ik niet meer tijd met haar heb doorgebracht."));
        AddOption(new DialogText(P0_D6, P0_D7, "Toen ik klein was, bakte ze koekjes voor mijn vrienden op school en die gaf ze dan aan mijn vrienden met een handgeschreven briefje erbij."));
        AddOption(new DialogText(P0_D7, P0_D8, "Daar schreef ze dan op dat ze zo blij is dat ze mijn vrienden waren."));
        AddOption(new DialogText(P0_D8, P0_D9, "En ik wil eigenlijk graag bloemen brengen omdat ze heel erg hield van planten en bomen."));
        AddOption(new DialogText(P0_D9, P0_D10, "We hadden vroeger drie bomen in de tuin en ze verzorgde die bomen zo goed.\nZe was dagelijks in de tuin bezig met de bomen."));
        AddOption(new DialogText(P0_D10, P0_D11, "Het gekke was dat ze met de bomen praatte."));
        AddOption(new DialogText(P0_D11, P0_D12, "Soms had mijn moeder gewoon volledig éénzijdige gesprekken met de bomen."));
        AddOption(new DialogText(P0_D12, P0_D13, "En ze gaf de bomen ook namen. We hadden Daphne de appelboom,\nTom de eikenboom en Vincent de Eucalyptus."));
        AddOption(new DialogText(P0_D13, P0_A1, "Dus ik wil nu zelf graag een bloem groeien voor haar."));
        AddOption(new DialogText(P0_D14, P0_A2, "Ah de bloem is gegroeid! Nu kan ik hem eindelijk\nbij mijn moeder neerleggen."));

        AddOption(new Choice(P0_C0, P0_C1, P0_D5, "Ik hoop echt dat het werkt! Mijn moeder zou zo blij worden als ze zag dat ik zelf een bloem geplant heb!", "Oh wat lief!", "Is het voor iets speciaals?"));
        AddOption(new Choice(P0_C1, P0_D6, P0_D16, "Mijn moeder was altijd wel ontzettend lief, \nmaar ook gewoon een beetje vreemd.", "Hmm, Vreemd? Hoezo vreemd?", "Waarom de bloem?"));

        AddOption(new DialogText(P0_D15, P0_A0, "Dankjewel! Ik geef het meteen aan de bloem!"));
        AddOption(new DialogText(P0_D16, P0_D9, "Waarom wil je dan nu een bloem voor haar groeien?", true));
    }

    public void CreateQP1()
    {
        AddOption(new DelayElement(P1_A0, P1_C0, P1_AI0));
        AddOption(new DelayElement(P1_A1, P1_D8, P1_AI1));

        AddOption(new Choice(P1_C0, P1_D9, P1_D1, "", "Vraag over moeders graf", "Vraag over bomen uit tuin"));

        AddOption(new DialogText(P1_D0, P1_D2, "Nee, maar deze plek was wel heel belangrijk voor haar."));
        AddOption(new DialogText(P1_D1, P1_D2, "Dit zijn Daphne, Tom en Vincent."));
        AddOption(new DialogText(P1_D2, P1_D3, "Vlak voordat mijn moeder overleed had ze nog één laatste wens aan mij."));
        AddOption(new DialogText(P1_D3, P1_D4, "Ze vroeg mij om altijd te blijven zorgen voor de bomen en\nvroeg zelfs of ik tegen ze kon blijven praten."));
        AddOption(new DialogText(P1_D4, P1_D5, "En zeg maar, ik wilde het wel, maar het lukte me niet\nom tegen planten te gaan praten."));
        AddOption(new DialogText(P1_D5, P1_D6, "Ik weet ook gewoon niet wat ik zou zeggen."));
        AddOption(new DialogText(P1_D6, P1_D7, "\"Hey Tom, hoe gaat het\"?"));
        AddOption(new DialogText(P1_D7, P1_A1, "Nou laat dan maar. Ik weet het ook niet meer."));
        AddOption(new DialogText(P1_D8, EnableRoots, "Tegen bomen praten? Hmm... Zouden ze dan ook antwoorden?", true));

        AddOption(new DialogText(P1_D9, P1_D0, "Is dit het graf van je moeder?", true));
       // AddOption(new DialogText(P1_D10, P1_D1, "Tegen bomen praten? Hmm... Zouden ze dan ook antwoorden?", true));
    }

    public void CreateQP2()
    {
        AddOption(new DelayElement(P2_A0, P2_D0, P2_AI0));
        AddOption(new DelayElement(P2_A1, P2_D33, P2_AI1));
        AddOption(new DialogText(P2_D0, P2_D1, "Uhm... Hallo?",true));
        AddOption(new DialogText(P2_D1, P2_D2, "..."));
        AddOption(new DialogText(P2_D2, P2_D3, "Ja, oké... Ik ben " + characterName + ".",true));
        AddOption(new DialogText(P2_D3, P2_D4, "Heb jij ook een naam?",true));
        AddOption(new DialogText(P2_D4, P2_C0, "Woooooooosh..."));

        AddOption(new Choice(P2_C0, P2_D6, P2_D7, "", "Wat is je naam?", "Heet jij Daphne?"));
        AddOption(new DialogText(P2_D6, P2_D9, "..."));
        AddOption(new DialogText(P2_D9, P2_C1, "Oké, geen antwoord... Dat werkt dus niet.",true));
        AddOption(new Choice(P2_C1, P2_D11, P2_D8, "", "Is het Tom?", "Is het Daphne?"));
        AddOption(new DialogText(P2_D11, P2_C2, "Woosh.. Woosh.."));
        AddOption(new Choice(P2_C2, P2_D8, P2_D12, "", "Daphne, dan?", "Zeg het gewoon."));
        AddOption(new DialogText(P2_D12, P2_D13, "..."));
        AddOption(new DialogText(P2_D13, P2_C2, "Oké, geen antwoord... Dat werkt dus niet.", true));
        AddOption(new DialogText(P2_D7, P2_D8, "Jack zei eerder dat je Daphne heet, is dat jou naam?",true));
        AddOption(new DialogText(P2_D8, P2_C3, "Woooooooosh..."));
        AddOption(new Choice(P2_C3, P2_D16, P2_D14, "", "Ben jij de enige met een naam?", "Wie zijn de andere twee bomen?"));
        AddOption(new DialogText(P2_D14, P2_D15, "..."));
        AddOption(new DialogText(P2_D15, P2_C3, "Hmm, zo krijg ik geen reactie...", true));
        AddOption(new DialogText(P2_D16, P2_D17, "Woosh.. Woosh.."));
        AddOption(new DialogText(P2_D17, P2_D41, "Die ander twee zijn dan zeker Tom en Vincent.", true));
        AddOption(new DialogText(P2_D41, P2_C4, "Woooooooosh..."));
        AddOption(new Choice(P2_C4, P2_D20, P2_D18, "", "Kunnen zij ook praten?", "Vraag over moeder"));
        AddOption(new DialogText(P2_D18, P2_D19, "Kwam Jacks moeder regelmatig met jullie praten?", true));
        AddOption(new DialogText(P2_D19, P2_C8, "Woooooooosh..."));
        AddOption(new DialogText(P2_D20, P2_C6, "Woooooooosh..."));
        AddOption(new Choice(P2_C6, P2_D21, P2_D22, "", "Kunnen alle bomen hier dan praten?", "Wat maakt jullie dan speciaal?"));
        AddOption(new DialogText(P2_D21, P2_C7, "Woosh.. Woosh.."));
        AddOption(new DialogText(P2_D22, P2_D23, "..."));
        AddOption(new DialogText(P2_D23, P2_C7, "Oh, dat is een open vraag...", true));
        AddOption(new Choice(P2_C7, P2_D24, P2_D23, "", "Vraag over moeder", "Lekker weertje, hè."));
        AddOption(new DialogText(P2_D24, P2_D18, "Jack zei dat jullie heel belangrijk waren voor zijn moeder."));
        AddOption(new Choice(P2_C8, P2_D25, P2_D27, "", "Waarover praatte jullie dan?", "Heeft zij jullie ook geplant?"));
        AddOption(new DialogText(P2_D25, P2_D26, "..."));
        AddOption(new DialogText(P2_D26, P2_C8, "Hmm... Geen antwoord.", true));
        AddOption(new DialogText(P2_D27, P2_C9, "Woooooooosh..."));
        AddOption(new Choice(P2_C9, P2_D29, P2_D28, "", "En de andere bomen?", "Was daar een de reden voor?"));
        AddOption(new DialogText(P2_D28, P2_D31, "Was daar ook een bijzondere reden voor?",true));
        AddOption(new DialogText(P2_D29, P2_D30, "Heeft ze alle bomen in dit bos geplant?"));
        AddOption(new DialogText(P2_D30, P2_D32, "Woosh.. Woosh.."));
        AddOption(new DialogText(P2_D31, P2_D32, "Woooooooosh..."));
        AddOption(new DialogText(P2_D32, P2_A1, "Dus jullie drieën zijn echt bijzonder."));
        AddOption(new DialogText(P2_D33, P2_C10, "Er staat 'Daphne 2001' waar zou dat voor zijn.",true));
        AddOption(new Choice(P2_C10, P2_D34, P2_D35, "", "Ben jij de geest van iemand?", "Is die steen voor jou?"));
        AddOption(new DialogText(P2_D34, P2_D36, "Woosh.. Woosh.."));
        AddOption(new DialogText(P2_D35, P2_D36, "Woooooooosh..."));
        AddOption(new DialogText(P2_D36, P2_C11, "dus je bent ooit geplant ter nagedachtenis.", true));
        AddOption(new Choice(P2_C11, P2_D37, P2_D35, "", "Waarom vertel je dit?", "En de andere bomen dan?"));
        AddOption(new DialogText(P2_D37, P2_D38, "..."));
        AddOption(new DialogText(P2_D38, P2_D39, "Wil je dat ik dit aan Jack vertel?", true));
        AddOption(new DialogText(P2_D39, P2_D40, "Woooooooosh..."));
        AddOption(new DelayElement(P3_A0, AddProg, P3_AI0));
        AddOption(new DialogText(P2_D40, P3_A0, "Misschien dat het Jack verder helpt als hij dit hoort. Ik moet het hem vertellen.",true));
    }

     public void CreateQP3()
    {
        AddOption(new DelayElement(P3_A1, EndScene, P3_AI1));
        AddOption(new Choice(P3_C0, P3_D0, P3_D1, "Ik denk… Ik denk dat ik het nog eens moet proberen. \nOok al voelt het nog zo raar.", "Ik heb met ze gepraat.", "Jack, we moeten even praten."));

        AddOption(new DialogText(P3_D0, P3_D2, "Echt? Haha, zeiden ze nog iets terug?"));
        AddOption(new DialogText(P3_D1, P3_D2, "Oh, waarover dan?"));
        AddOption(new DialogText(P3_D2, P3_C1, "Jack. Weet je wie deze bomen echt zijn?", true));

        AddOption(new Choice(P3_C1, P3_D23, P3_D24, "Hoe bedoel je? Het zijn toch gewoon bomen?", "Er was een belangrijke reden.", "Heb je haar er ooit over gevraagd?"));
        AddOption(new DialogText(P3_D23, P3_D3, "Ik denk dat er een reden was dat je moeder met ze sprak."));
        AddOption(new DialogText(P3_D24, P3_D3, "Heb je ooit je moeder gevraagd wie Tom, Vincent en Daphne waren?", true));
        AddOption(new DialogText(P3_D3, P3_D4, "Ik… Waar heb je het over?"));
        AddOption(new DialogText(P3_D4, P3_D5, "Volgens mij zijn hier kinderen begraven.", true));
        AddOption(new DialogText(P3_D5, P3_D6, "Ik... Wacht... Huh."));
        AddOption(new DialogText(P3_D6, P3_D7, "Dit is eigenlijk best logisch, denk ik."));
        AddOption(new DialogText(P3_D7, P3_D8, "Wat. Hoe dan?", true));
        AddOption(new DialogText(P3_D8, P3_D9, "Weet je. Mijn ma, ze... reageerde altijd heftig op bepaalde vragen. "));
        AddOption(new DialogText(P3_D9, P3_D10, "Toen ik klein was wilde ik graag een broertje hebben."));
        AddOption(new DialogText(P3_D10, P3_D11, "Als ik haar erom vroeg werd ze altijd heel stil."));
        AddOption(new DialogText(P3_D11, P3_D12, "Ik snapte nooit helemaal waarom, maar nu..."));
        AddOption(new DialogText(P3_D12, P3_D13, "Tom. Vincent. Daphne. Ze zijn mijn oudere broers en zus, denk ik."));
        AddOption(new DialogText(P3_D13, P3_D14, "..."));
        AddOption(new DialogText(P3_D14, P3_D15, "Ik snap nu waarom mijn moeder altijd met de bomen aan het praten was!"));
        AddOption(new DialogText(P3_D15, P3_D16, "Haha. Ik denk dat ik haar een beetje beter begrijp nu."));
        AddOption(new DialogText(P3_D16, P3_D17, "Ze is wel echt nog steeds een gekkie."));
        AddOption(new DialogText(P3_D17, P3_D18, "Ze was altijd wel heel lief hoor..."));
        AddOption(new DialogText(P3_D18, P3_D19, "Ik denk dat ik een keer een boom voor haar ga planten. Thuis."));
        AddOption(new DialogText(P3_D19, P3_D20, "Hey ehm... Bedankt dat je naar mijn verhaal hebt geluisterd."));
        AddOption(new DialogText(P3_D20, P3_D21, "Volgens mij was ik eventjes verdwaald geraakt."));
        AddOption(new DialogText(P3_D21, P3_D22, "Maar het wordt maar eens tijd dat ik naar huis ga."));
        AddOption(new DialogText(P3_D22, P3_A1, "Hey ehm… Tot ziens he!"));

        //Jack loopt de scene uit, en fade to black. Fade out from black, de drie bomen zijn weg en alleen de photo staat er nog. De speler drukt op de photo, deze verschijnt groot in het midden van het beeld met de volgende tekst eronder:
    }
    public void CreateQP4()
    {
        AddOption(new DialogText(P4_D0, P4_D1, "Je hebt Jacks verhaal gehoord en hem gesteund, waardoor hij zijn weg uit het bos kon vinden."));
        AddOption(new DialogText(P4_D1, P4_D2, "Dit verhaal is nu tot zijn einde gekomen, maar…"));
        AddOption(new DialogText(P4_D2, P4_D3, "…er zijn nog velen, die je ondersteuning kunnen gebruiken."));
        AddOption(new DialogText(P4_D3, 89015678, "Dit verhaal is nu klaar. \nKlik op volgende om terug naar het hoofdmenu te gaan."));
        AddOption(new Function(89015678, 404, 8768876));
        gm.dSFuncDict.Add(8768876, () => gm.LoadLevel("MainMenu"));
    }

    
    private void RootsToTree()
    {
        HouseRoots.SetRootDir(false);
        HouseRoots.SetColor1();
        HillRoots.SetRootDir(true);
        HillRoots.SetColor1();
    }

    private void RootsToHouse()
    {
        HouseRoots.SetRootDir(true);
        HouseRoots.SetColor2();
        HillRoots.SetRootDir(false);
        HillRoots.SetColor2();
    }

    private void AddOption(DialogEntity e)
    {
        gm.allOptions.Add(e);
    }

    private void StartEndScene()
    {
        gm.EndGameScene();
    }
    private void JackDisappears()
    {
        jack.transform.position = memorialPoint.position; 
    }

    private void EnableMarker()
    {
        marker.gameObject.SetActive(true);
    }
    
    private void RemoveTheBlockade()
    {
        GameManager.instance.OpenArea();
    }

    private void EnableTheBlockade()
    {
        GameManager.instance.CloseArea();
    }

    private void IncrementQuestProgress()
    {
		if(currentQuestProgress == -1 && foundJackText != string.Empty)
			GameManager.instance.SetNewQuestProgress(foundJackText);

		if(currentQuestProgress >= 0 && currentQuestProgress < textPerProgressionDone.Count && textPerProgressionDone[currentQuestProgress] != string.Empty)
			GameManager.instance.SetNewQuestProgress(textPerProgressionDone[currentQuestProgress]);

        currentQuestProgress++;

		if(currentQuestProgress < textPerProgressionToDo.Count && textPerProgressionToDo[currentQuestProgress] != string.Empty)
			GameManager.instance.SetNewQuestProgress(textPerProgressionToDo[currentQuestProgress]);

        IncrementQuestMarkerPos();
    }

    public override void IncrementQuestMarkerPos()
    {
        // jaaaaa
        currentMarkerPos++;
        if (currentMarkerPos > questMarkerPositions.Count - 1)
        {
            marker.gameObject.SetActive(false);
            return;
        }
        else
            marker.gameObject.SetActive(true);
        if (questMarkerPositions[currentMarkerPos].position != null)
            marker.position = questMarkerPositions[currentMarkerPos].position;
    }

    private void EnableWaterPickup()
    {
        emptyBucket.gameObject.SetActive(false);
        waterBucket.gameObject.SetActive(true);
    }

    public override void DisableMarkerGraphic()
    {
        marker.gameObject.SetActive(false);
    }

    public override void EnableMarkerGraphic()
    {
        marker.gameObject.SetActive(true);
    }
}
