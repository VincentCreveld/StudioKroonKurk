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
    public GameObject flower;

    private void Start()
    {
        questId = questNo;
        gm = GameManager.instance;
        state = QuestState.canAccept;
        Initialise(questNo);
		GameManager.instance.SetNewQuestProgress("Vind Jack in het bos");
	}

	public override void Initialise(int i)
	{
		gm.questList.Add(i, this);
		CreateProgressTreeStructure();
		CreateQPNeg1();
		CreateQP0();
		CreateQP1();
	}

	public void CreateProgressTreeStructure()
	{
		AddOption(new QuestGate(EntryId, QuestComp, Progress0, PN1_Entry, QuestClosed, questNo));
		//AddOption(new QuestStepGate(ProgressNeg1, PN1_Entry, Progress0, questNo, 0));
		AddOption(new QuestStepGate(Progress0, P0_Entry, Progress1, questNo, 0));
		AddOption(new QuestStepGate(Progress1, P1_Entry, QuestComp, questNo, 1));
		//AddOption(new QuestStepGate(Progress2, P2_Entry, Progress3, questNo, 3));
		//AddOption(new QuestStepGate(Progress3, P3_Entry, QuestComp, questNo, 4));

		AddOption(new ReturnControl(CloseDialog));
		AddOption(new Function(AddProg, CloseDialog, CloseDiaFunc));
		AddOption(new Function(SetToInProgress, PN1_C1, SetToInProgressFunc));
		gm.dSFuncDict.Add(SetToInProgressFunc, () => SetQuestState(QuestState.ongoing));
		gm.dSFuncDict.Add(CloseDiaFunc, IncrementQuestProgress);

		AddOption(new DialogText(QuestComp, CloseDialog, "Je hebt me een groote dienst bewezen!\nDankjewel!"));
		AddOption(new DialogText(QuestCanAccept, CloseDialog, "Je hebt me een groote dienst bewezen!\nDankjewel!"));
		AddOption(new DialogText(QuestClosed, CloseDialog, "Ik heb je hulp niet meer nodig."));
	}

	public void CreateQPNeg1()
	{
		AddOption(new DialogText(PN1_D0, PN1_C0, "Het lukt me maar niet om mijn bloemen te laten groeien."));
		AddOption(new DialogText(PN1_D1, CloseDialog, "Oké, geen probleem. Sorry."));
		AddOption(new DialogText(PN1_D2, PN1_D6, "Ja ze staan de hele dag in de zon.\nDat zou toch goed moeten zijn?"));
		AddOption(new DialogText(PN1_D3, PN1_D5, "Ah oké, ik zal wel even op zoek gaan naar wat water."));
		AddOption(new DialogText(PN1_D4, PN1_D3, "Nou, ik heb er spijt van dat ik niet veel tijd met mijn moeder heb doorgebracht.\nDus ik wil haar bloemen brengen."));
		AddOption(new DialogText(PN1_D5, AddProg, "Dankjewel! Er staat volgens mij ergens naast mijn schuurtje een emmer."));
		AddOption(new DialogText(PN1_D6, PN1_C2, "Als ze in de zon staan is het goed.\nGeef je ze ook water?"));
		AddOption(new Choice(PN1_C0, PN1_D1, SetToInProgress, "Het is echt heel belangrijk.\nZou je me kunnnen helpen?", "Ik heb nu even geen tijd.", "Ja, tuurlijk kan ik helpen."));
		AddOption(new Choice(PN1_C1, PN1_C2, PN1_D2, "Ik weet niet goed wat ik moet doen om\nde bloemen in leven te houden.", "Heb je de bloemen al water gegeven?", "Hebben de bloemen wel genoeg zonlicht?"));
		AddOption(new Choice(PN1_C2, PN1_D5, PN1_C3, "Oh, water geven, inderdaad!\nKun je water voor mij zoeken?", "Ik zal wel op zoek gaan naar wat water voor je.", "Waarom kan je het niet zelf halen?"));
		AddOption(new Choice(PN1_C3, PN1_D3, PN1_D4, "Ik kan daar nog niet heen, niet voordat ik de bloemen heb.", "Ah oké, ik zal wel even op zoek gaan naar wat water.", "Oh, wat is er gebeurt dan?"));
	}

	public void CreateQP0()
	{
		AddOption(new ItemGate(P0_IG0, P0_IG1, P0_D0, P0_I0));
		AddOption(new ItemGate(P0_IG1, P0_D4, P0_D2, P0_I1));

		AddOption(new DelayElement(P0_A0, P0_C0, P0_AI0));
		AddOption(new DelayElement(P0_A1, P0_D14, P0_AI1));
		AddOption(new DelayElement(P0_A2, AddProg, P0_AI2));

		AddOption(new DialogText(P0_D0, P0_D1,"Heb je de emmer al gevonden? Hij zou ergens naast\nmijn schuurtje moeten staan."));
		AddOption(new DialogText(P0_D1, CloseDialog, "Top, ik zie hem al staan."));
		AddOption(new DialogText(P0_D2, P0_D3, "Het beekje zou ergens ten westen moeten zijn. Volg het pad\n en je vindt het wel."));
		AddOption(new DialogText(P0_D3, CloseDialog, "Ik zal wel even kijken!"));
		AddOption(new DialogText(P0_D4, P0_A0, "Hier is wat water, geef je ze water?"));
		AddOption(new DialogText(P0_D5, P0_C1, "Nee, maar nu ze er niet meer is heb ik heel erg spijt \ndat ik niet veel tijd met haar heb doorgebracht."));
		AddOption(new DialogText(P0_D6, P0_D7, "Toen ik klein was, bate ze koekjes voor mijn vrienden op school en die\ngaf ze dan aan mijn vrienden met een handgeschreven briefje erbij."));
		AddOption(new DialogText(P0_D7, P0_D8, "Daar schreef ze dan op dat ze zo blij is dat ze mijn vrienden waren."));
		AddOption(new DialogText(P0_D8, P0_D9, "En ik wil eigenlijk graag bloemen brengen omdat ze heel erg hield van planten en bomen."));
		AddOption(new DialogText(P0_D9, P0_D10, "We hadden vroeger drie bomen in de tuin en ze verzorgde die bomen zo goed.\nZe was dagelijks in de tuin bezig met de bomen."));
		AddOption(new DialogText(P0_D10, P0_D11, "Het gekke was dat ze met de bomen praatte."));
		AddOption(new DialogText(P0_D11, P0_D12, "Soms had mijn moeder gewoon volledig éénzijdige gesprekken met de bomen."));
		AddOption(new DialogText(P0_D12, P0_D13, "En ze gaf de bomen ook namen. We hadden Daphne de appelboom,\nTom de eikenboom en Vincent de Berk."));
		AddOption(new DialogText(P0_D13, P0_A1, "Dus ik wil nu zelf graag een bloem groeien voor haar."));
		AddOption(new DialogText(P0_D14, P0_A2, "Ah de bloem is gegroeid! Nu kan ik hem eindelijk\nbij mijn moeder neerleggen."));

		AddOption(new Choice(P0_C0, P0_C1, P0_D5, "Ik hoop dat het helpt.\nIk wil deze bloemen zelf groeien om naar mijn moeder te brengen.", "Oh wat lief!", "Is het voor iets speciaals?"));
		AddOption(new Choice(P0_C1, P0_D6, P0_D9, "Heh. Naja, mijn moeder was altijd een beetje vreemd.\nWel ontzettend lief, maar wel gewoon een beetje vreemd.", "Hmm, Vreemd? Hoezo vreemd?", "Waaom wil je dan nu een bloem voor haar groeien?"));
	}

	public void CreateQP1()
	{
		AddOption(new DelayElement(P1_A0, P1_C0, P1_AI0));
		AddOption(new DelayElement(P1_A1, AddProg, P1_AI1));

		AddOption(new Choice(P1_C0, P1_D0, P1_D1, "", "Is dit het graf van je moeder?", "Zijn dit de bomen uit je achtertuin?"));

		AddOption(new DialogText(P1_D0, P1_D2, "Nee, maar deze plek was wel heel belangrijk voor haar."));
		AddOption(new DialogText(P1_D1, P1_D2, "Dit zijn Daphne, Tom en Vincent."));
		AddOption(new DialogText(P1_D2, P1_D3, "Vlak voordat mijn moeder overleed had ze nog één laatste wens aan mij."));
		AddOption(new DialogText(P1_D3, P1_D4, "Ze vroeg mij om altijd te blijven zorgen voor de bomen en\nvroeg zelfs of ik tegen ze kon blijven praten."));
		AddOption(new DialogText(P1_D4, P1_D5, "En zeg maar, ik wilde het wel, maar het lukte me niet\nom tegen planten te gaan praten."));
		AddOption(new DialogText(P1_D5, P1_D6, "Ik weet ook gewoon niet wat ik zou zeggen."));
		AddOption(new DialogText(P1_D6, P1_D7, "\"Hey Tom, hoe gaat het\"?"));
		AddOption(new DialogText(P1_D7, P1_A1, "Nou laat maar. Ik weet het ook niet meer."));
	}

	// Entry 100300
	//public override void Initialise(int i)
	//   {
	//       gm.questList.Add(questNo, this);

	//       AddOption(new DialogText(199999, 404, "Je hebt me al geholpen! dankjewel."));
	//       AddOption(new DialogText(199998, 404, "Ik heb je hulp nog niet nodig."));
	//       AddOption(new DialogText(199997, 404, "Bedankt voor de hulp!"));
	//       QuestProgressNeg1();
	//       QuestProgress0();
	//       QuestProgress1();
	//       QuestProgress2();
	//       QuestProgress3();

	//       //SOLVE THESE

	//       int entryQP0 = 100004;
	//       int entryQP1 = 101200;
	//       int entryQP2 = 102000;
	//       int entryQP3 = 103100;
	//       int entryQP4 = 103100;


	//       AddOption(new QuestGate(100300, 199999, 100400, 100100, 199998, questNo));
	//       AddOption(new QuestStepGate(100400, entryQP0, 100401, questNo, 0));
	//       AddOption(new QuestStepGate(100401, entryQP1, 100402, questNo, 1));
	//       AddOption(new QuestStepGate(100402, entryQP2, 100403, questNo, 2));
	//       AddOption(new QuestStepGate(100403, entryQP3, 100404, questNo, 3));
	//       AddOption(new QuestStepGate(100404, entryQP4, 199997, questNo, 4));

	//	// These should be subbed for DelayElement dialog entities
	//       gm.dSFuncDict.Add(100600, IncrementQuestProgress);
	//       gm.dSFuncDict.Add(102600, StartGiveWater);
	//       gm.dSFuncDict.Add(102601, JackDisappears);
	//       gm.dSFuncDict.Add(103600, StartEndScene);

	//       gm.dSFuncDict.Add(101697, () => { EnableWaterPickup(); IncrementQuestProgress(); });
	//       gm.dSFuncDict.Add(101695, () => state = QuestState.ongoing );
	//       gm.dSFuncDict.Add(101694, () => state = QuestState.closed );
	//   }

	private void AddOption(DialogEntity e)
    {
        gm.allOptions.Add(e);
    }

    //private void QuestProgressNeg1()
    //{
    //    AddOption(new Choice(100100, 404, 100000, "Hey, zou je me kunnen helpen?", "Ik heb nu even geen tijd.", "Waar heb je hulp bij nodig?"));
    //    AddOption(new DialogText(100000, 100101, "Ik ben opzoek naar iemand die \nwat water voor me kan halen."));
    //    AddOption(new Choice(100101, 100598, 100598, "Ik probeer al een tijdje deze bloemen te laten groeien maar het blijft maar mislukken.", "Ik kan wel wat water voor je zoeken", "Geen probleem!"));
    //    AddOption(new Function(100598, 100500, 101695));
    //    AddOption(new Function(100500, 100400, 100600));
    //}
    //private void QuestProgress0()
    //{
    //    AddOption(new DialogText(100004, 100001, "Waar vind ik het water?", true));
    //    AddOption(new DialogText(100001, 100002, "Een stukje verderop in het noorden is een vijvertje bij een hele grote boom. Ik denk dat je daar wel water kan halen."));
    //    AddOption(new DialogText(100002, 100003, "Ik denk dat ik hier ook nog ergens een emmer heb liggen."));
    //    AddOption(new DialogText(100003, 100501, "Ik zal kijken wat ik voor je kan doen.", true));
    //    AddOption(new Function(100501, 404, 100600));
    //}

    //private void QuestProgress1()
    //{
    //    gm.itemList.Add(101700, new Item(101700, "Emmer"));
    //    gm.itemList.Add(101701, new Item(101701, "WaterEmmer"));
    //    // Is de emmer gevonden?
    //    AddOption(new ItemGate(101200, 101201, 101000, 101700));
    //    // Is de emmer gevuld met water?
    //    AddOption(new ItemGate(101201, 404, 101004, 101701));
    //    // Emmer gevonden, nog geen water
    //    AddOption(new DialogText(101004, 101002, "Ik heb de emmer gevonden, waar kan ik water halen?", true));
    //    AddOption(new DialogText(101002, 101003, "De vijver zou ergens in het noorden moeten zijn, als je de weg volgt dan kom je er vanzelf wel."));
    //    AddOption(new DialogText(101003, 404, "Ik zal wel even kijken!", true));

    //    // Emmer nog niet gevonden
    //    AddOption(new DialogText(101000, 101001, "Heb je de emmer al gevonden? \n Ik denk dat hij ergens in de buurt van mijn schuurtje ligt. "));
    //    AddOption(new DialogText(101001, 404, "Top, dan zal ik hem wel vinden.", true));
    //}

    //private void QuestProgress2()
    //{
    //    // Water gevonden
    //    AddOption(new DialogText(102000, 102001, "Hier is het water, hopelijk helpt het.", true));
    //    AddOption(new DialogText(102001, 102011, "Ik zal het even proberen, ik wilde deze bloemen graag zelf groeien om naar mijn moeder te brengen."));
    //    AddOption(new DialogText(102011, 102500, "*Jack geeft de bloem water en jullie wachten.*"));
    //    AddOption(new Function(102500, 102501, 102600));
    //    AddOption(new Function(102501, 102002, 100600));

    //    AddOption(new DialogText(102002, 102003, "Waarom wil je graag de bloemen naar je moeder brengen?", true));
    //    AddOption(new DialogText(102003, 102004, "Ja, mijn moeder was altijd een beetje vreemd. Wel ontzettend lief, maar gewoon een beetje vreemd."));
    //    AddOption(new DialogText(102004, 102005, "Hmm vreemd? Hoezo vreemd?", true));
    //    AddOption(new DialogText(102005, 102006, "Toen ik klein was, bakte ze wel eens koekjes en die gaf ze dan aan mijn vrienden op school en bij elk koekje zat een handgeschreven briefje."));
    //    AddOption(new DialogText(102006, 102007, "op die briefjes stond dan hoe blij ze was dat ze mijn vrienden waren."));
    //    AddOption(new DialogText(102007, 102008, "Heb je haar nooit gevraagd waarom ze dat deed vroeger?", true));
    //    AddOption(new DialogText(102008, 102502, "Nee, en nu kan dat ook niet meer."));
    //    AddOption(new Function(102502, 102009, 102600));
    //    AddOption(new DialogText(102009, 102010, "Ah de bloem is gegroeid! Nu kan ik hem eindelijk bij mijn moeder neerleggen."));
    //    AddOption(new DialogText(102010, 102503, "*Jack loopt weg, misschien moet je hem even gaan zoeken*"));
    //    AddOption(new Function(102503, 102504, 102601));
    //    AddOption(new Function(102504, 404, 100600));
    //}

    //private void QuestProgress3()
    //{
    //    AddOption(new Choice(103100, 103000, 103000, "Afgelopen zomer kreeg ik het telefoontje...", "Was dat haar voor die bomen?", "Bijzondere bomen op de foto."));
    //    AddOption(new DialogText(103000, 103001, "We hadden vroeger drie bomen in de tuin staan en hoewel mijn moeder deze bomen gewoon verzorgde, was ze er ook heel vaak tegen aan het praten."));
    //    AddOption(new DialogText(103001, 103002, "Maar de bomen waren zo belangrijk voor haar, soms hield ze gewoon volledig eenzijdige gesprekken met de bomen."));
    //    AddOption(new DialogText(103002, 103003, "En ze gaf de bomen ook namen, we hadden Iris de appelboom, Tom de eikenboom en Vincent de berk."));
    //    AddOption(new DialogText(103003, 103500, "Ik heb wel spijt van dat ik de laatste jaren niet veel tijd met haar heb doorgebracht."));
    //    AddOption(new Function(103500, 103501, 103600));
    //    AddOption(new Function(103501, 199997, 101694));
    //}

    private void StartEndScene()
    {
		// TODO
    }
    private void JackDisappears()
    {
        jack.transform.position = memorialPoint.position; 
    }
    private void StartGiveWater()
    {
        flower.SetActive(true);
    }
    private void EnableMarker()
    {
        marker.gameObject.SetActive(true);
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

		//if(currentQuestProgress > questMarkerPositions.Count - 1)
		//{
		//	marker.gameObject.SetActive(false);
		//	return;
		//}
		//else
		//	marker.gameObject.SetActive(true);
		//if(questMarkerPositions[currentQuestProgress].position != null)
		//	marker.position = questMarkerPositions[currentQuestProgress].position;
	}
    private void EnableWaterPickup()
    {
        emptyBucket.gameObject.SetActive(false);
        waterBucket.gameObject.SetActive(true);
    }
}
