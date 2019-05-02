using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeQuest : Quest
{
    public List<Transform> questMarkerPositions;
    public Transform marker;
    public int questNo;
    public Transform emptyBucket, waterBucket;

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
     */

    // Entry 100300
    public override void Initialise(int i)
    {
        gm.questList.Add(questNo, this);

        AddOption(new DialogText(199999, 404, "Je hebt me al geholpen! dankjewel."));
        AddOption(new DialogText(199998, 404, "Ik heb je hulp nog niet nodig."));
        AddOption(new DialogText(199997, 404, "Bedankt voor de hulp!"));
        QuestProgress0();
        QuestProgress1();
        QuestProgress2();
        QuestProgress3();

        AddOption(new QuestGate(100300, 199999, 100400, 100100, 199998, questNo));
        //SOLVE THESE
        AddOption(new QuestStepGate(100400, 101200, 100401, questNo, 1));
        AddOption(new QuestStepGate(100401, 102000, 100402, questNo, 2));
        AddOption(new QuestStepGate(100402, 103000, 100403, questNo, 3));
        AddOption(new QuestStepGate(100403, 104000, 100404, questNo, 4));
        AddOption(new QuestStepGate(100404, 105000, 100405, questNo, 5));
        AddOption(new QuestStepGate(100405, 106000, 199997, questNo, 6));

        gm.dSFuncDict.Add(100600, SetNextQuestMarker);
        gm.dSFuncDict.Add(101600, StartGiveWater);
        gm.dSFuncDict.Add(102600, FlowerGrows);
        gm.dSFuncDict.Add(103600, StartEndScene);
        gm.dSFuncDict.Add(101697, () => { EnableWaterPickup(); });
        gm.dSFuncDict.Add(101695, () => state = QuestState.ongoing );
    }

    private void AddOption(DialogEntity e)
    {
        gm.allOptions.Add(e);
    }

    private void QuestProgress0()
    {
        AddOption(new Choice(100100, 404, 100000, "Hey, zou je me kunnen helpen?", "Ik heb nu even geen tijd.", "Waar heb je hulp bij nodig?"));
        AddOption(new DialogText(100000, 100101, "Ik ben opzoek naar iemand die \nwat water kan halen."));
        AddOption(new Choice(100101, 100002, 100002, "Ik probeer deze bloemen te laten groeien \n, maar ze lijken steeds dood te gaan.", "Ik kan wel wat water voor je zoeken", "Geen probleem, maar waar vind ik water?"));
        AddOption(new DialogText(100001, 100002, "Een stukje verderop in het noorden zag \nik een beekje. Ik moet hier ergens \nin de buurt ook een emmer \nhebben staan."));
        AddOption(new DialogText(100002, 100599, "Ik zal kijken wat ik voor je kan doen."));
        AddOption(new Function(100500, 404, 100600));
        AddOption(new Function(100599, 100598, 100600));
        AddOption(new Function(100598, 100500, 101695));
    }

    private void QuestProgress1()
    {
        gm.itemList.Add(101700, new Item(101700, "Emmer"));
        gm.itemList.Add(101701, new Item(101701, "WaterEmmer"));
        AddOption(new ItemGate(101200, 101201, 101000, 101700));
        AddOption(new ItemGate(101201, 101004, 101002, 101701));
        AddOption(new DialogText(101004, 101005, "Hier is het water, hopelijk helpt het."));
        AddOption(new DialogText(101005, 101500, "Ik zal het even proberen, ik wilde deze bloemen zelf groeien om naar mijn moeder te brengen."));
        AddOption(new DialogText(101002, 101003, "Het beekje zou ergens in het oosten moeten zijn, volg je de weg, dan vind je het wel."));
        AddOption(new DialogText(101003, 404, "Ik zal wel even kijken!"));
        AddOption(new DialogText(101000, 101001, "Heb je de emmer al gevonden? \nHij zou ergens naast mijn \nschuurtje moeten staan."));
        AddOption(new DialogText(101001, 404, "Top, dan zal ik hem wel vinden."));
        AddOption(new Function(101500, 101501, 101600));
        AddOption(new Function(101501, 404, 100600));
    }

    private void QuestProgress2()
    {
        AddOption(new DialogText(102000, 102001, "Waarom wil je graag de bloemen naar je moeder brengen?"));
        AddOption(new DialogText(102001, 102002, "Ja, mijn moeder was altijd een beetje vreemd. Wel ontzettend lief, maar gewoon een beetje vreemd."));
        AddOption(new DialogText(102002, 102003, "Hmm vreemd? Hoezo vreemd?"));
        AddOption(new DialogText(102003, 102004, "Toen ik klein was, bakte ze koekjes voor mijn vrienden op school en die gaf ze dan aan mijn vrienden met een handgeschreven briefje erbij."));
        AddOption(new DialogText(102004, 102005, "Dan zette ze daarop hoe blij ze was dat ze mijn vrienden waren."));
        AddOption(new DialogText(102005, 102006, "Heb je haar nooit gevraagd waarom ze dat deed vroeger?"));
        AddOption(new DialogText(102006, 102500, "Nee, en nu kan dat ook niet meer."));
        AddOption(new Function(102500, 102007, 102600));
        AddOption(new DialogText(102007, 102501, "Ah de bloem is gegroeid! Nu kan ik hem eindelijk bij mijn moeder neerleggen."));
        AddOption(new Function(102501, 102502, 102601));
        AddOption(new Function(102502, 404, 100600));
    }

    private void QuestProgress3()
    {
        AddOption(new Choice(103100, 103000, 103000, "Afgelopen zomer kreeg ik het telefoontje...", "Was dat haar op die foto?", "Bijzondere bomen zeg."));
        AddOption(new DialogText(103000, 103001, "We hadden vroeger drie bomen in de tuin en ze was altijd aan het praten met de bomen. En ze verzorgde de bomen ook wel normaal. "));
        AddOption(new DialogText(103001, 103002, "Maar de bomen waren zo belangrijk voor haar, soms hield ze gewoon volledig eenzijdige gesprekken met de bomen."));
        AddOption(new DialogText(103002, 103003, "En ze gaf de bomen ook namen, we hadden Daphne de appelboom, Tom de eikenboom en Vincent de berk."));
        AddOption(new DialogText(103003, 103500, "Ik heb wel spijt van dat ik de laatste jaren niet veel tijd met haar heb doorgebracht."));
        AddOption(new Function(102502, 404, 103600));
    }

    private void StartEndScene()
    {

    }
    private void FlowerGrows()
    {

    }
    private void StartGiveWater()
    {

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
