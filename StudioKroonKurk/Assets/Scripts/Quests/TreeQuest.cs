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
    public string characterName;
    private void Start()
    {
        questId = questNo;
		gm = GameManager.instance;
        state = QuestState.canAccept;
        Initialise(questNo);
		gm.SetNewQuestProgress("Vind Jack in het bos");
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
		AddOption(new QuestStepGate(Progress0, P0_Entry, Progress1, questNo, 0));
		AddOption(new QuestStepGate(Progress1, P1_Entry, QuestComp, questNo, 1));
        AddOption(new QuestStepGate(Progress2, P2_Entry, QuestComp, questNo, 2));

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
		AddOption(new DialogText(PN1_D3, PN1_D5, "Ah oké, ik zal wel even op zoek gaan naar wat water.", true));
		AddOption(new DialogText(PN1_D4, PN1_D3, "Nou, ik heb er spijt van dat ik niet veel tijd met mijn moeder heb doorgebracht.\nDus ik wil haar bloemen brengen."));
		AddOption(new DialogText(PN1_D5, AddProg, "Dankjewel! Er staat volgens mij ergens naast mijn schuurtje een emmer."));
		AddOption(new DialogText(PN1_D6, PN1_C2, "Als ze in de zon staan is het goed.\nGeef je ze ook water?", true));
		AddOption(new Choice(PN1_C0, PN1_D1, SetToInProgress, "Het is echt heel belangrijk.\nZou je me kunnen helpen?", "Ik heb nu even geen tijd.", "Ja, tuurlijk kan ik helpen."));
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
		AddOption(new DialogText(P0_D1, CloseDialog, "Top, ik zie hem al staan.", true));
		AddOption(new DialogText(P0_D2, P0_D3, "Het beekje zou ergens ten westen moeten zijn. Volg het pad\n en je vindt het wel."));
		AddOption(new DialogText(P0_D3, CloseDialog, "Ik zal wel even kijken!", true));
		AddOption(new DialogText(P0_D4, P0_A0, "Hier is wat water, geef je ze water?", true));
		AddOption(new DialogText(P0_D5, P0_C1, "Nee, maar nu ze er niet meer is heb ik heel \n erg spijt dat ik niet veel tijd met haar heb doorgebracht."));
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
		AddOption(new DelayElement(P1_A1, P1_D8, P1_AI1));

		AddOption(new Choice(P1_C0, P1_D0, P1_D1, "", "Is dit het graf van je moeder?", "Zijn dit de bomen uit je achtertuin?"));

		AddOption(new DialogText(P1_D0, P1_D2, "Nee, maar deze plek was wel heel belangrijk voor haar."));
		AddOption(new DialogText(P1_D1, P1_D2, "Dit zijn Daphne, Tom en Vincent."));
		AddOption(new DialogText(P1_D2, P1_D3, "Vlak voordat mijn moeder overleed had ze nog één laatste wens aan mij."));
		AddOption(new DialogText(P1_D3, P1_D4, "Ze vroeg mij om altijd te blijven zorgen voor de bomen en\nvroeg zelfs of ik tegen ze kon blijven praten."));
		AddOption(new DialogText(P1_D4, P1_D5, "En zeg maar, ik wilde het wel, maar het lukte me niet\nom tegen planten te gaan praten."));
		AddOption(new DialogText(P1_D5, P1_D6, "Ik weet ook gewoon niet wat ik zou zeggen."));
		AddOption(new DialogText(P1_D6, P1_D7, "\"Hey Tom, hoe gaat het\"?"));
		AddOption(new DialogText(P1_D7, P1_A1, "Nou laat maar. Ik weet het ook niet meer."));
        AddOption(new DialogText(P1_D8, AddProg, "Tegen bomen praten? Hmm... Zouden ze dan ook antwoorden?",true));
    }

    public void CreateQP2()
    {
        AddOption(new DelayElement(P2_A0, P2_D0, P2_AI0));
        //AddOption(new DelayElement(P2_A1, , P2_AI1));
        AddOption(new DialogText(P2_D0, P2_D1, "Uhm... Hallo?",true));
        AddOption(new DialogText(P2_D1, P2_D2, "..."));
        AddOption(new DialogText(P2_D2, P2_D3, "Ja, oké... Ik ben " + characterName + ".",true));
        AddOption(new DialogText(P2_D3, P2_D4, "Heb jij ook een naam?",true));
        AddOption(new DialogText(P2_D4, P2_D5, "Woooooooosh..."));

        AddOption(new Choice(P2_C0, P2_D6, P2_D7, "", "Wat is je naam?", "Heet jij Daphne?"));
        AddOption(new DialogText(P2_D6, P2_D9, "..."));
        AddOption(new DialogText(P2_D9, P2_C1, "Oké, geen antwoord... Dat werkt dus niet.",true));
        AddOption(new Choice(P2_C1, P2_D11, P2_D8, "", "Is het Tom?", "Is het Daphne?"));
        AddOption(new DialogText(P2_D11, P2_C2, "Woosh.. Woosh.."));
        AddOption(new Choice(P2_C2, P2_D8, P2_D12, "", "Daphne, dan?", "Zeg het gewoon."));
        AddOption(new DialogText(P2_D12, P2_D13, "..."));
        AddOption(new DialogText(P2_D13, P2_C2, "Oké, geen antwoord... Dat werkt dus niet.", true));
        AddOption(new DialogText(P2_D7, P2_D8, "Jack zei eerder dat je Daphne heet, is dat jou naam?",true));
        AddOption(new DialogText(P2_D8, P2_D10, "Woooooooosh..."));


    }


    private void AddOption(DialogEntity e)
    {
        gm.allOptions.Add(e);
    }

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
