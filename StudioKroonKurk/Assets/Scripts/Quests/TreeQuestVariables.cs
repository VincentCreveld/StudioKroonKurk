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
	#endregion

	#region Progress2
	#endregion

	#region Progress3
	#endregion
}
