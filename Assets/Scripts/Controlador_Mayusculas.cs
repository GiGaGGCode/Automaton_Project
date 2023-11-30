using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlador_Mayusculas : MonoBehaviour
{
    public TMPro.TMP_InputField inputField;
    public TMPro.TMP_InputField inputField2;
    public TMPro.TMP_Text text;
    public TMPro.TMP_Text text2;

    public List<string> abreviacionesList = new List<string>();

    void Start(){
        abreviacionesList.Add("AS");
        abreviacionesList.Add("BC");
        abreviacionesList.Add("BS");
        abreviacionesList.Add("CC");
        abreviacionesList.Add("CL");
        abreviacionesList.Add("CM");
        abreviacionesList.Add("CS");
        abreviacionesList.Add("CH");
        abreviacionesList.Add("DF");
        abreviacionesList.Add("DG");
        abreviacionesList.Add("GT");
        abreviacionesList.Add("GR");
        abreviacionesList.Add("HG");
        abreviacionesList.Add("JC");
        abreviacionesList.Add("MC");
        abreviacionesList.Add("MN");
        abreviacionesList.Add("MS");
        abreviacionesList.Add("NT");
        abreviacionesList.Add("NL");
        abreviacionesList.Add("OC");
        abreviacionesList.Add("PL");
        abreviacionesList.Add("QT");
        abreviacionesList.Add("QR");
        abreviacionesList.Add("SP");
        abreviacionesList.Add("SL");
        abreviacionesList.Add("SR");
        abreviacionesList.Add("TC");
        abreviacionesList.Add("TS");
        abreviacionesList.Add("TL");
        abreviacionesList.Add("VZ");
        abreviacionesList.Add("YN");
        abreviacionesList.Add("ZS");
        abreviacionesList.Add("NE");
    }

    public void ConvertToUppercase(string text)
    {
        // Convierte el texto a mayúsculas y establece el resultado en el InputField.
        inputField.text = text.ToUpper();
        inputField2.text = text.ToUpper();
    }

    public void Detectar_Curp(){
        //Expresion regular para detectar la CURP
        string curp = inputField.text;
        string pattern = @"^[A-Z]{1}[AEIOU]{1}[A-Z]{2}\d{2}(0[1](0[1-9]|1[0-9]|2[0-9]|3[0-1])|0[2](0[1-9]|1[0-9]|2[0-9])|0[3-9](0[1-9]|1[0-9]|2[0-9]|3[0-1])|1[0-2](0[1-9]|1[0-9]|2[0-9]|3[0-1]))[H|M]{1}[A-Z]{2}[BCDFGHJKLMNÑPQRSTVWXYZ]{3}[A-Z]{1}[0-9]{1}$";
        if (System.Text.RegularExpressions.Regex.IsMatch(curp, pattern))
        {
            text.text = "VALIDO";
            text.color = Color.green;
        }
        else
        {
            text.text = "INVALIDO";
            text.color = Color.red;
        }
    }

    public void Dectar_CurpAutomata(){
        string curp = inputField2.text;
        if(curp.Length != 18){
            text2.text = "INVALIDO";
            text2.color = Color.red;
            return;
        }
        if(curp[0]>=65 && curp[0]<=90){
            if(curp[1]=='A' || curp[1]=='E' || curp[1]=='I' || curp[1]=='O' || curp[1]=='U'){
                if(curp[2]>=65 && curp[2]<=90){
                    if(curp[3]>=65 && curp[3]<=90){
                        if(curp[4]>=48 && curp[4]<=57){
                            if(curp[5]>=48 && curp[5]<=57){
                                if(curp[6]=='0' && curp[7]=='2'){
                                    //validar febrero 29 dias máximos
                                    if((curp[8]=='0' && (curp[9]>=49 && curp[9]<=57)) || ((curp[8]=='1' || curp[8]=='2') && (curp[9]>=48 && curp[9]<=56))){	
                                        if(curp[10]=='H' || curp[10]=='M'){
                                            string tmp = curp[11].ToString() + curp[12].ToString();
                                            if(abreviacionesList.Contains(tmp)){
                                                if(curp[13]=='B' || curp[13]=='C' || curp[13]=='D' || curp[13]=='F' || curp[13]=='G' || curp[13]=='H' || curp[13]=='J' || curp[13]=='K' || curp[13]=='L' || curp[13]=='M' || curp[13]=='N' || curp[13]=='Ñ' || curp[13]=='P' || curp[13]=='Q' || curp[13]=='R' || curp[13]=='S' || curp[13]=='T' || curp[13]=='V' || curp[13]=='W' || curp[13]=='X' || curp[13]=='Y' || curp[13]=='Z'){
                                                    if(curp[14] == 'B' || curp[14] == 'C' || curp[14] == 'D' || curp[14] == 'F' || curp[14] == 'G' || curp[14] == 'H' || curp[14] == 'J' || curp[14] == 'K' || curp[14] == 'L' || curp[14] == 'M' || curp[14] == 'N' || curp[14] == 'Ñ' || curp[14] == 'P' || curp[14] == 'Q' || curp[14] == 'R' || curp[14] == 'S' || curp[14] == 'T' || curp[14] == 'V' || curp[14] == 'W' || curp[14] == 'X' || curp[14] == 'Y' || curp[14] == 'Z'){
                                                        if(curp[15] == 'B' || curp[15] == 'C' || curp[15] == 'D' || curp[15] == 'F' || curp[15] == 'G' || curp[15] == 'H' || curp[15] == 'J' || curp[15] == 'K' || curp[15] == 'L' || curp[15] == 'M' || curp[15] == 'N' || curp[15] == 'Ñ' || curp[15] == 'P' || curp[15] == 'Q' || curp[15] == 'R' || curp[15] == 'S' || curp[15] == 'T' || curp[15] == 'V' || curp[15] == 'W' || curp[15] == 'X' || curp[15] == 'Y' || curp[15] == 'Z'){
                                                            if((curp[16]>=48 && curp[16]<=57) || (curp[16]>=65 && curp[16]<=90)){
                                                                if((curp[17]>=48 && curp[17]<=57) || (curp[17]>=65 && curp[17]<=90)){
                                                                    text2.text = "VALIDO";
                                                                    text2.color = Color.green;
                                                                    return;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else if((curp[6]=='0' && (curp[7]=='1' || (curp[7]>=51 && curp[7]<=57))) || (curp[6]=='1' && (curp[7]=='0' || curp[7]=='1' || curp[7]=='2'))){
                                    if((curp[8]=='0' && (curp[9]>=49 && curp[9]<=57)) || ((curp[8]=='1' || curp[8]=='2') && (curp[9]>=48 && curp[9]<=57)) || (curp[8]=='3' && (curp[9]=='0' || curp[9]=='1'))){	
                                        if(curp[10]=='H' || curp[10]=='M'){
                                            string tmp = curp[11].ToString() + curp[12].ToString();
                                            if(abreviacionesList.Contains(tmp)){
                                                if(curp[13]=='B' || curp[13]=='C' || curp[13]=='D' || curp[13]=='F' || curp[13]=='G' || curp[13]=='H' || curp[13]=='J' || curp[13]=='K' || curp[13]=='L' || curp[13]=='M' || curp[13]=='N' || curp[13]=='Ñ' || curp[13]=='P' || curp[13]=='Q' || curp[13]=='R' || curp[13]=='S' || curp[13]=='T' || curp[13]=='V' || curp[13]=='W' || curp[13]=='X' || curp[13]=='Y' || curp[13]=='Z'){
                                                    if(curp[14] == 'B' || curp[14] == 'C' || curp[14] == 'D' || curp[14] == 'F' || curp[14] == 'G' || curp[14] == 'H' || curp[14] == 'J' || curp[14] == 'K' || curp[14] == 'L' || curp[14] == 'M' || curp[14] == 'N' || curp[14] == 'Ñ' || curp[14] == 'P' || curp[14] == 'Q' || curp[14] == 'R' || curp[14] == 'S' || curp[14] == 'T' || curp[14] == 'V' || curp[14] == 'W' || curp[14] == 'X' || curp[14] == 'Y' || curp[14] == 'Z'){
                                                        if(curp[15] == 'B' || curp[15] == 'C' || curp[15] == 'D' || curp[15] == 'F' || curp[15] == 'G' || curp[15] == 'H' || curp[15] == 'J' || curp[15] == 'K' || curp[15] == 'L' || curp[15] == 'M' || curp[15] == 'N' || curp[15] == 'Ñ' || curp[15] == 'P' || curp[15] == 'Q' || curp[15] == 'R' || curp[15] == 'S' || curp[15] == 'T' || curp[15] == 'V' || curp[15] == 'W' || curp[15] == 'X' || curp[15] == 'Y' || curp[15] == 'Z'){
                                                            if((curp[16]>=48 && curp[16]<=57) || (curp[16]>=65 && curp[16]<=90)){
                                                                if((curp[17]>=48 && curp[17]<=57) || (curp[17]>=65 && curp[17]<=90)){
                                                                    text2.text = "VALIDO";
                                                                    text2.color = Color.green;
                                                                    return;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        text2.text = "INVALIDO";
        text2.color = Color.red;
        return;
    }
}
