using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeQuest : Quest
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
    }

    /*
        QuestNo - Progress - Type - id
            1        00        X     00

        X = Types:
            DialogText = 0
            Choice = 1
            ItemGate = 2
            QuestGate = 3
            QuestStepGate = 4
            FunctionEntity = 5
            Function = 6
            Item = 7
            Audio = 8
     */

    // Entry 100300
    public override void Initialise(int i)
    {
        gm.questList.Add(questNo, this);

        AddOption(new DialogText(199999, 404, "Je hebt me al geholpen! dankjewel."));
        AddOption(new DialogText(199998, 404, "Ik heb je hulp nog niet nodig."));
        AddOption(new DialogText(199997, 404, "Bedankt voor de hulp!"));
        QuestProgressNeg1();
        QuestProgress0();
        QuestProgress1();
        QuestProgress2();
        QuestProgress3();

        //SOLVE THESE

        int entryQP0 = 100004;
        int entryQP1 = 101200;
        int entryQP2 = 102000;
        int entryQP3 = 103100;
        int entryQP4 = 103100;


        AddOption(new QuestGate(100300, 199999, 100400, 100100, 199998, questNo));
        AddOption(new QuestStepGate(100400, entryQP0, 100401, questNo, 0));
        AddOption(new QuestStepGate(100401, entryQP1, 100402, questNo, 1));
        AddOption(new QuestStepGate(100402, entryQP2, 100403, questNo, 2));
        AddOption(new QuestStepGate(100403, entryQP3, 100404, questNo, 3));
        AddOption(new QuestStepGate(100404, entryQP4, 199997, questNo, 4));

        gm.dSFuncDict.Add(100600, SetNextQuestMarker);
        gm.dSFuncDict.Add(102600, StartGiveWater);
        gm.dSFuncDict.Add(102601, JackDisappears);
        gm.dSFuncDict.Add(103600, StartEndScene);
        gm.dSFuncDict.Add(101697, () => { EnableWaterPickup(); SetNextQuestMarker(); });
        gm.dSFuncDict.Add(101695, () => state = QuestState.ongoing );
        gm.dSFuncDict.Add(101694, () => state = QuestState.closed );
    }

    private void AddOption(DialogEntity e)
    {
        gm.allOptions.Add(e);
    }

    private void QuestProgressNeg1()
    {
        AddOption(new Choice(100100, 404, 100000, "Hey, zou je me kunnen helpen?", "Ik heb nu even geen tijd.", "Waar heb je hulp bij nodig?"));
        AddOption(new DialogText(100000, 100101, "Ik ben opzoek naar iemand die \nwat water voor me kan halen."));
        AddOption(new Choice(100101, 100598, 100598, "Ik probeer al een tijdje deze bloemen te laten groeien maar het blijft maar mislukken.", "Ik kan wel wat water voor je zoeken", "Geen probleem!"));
        AddOption(new Function(100598, 100500, 101695));
        AddOption(new Function(100500, 100400, 100600));
    }
    private void QuestProgress0()
    {
        AddOption(new DialogText(100004, 100001, "Waar vind ik het water?", true));
        AddOption(new DialogText(100001, 100002, "Een stukje verderop in het noorden is een vijvertje bij een hele grote boom. Ik denk dat je daar wel water kan halen."));
        AddOption(new DialogText(100002, 100003, "Ik denk dat ik hier ook nog ergens een emmer heb liggen."));
        AddOption(new DialogText(100003, 100501, "Ik zal kijken wat ik voor je kan doen.", true));
        AddOption(new Function(100501, 404, 100600));
    }

    private void QuestProgress1()
    {
        gm.itemList.Add(101700, new Item(101700, "Emmer"));
        gm.itemList.Add(101701, new Item(101701, "WaterEmmer"));
        // Is de emmer gevonden?
        AddOption(new ItemGate(101200, 101201, 101000, 101700));
        // Is de emmer gevuld met water?
        AddOption(new ItemGate(101201, 404, 101004, 101701));
        // Emmer gevonden, nog geen water
        AddOption(new DialogText(101004, 101002, "Ik heb de emmer gevonden, waar kan ik water halen?", true));
        AddOption(new DialogText(101002, 101003, "De vijver zou ergens in het noorden moeten zijn, als je de weg volgt dan kom je er vanzelf wel."));
        AddOption(new DialogText(101003, 404, "Ik zal wel even kijken!", true));

        // Emmer nog niet gevonden
        AddOption(new DialogText(101000, 101001, "Heb je de emmer al gevonden? \n Ik denk dat hij ergens in de buurt van mijn schuurtje ligt. "));
        AddOption(new DialogText(101001, 404, "Top, dan zal ik hem wel vinden.", true));
    }

    private void QuestProgress2()
    {
        // Water gevonden
        AddOption(new DialogText(102000, 102001, "Hier is het water, hopelijk helpt het.", true));
        AddOption(new DialogText(102001, 102011, "Ik zal het even proberen, ik wilde deze bloemen graag zelf groeien om naar mijn moeder te brengen."));
        AddOption(new DialogText(102011, 102500, "*Jack geeft de bloem water en jullie wachten.*"));
        AddOption(new Function(102500, 102501, 102600));
        AddOption(new Function(102501, 102002, 100600));

        AddOption(new DialogText(102002, 102003, "Waarom wil je graag de bloemen naar je moeder brengen?", true));
        AddOption(new DialogText(102003, 102004, "Ja, mijn moeder was altijd een beetje vreemd. Wel ontzettend lief, maar gewoon een beetje vreemd."));
        AddOption(new DialogText(102004, 102005, "Hmm vreemd? Hoezo vreemd?", true));
        AddOption(new DialogText(102005, 102006, "Toen ik klein was, bakte ze wel eens koekjes en die gaf ze dan aan mijn vrienden op school en bij elk koekje zat een handgeschreven briefje."));
        AddOption(new DialogText(102006, 102007, "op die briefjes stond dan hoe blij ze was dat ze mijn vrienden waren."));
        AddOption(new DialogText(102007, 102008, "Heb je haar nooit gevraagd waarom ze dat deed vroeger?", true));
        AddOption(new DialogText(102008, 102502, "Nee, en nu kan dat ook niet meer."));
        AddOption(new Function(102502, 102009, 102600));
        AddOption(new DialogText(102009, 102010, "Ah de bloem is gegroeid! Nu kan ik hem eindelijk bij mijn moeder neerleggen."));
        AddOption(new DialogText(102010, 102503, "*Jack loopt weg, misschien moet je hem even gaan zoeken*"));
        AddOption(new Function(102503, 102504, 102601));
        AddOption(new Function(102504, 404, 100600));
    }

    private void QuestProgress3()
    {
        AddOption(new Choice(103100, 103000, 103000, "Afgelopen zomer kreeg ik het telefoontje...", "Was dat haar voor die bomen?", "Bijzondere bomen op de foto."));
        AddOption(new DialogText(103000, 103001, "We hadden vroeger drie bomen in de tuin staan en hoewel mijn moeder deze bomen gewoon verzorgde, was ze er ook heel vaak tegen aan het praten."));
        AddOption(new DialogText(103001, 103002, "Maar de bomen waren zo belangrijk voor haar, soms hield ze gewoon volledig eenzijdige gesprekken met de bomen."));
        AddOption(new DialogText(103002, 103003, "En ze gaf de bomen ook namen, we hadden Iris de appelboom, Tom de eikenboom en Vincent de berk."));
        AddOption(new DialogText(103003, 103500, "Ik heb wel spijt van dat ik de laatste jaren niet veel tijd met haar heb doorgebracht."));
        AddOption(new Function(103500, 103501, 103600));
        AddOption(new Function(103501, 199997, 101694));
    }

    private void StartEndScene()
    {

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
    private void SetNextQuestMarker()
    {
        currentQuestProgress++;
        if (currentQuestProgress > questMarkerPositions.Count - 1)
        {
            marker.gameObject.SetActive(false);
            return;
        }
        else
            marker.gameObject.SetActive(true);
        marker.position = questMarkerPositions[currentQuestProgress].position;
    }
    private void EnableWaterPickup()
    {
        emptyBucket.gameObject.SetActive(false);
        waterBucket.gameObject.SetActive(true);
    }
}
