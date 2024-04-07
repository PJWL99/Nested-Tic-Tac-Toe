using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gamecontroler : MonoBehaviour
{

    public int whosturn; //0 = x, 1 = O
    public int turncounter; // count the no. of turns played
    public GameObject[] turnIcons; // displays whos turn it is;
    public Sprite[] playerIcons; 
    public Button[] tictactoespaces;
    public int[] markedspaces;

    public TextMeshProUGUI winnertext;

    public GameObject[] winningline;
    public GameObject winnerpanel;

    public int[] maingridmarkedspaces = new int[9];

    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }

    public void GameSetup(){
        whosturn = 0;
        turncounter = 0;
        turnIcons[0].SetActive(true);
        turnIcons[1].SetActive(false);
        for(int i = 0; i < tictactoespaces.Length; i++){
            tictactoespaces[i].interactable = true;
            tictactoespaces[i].GetComponent<Image>().sprite = null;        }

        for(int i = 0; i < markedspaces.Length; i++){
            markedspaces[i] = -100;
        }
        for(int i = 0; i < 9; i++){
            maingridmarkedspaces[i] = -100;
        }
    }

        

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void tictactoebutton(int whichnumber){
        tictactoespaces[whichnumber].image.sprite = playerIcons[whosturn];

        for(int i = 0; i < 9; i++){
            if(whichnumber%9 == i){
            
            
                for(int j = 0; j < i*9; j++){
                tictactoespaces[j].interactable = false;
            }
            for(int j = i*9; j < i*9+9; j++){
                tictactoespaces[j].interactable = true;
            }
            for(int j = i*9+9; j < 81; j++){
                tictactoespaces[j].interactable = false;
            }
            }
        }
        

        tictactoespaces[whichnumber].interactable = false;
        markedspaces[whichnumber] = whosturn+1;
        for(int i = 0; i < 81; i++){
            if(markedspaces[i] != -100){
                tictactoespaces[i].interactable = false;
            }
        }

        turncounter++;
        

        if(turncounter > 4){
            winnercheck00();
            winnercheck01();
            winnercheck02();
            winnercheck10();
            winnercheck11();
            winnercheck12();
            winnercheck20();
            winnercheck21();
            winnercheck22();
        }

        for(int i = 0; i < 9; i++){
            if(whichnumber%9 == i){
        if(maingridmarkedspaces[i] != -100){
                for(int j = 0; j < i*9; j++){
                    if(markedspaces[j] == -100){
                        tictactoespaces[j].interactable = true;
                    }
                }

                for(int j = i*9; j < i*9+9; j++){
                tictactoespaces[j].interactable = false;
            }

                for(int j = i*9+9; j < 81; j++){
                    if(markedspaces[j] == -100){
                        tictactoespaces[j].interactable = true;
                    }
                }
            }
            }
        }

        int count = 0;
        for(int i = 0; i < 81; i++){
            if(markedspaces[i] != -100){
                count++;
            }
        }
        if(count == 81){
            winnerpanel.gameObject.SetActive(true);
            winnertext.text = "It's a Tie!!!";
        }

        if(turncounter > 16){
            mainwincheck();
        }

        
//D:\unity\My project\Assets\Scripts\game controler.cs


        if(whosturn == 0){
            whosturn = 1;
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }
        else{
            whosturn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
    }

    

    void winnercheck00(){
        int s1 = markedspaces[0] + markedspaces[1] + markedspaces[2];
        int s2 = markedspaces[3] + markedspaces[4] + markedspaces[5];
        int s3 = markedspaces[6] + markedspaces[7] + markedspaces[8];
        int s4 = markedspaces[0] + markedspaces[3] + markedspaces[6];
        int s5 = markedspaces[1] + markedspaces[4] + markedspaces[7];
        int s6 = markedspaces[2] + markedspaces[5] + markedspaces[8];
        int s7 = markedspaces[0] + markedspaces[4] + markedspaces[8];
        int s8 = markedspaces[2] + markedspaces[4] + markedspaces[6];

        var solution = new int[] {s1,s2,s3,s4,s5,s6,s7,s8};
        for(int i = 0; i < solution.Length; i++){
            if(solution[i] == 3*(whosturn+1)){
                // winnerdisplay(i);
                for(int j = 0; j < 9; j++){
                    tictactoespaces[j].image.sprite = playerIcons[whosturn];
                    markedspaces[j] = whosturn+1;
                }
                maingridmarkedspaces[0] = whosturn+1;
                return;
            }
        }
    }

    void winnercheck01(){
        int s1 = markedspaces[9] + markedspaces[10] + markedspaces[11];
        int s2 = markedspaces[12] + markedspaces[13] + markedspaces[14];
        int s3 = markedspaces[15] + markedspaces[16] + markedspaces[17];
        int s4 = markedspaces[9] + markedspaces[12] + markedspaces[15];
        int s5 = markedspaces[10] + markedspaces[13] + markedspaces[16];
        int s6 = markedspaces[11] + markedspaces[14] + markedspaces[17];
        int s7 = markedspaces[9] + markedspaces[13] + markedspaces[17];
        int s8 = markedspaces[11] + markedspaces[13] + markedspaces[15];

        var solution = new int[] {s1,s2,s3,s4,s5,s6,s7,s8};
        for(int i = 0; i < solution.Length; i++){
            if(solution[i] == 3*(whosturn+1)){
                // winnerdisplay(i);
                for(int j = 9; j < 18; j++){
                    tictactoespaces[j].image.sprite = playerIcons[whosturn];
                    markedspaces[j] = whosturn+1;
                }
                maingridmarkedspaces[1] = whosturn+1;
                return;
            }
        }
    }

    void winnercheck02(){
        int s1 = markedspaces[18] + markedspaces[19] + markedspaces[20];
        int s2 = markedspaces[21] + markedspaces[22] + markedspaces[23];
        int s3 = markedspaces[24] + markedspaces[25] + markedspaces[26];
        int s4 = markedspaces[18] + markedspaces[22] + markedspaces[26];
        int s5 = markedspaces[20] + markedspaces[22] + markedspaces[24];
        int s6 = markedspaces[18] + markedspaces[21] + markedspaces[24];
        int s7 = markedspaces[19] + markedspaces[22] + markedspaces[25];
        int s8 = markedspaces[20] + markedspaces[23] + markedspaces[26];

        var solution = new int[] {s1,s2,s3,s4,s5,s6,s7,s8};
        for(int i = 0; i < solution.Length; i++){
            if(solution[i] == 3*(whosturn+1)){
                // winnerdisplay(i);
                for(int j = 18; j < 27; j++){
                    tictactoespaces[j].image.sprite = playerIcons[whosturn];
                    markedspaces[j] = whosturn+1;
                }
                maingridmarkedspaces[2] = whosturn+1;
                return;
            }
        }
        return;
    }

    void winnercheck10(){
        int s1 = markedspaces[27] + markedspaces[28] + markedspaces[29];
        int s2 = markedspaces[30] + markedspaces[31] + markedspaces[32];
        int s3 = markedspaces[33] + markedspaces[34] + markedspaces[35];
        int s4 = markedspaces[27] + markedspaces[30] + markedspaces[33];
        int s5 = markedspaces[28] + markedspaces[31] + markedspaces[34];
        int s6 = markedspaces[29] + markedspaces[32] + markedspaces[35];
        int s7 = markedspaces[27] + markedspaces[31] + markedspaces[35];
        int s8 = markedspaces[29] + markedspaces[31] + markedspaces[33];

        var solution = new int[] {s1,s2,s3,s4,s5,s6,s7,s8};
        for(int i = 0; i < solution.Length; i++){
            if(solution[i] == 3*(whosturn+1)){
                // winnerdisplay(i);
                for(int j = 27; j < 36; j++){
                    tictactoespaces[j].image.sprite = playerIcons[whosturn];
                    markedspaces[j] = whosturn+1;
                }
                maingridmarkedspaces[3] = whosturn+1;
                return;
            }
        }
        return;
    }

    void winnercheck11(){
        int s1 = markedspaces[36] + markedspaces[37] + markedspaces[38];
        int s2 = markedspaces[39] + markedspaces[40] + markedspaces[41];
        int s3 = markedspaces[42] + markedspaces[43] + markedspaces[44];
        int s4 = markedspaces[36] + markedspaces[39] + markedspaces[42];
        int s5 = markedspaces[37] + markedspaces[40] + markedspaces[43];
        int s6 = markedspaces[38] + markedspaces[41] + markedspaces[44];
        int s7 = markedspaces[36] + markedspaces[40] + markedspaces[44];
        int s8 = markedspaces[38] + markedspaces[40] + markedspaces[42];

        var solution = new int[] {s1,s2,s3,s4,s5,s6,s7,s8};
        for(int i = 0; i < solution.Length; i++){
            if(solution[i] == 3*(whosturn+1)){
                // winnerdisplay(i);
                for(int j = 36; j < 45; j++){
                    tictactoespaces[j].image.sprite = playerIcons[whosturn];
                    markedspaces[j] = whosturn+1;
                }
                maingridmarkedspaces[4] = whosturn+1;
                return;
            }
        }
        return;
    }

    void winnercheck12(){
        int s1 = markedspaces[45] + markedspaces[46] + markedspaces[47];
        int s2 = markedspaces[48] + markedspaces[49] + markedspaces[50];
        int s3 = markedspaces[51] + markedspaces[52] + markedspaces[53];
        int s4 = markedspaces[45] + markedspaces[48] + markedspaces[51];
        int s5 = markedspaces[46] + markedspaces[49] + markedspaces[52];
        int s6 = markedspaces[47] + markedspaces[50] + markedspaces[53];
        int s7 = markedspaces[45] + markedspaces[49] + markedspaces[53];
        int s8 = markedspaces[47] + markedspaces[49] + markedspaces[51];

        var solution = new int[] {s1,s2,s3,s4,s5,s6,s7,s8};
        for(int i = 0; i < solution.Length; i++){
            if(solution[i] == 3*(whosturn+1)){
                // winnerdisplay(i);
                for(int j = 45; j < 54; j++){
                    tictactoespaces[j].image.sprite = playerIcons[whosturn];
                    markedspaces[j] = whosturn+1;
                }
                maingridmarkedspaces[5] = whosturn+1;
                return;
            }
        }
        return;
    }

    void winnercheck20(){
        int s1 = markedspaces[54] + markedspaces[55] + markedspaces[56];
        int s2 = markedspaces[57] + markedspaces[58] + markedspaces[59];
        int s3 = markedspaces[60] + markedspaces[61] + markedspaces[62];
        int s4 = markedspaces[54] + markedspaces[57] + markedspaces[60];
        int s5 = markedspaces[55] + markedspaces[58] + markedspaces[61];
        int s6 = markedspaces[56] + markedspaces[59] + markedspaces[62];
        int s7 = markedspaces[54] + markedspaces[58] + markedspaces[62];
        int s8 = markedspaces[56] + markedspaces[58] + markedspaces[60];

        var solution = new int[] {s1,s2,s3,s4,s5,s6,s7,s8};
        for(int i = 0; i < solution.Length; i++){
            if(solution[i] == 3*(whosturn+1)){
                // winnerdisplay(i);
                for(int j = 54; j < 63; j++){
                    tictactoespaces[j].image.sprite = playerIcons[whosturn];
                    markedspaces[j] = whosturn+1;
                }
                maingridmarkedspaces[6] = whosturn+1;
                return;
            }
        }
        return;
    }

    void winnercheck21(){
        int s1 = markedspaces[63] + markedspaces[64] + markedspaces[65];
        int s2 = markedspaces[66] + markedspaces[67] + markedspaces[68];
        int s3 = markedspaces[69] + markedspaces[70] + markedspaces[71];
        int s4 = markedspaces[63] + markedspaces[66] + markedspaces[69];
        int s5 = markedspaces[64] + markedspaces[67] + markedspaces[70];
        int s6 = markedspaces[65] + markedspaces[68] + markedspaces[71];
        int s7 = markedspaces[63] + markedspaces[67] + markedspaces[71];
        int s8 = markedspaces[65] + markedspaces[67] + markedspaces[69];

        var solution = new int[] {s1,s2,s3,s4,s5,s6,s7,s8};
        for(int i = 0; i < solution.Length; i++){
            if(solution[i] == 3*(whosturn+1)){
                // winnerdisplay(i);
                for(int j = 63; j < 72; j++){
                    tictactoespaces[j].image.sprite = playerIcons[whosturn];
                    markedspaces[j] = whosturn+1;
                }
                maingridmarkedspaces[7] = whosturn+1;
                return;
            }
        }
        return;
    }

    void winnercheck22(){
        int s1 = markedspaces[72] + markedspaces[73] + markedspaces[74];
        int s2 = markedspaces[75] + markedspaces[76] + markedspaces[77];
        int s3 = markedspaces[78] + markedspaces[79] + markedspaces[80];
        int s4 = markedspaces[72] + markedspaces[75] + markedspaces[78];
        int s5 = markedspaces[73] + markedspaces[76] + markedspaces[79];
        int s6 = markedspaces[74] + markedspaces[77] + markedspaces[80];
        int s7 = markedspaces[72] + markedspaces[76] + markedspaces[80];
        int s8 = markedspaces[74] + markedspaces[76] + markedspaces[78];

        var solution = new int[] {s1,s2,s3,s4,s5,s6,s7,s8};
        for(int i = 0; i < solution.Length; i++){
            if(solution[i] == 3*(whosturn+1)){
                // winnerdisplay(i);
                for(int j = 72; j < 81; j++){
                    tictactoespaces[j].image.sprite = playerIcons[whosturn];
                    markedspaces[j] = whosturn+1;
                }
                maingridmarkedspaces[8] = whosturn+1;
                return;
            }
        }
        return;
    }

    void mainwincheck(){
        int s1 = maingridmarkedspaces[0] + maingridmarkedspaces[1] + maingridmarkedspaces[2];
        int s2 = maingridmarkedspaces[3] + maingridmarkedspaces[4] + maingridmarkedspaces[5];
        int s3 = maingridmarkedspaces[6] + maingridmarkedspaces[7] + maingridmarkedspaces[8];
        int s4 = maingridmarkedspaces[0] + maingridmarkedspaces[3] + maingridmarkedspaces[6];
        int s5 = maingridmarkedspaces[1] + maingridmarkedspaces[4] + maingridmarkedspaces[7];
        int s6 = maingridmarkedspaces[2] + maingridmarkedspaces[5] + maingridmarkedspaces[8];
        int s7 = maingridmarkedspaces[0] + maingridmarkedspaces[4] + maingridmarkedspaces[8];
        int s8 = maingridmarkedspaces[2] + maingridmarkedspaces[4] + maingridmarkedspaces[6];

        var solution = new int[] {s1,s2,s3,s4,s5,s6,s7,s8};
        for(int i = 0; i < solution.Length; i++){
            if(solution[i] == 3*(whosturn+1)){
                winnerdisplay(i);
                return;
            }
        }
        return;
    }

    void winnerdisplay(int index){
        winnerpanel.gameObject.SetActive(true);
        if(whosturn == 0){
            winnertext.text = "Player X Wins!";
        }

        else if(whosturn == 1){
            winnertext.text = "Player O wins!";
        }

        winningline[index].SetActive(true);
        
    }
}
