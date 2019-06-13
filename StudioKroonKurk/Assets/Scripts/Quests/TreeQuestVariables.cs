using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TreeQuest
{
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
			Statics = 9
     */
	 // Gets called on -1 increment
	public string foundJackText;
	private int EntryId = 100300;
	private int AddProg = 100900;
    private int CloseDialog = 100901;
	private int QuestComp = 100902;
	private int QuestOngoing = 100903;
	private int QuestCanAccept = 100904;
	private int QuestClosed = 100905;
	private int CloseDiaFunc = 100906;
	private int SetToInProgress = 100907;
	private int SetToInProgressFunc = 100908;
    private int RemoveRoots = 100909;
    private int RemoveRootsFunc = 100910;

    #region ProgressGates
    private int ProgressNeg1 = 100400;
	private int Progress0 = 100401;
	private int Progress1 = 100402;
	private int Progress2 = 100403;
	private int Progress3 = 100404;
	#endregion

	#region Progress-1
	private int PN1_Entry = 100000;
	private int PN1_D0 = 100000;
	private int PN1_D1 = 100001;
	private int PN1_D2 = 100002;
	private int PN1_D3 = 100003;
	private int PN1_D4 = 100004;
	private int PN1_D5 = 100005;
	private int PN1_D6 = 100006;
	private int PN1_C0 = 100100;
	private int PN1_C1 = 100101;
	private int PN1_C2 = 100102;
	private int PN1_C3 = 100103;
	#endregion

	#region Progress0
	private int P0_Entry = 101200;
	// Item gates
	private int P0_IG0 = 101200;
	private int P0_IG1 = 101201;
	// Items to check
	private int P0_I0 = 101700;
	private int P0_I1 = 101701;
	// Animation
	private int P0_A0 = 101990;
	private int P0_A1 = 101991;
	private int P0_A2 = 101992;
	// Animation id
	private int P0_AI0 = 0;
	private int P0_AI1 = 1;
	private int P0_AI2 = 2;

	private int P0_D0 = 101000;
	private int P0_D1 = 101001;
	private int P0_D2 = 101002;
	private int P0_D3 = 101003;
	private int P0_D4 = 101004;
	private int P0_D5 = 101005;
	private int P0_D6 = 101006;
	private int P0_D7 = 101007;
	private int P0_D8 = 101008;
	private int P0_D9 = 101009;
	private int P0_D10 = 101010;
	private int P0_D11 = 101011;
	private int P0_D12 = 101012;
	private int P0_D13 = 101013;
	private int P0_D14 = 101014;

	private int P0_C0 = 101100;
	private int P0_C1 = 101101;
	#endregion

	#region Progress1
	private int P1_Entry = 102990;

	private int P1_A0 = 102990;
	private int P1_A1 = 102991;
	private int P1_AI0 = 3;
	private int P1_AI1 = 4;

	private int P1_C0 = 102100;

	private int P1_D0 = 102000;
	private int P1_D1 = 102001;
	private int P1_D2 = 102002;
	private int P1_D3 = 102003;
	private int P1_D4 = 102004;
	private int P1_D5 = 102005;
	private int P1_D6 = 102006;
    private int P1_D7 = 102007;
    private int P1_D8 = 102008;
    #endregion

    #region Progress2
    private int P2_Entry = 103900;

    private int P2_A0 = 103900;
    private int P2_A1 = 103901;
    private int P2_AI0 = 5;
    private int P2_AI1 = 6;

    private int P2_C0 = 103100;
    private int P2_C1 = 103101;
    private int P2_C2 = 103102;
    private int P2_C3 = 103103;
    private int P2_C4 = 103104;
    private int P2_C5 = 103105;
    private int P2_C6 = 103106;
    private int P2_C7 = 103107;
    private int P2_C8 = 103108;
    private int P2_C9 = 103109;
    private int P2_C10 = 103110;
    private int P2_C11 = 103111;


    private int P2_D0 = 103000;
    private int P2_D1 = 103001;
    private int P2_D2 = 103002;
    private int P2_D3 = 103003;
    private int P2_D4 = 103004;
    private int P2_D5 = 103005;
    private int P2_D6 = 103006;
    private int P2_D7 = 103007;
    private int P2_D8 = 103008;
    private int P2_D9 = 103009;
    private int P2_D10 = 103010;
    private int P2_D11 = 103011;
    private int P2_D12 = 103012;
    private int P2_D13 = 103013;
    private int P2_D14 = 103014;
    private int P2_D15 = 103015;
    private int P2_D16 = 103016;
    private int P2_D17 = 103017;
    private int P2_D18 = 103018;
    private int P2_D19 = 103019;
    private int P2_D20 = 103020;
    private int P2_D21 = 103021;
    private int P2_D22 = 103022;
    private int P2_D23 = 103023;
    private int P2_D24 = 103024;
    private int P2_D25 = 103025;
    private int P2_D26 = 103026;
    private int P2_D27 = 103027;
    private int P2_D28 = 103028;
    private int P2_D29 = 103029;
    private int P2_D30 = 103030;
    private int P2_D31 = 103031;
    private int P2_D32 = 103032;
    private int P2_D33 = 103033;
    private int P2_D34 = 103034;
    private int P2_D35 = 103035;
    private int P2_D36 = 103036;
    private int P2_D37 = 103037;
    private int P2_D38 = 103038;
    private int P2_D39 = 103039;
    private int P2_D40 = 103040;
    private int P2_D41 = 103041;



    #endregion

    #region Progress3
    #endregion
}
